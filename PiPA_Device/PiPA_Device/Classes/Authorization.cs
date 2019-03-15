using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PiPA_Device.Classes
{

    public class Authentication
    {
        
        private string _subscriptionKey;
        private readonly string _tokenUri;
        private string _token;
        private Timer accessTokenRenewer;

        //Access token expires every 10 minutes. Renew it every 9 minutes.
        private const int RefreshTokenDuration = 9;

        /// <summary>
        /// Creates an access token using the provided subscrition key and uri
        /// </summary>
        /// <param name="subscriptionKey">Azure Cognitive Services Speech API Key</param>
        /// <param name="tokenUri">Token URI string</param>
        public Authentication(string subscriptionKey, string tokenUri)
        {
            _subscriptionKey = subscriptionKey;
            _tokenUri = tokenUri;
            _token = FetchToken(_tokenUri, subscriptionKey).Result;

            // renew the token on set duration.
            accessTokenRenewer = new Timer(new TimerCallback(OnTokenExpiredCallback),
                                            this,
                                            TimeSpan.FromMinutes(RefreshTokenDuration),
                                            TimeSpan.FromMilliseconds(-1));
        }

        /// <summary>
        /// Gets the current access token
        /// </summary>
        /// <returns>Access token string</returns>
        public string GetAccessToken()
        {
            return _token;
        }

        /// <summary>
        /// Gets a new access token when the current one expires
        /// </summary>
        private void RenewAccessToken()
        {
            _token = FetchToken(_tokenUri, _subscriptionKey).Result;
            Console.WriteLine("Renewed token.");
        }

        /// <summary>
        /// Attempts to renew the access token after the current token expires (> 9 minutes)
        /// </summary>
        /// <param name="stateInfo">Current state of token object</param>
        private void OnTokenExpiredCallback(object stateInfo)
        {
            try
            {
                RenewAccessToken();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format($"Failed renewing access token. Details: {ex.Message}"));
            }
            finally
            {
                try
                {
                    accessTokenRenewer.Change(TimeSpan.FromMinutes(RefreshTokenDuration), TimeSpan.FromMilliseconds(-1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format($"Failed to reschedule the timer to renewaccesstoken.Details {ex.Message}"));
                }
            }
        }

        /// <summary>
        /// Fetches the access token using the provided uri and subscription key from Azure Coginitive Services Speech
        /// </summary>
        /// <param name="fetchUri">Fetch URI string</param>
        /// <param name="subscriptionKey">Azure Cognitive Services Speech subscription key</param>
        /// <returns>Http response message containing token</returns>
        private async Task<string> FetchToken(string fetchUri, string subscriptionKey)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                UriBuilder uriBuilder = new UriBuilder(fetchUri);

                var result = await client.PostAsync(uriBuilder.Uri.AbsoluteUri, null);
                Console.WriteLine($"Token Uri: {uriBuilder.Uri.AbsoluteUri}");
                return await result.Content.ReadAsStringAsync();
            }
        }
    }

}
