using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using NAudio.Wave;
using System.Threading;

namespace PiPA_Device.Classes
{
    public class TextToSpeech
    {
        public string Command { get; set; }
        public string Text { get; set; }
        public string Token { get; set; }
        public string Uri { get; set; }

        public TextToSpeech(string command, string token, string uri)
        {
            Command = command;
            Token = token;
            Uri = uri;
        }

        /// <summary>
        /// Selects a string phrase based on the command or input given to PiPA device. This phrase is then synthesized into a wav file and then played back to the user as a response from PiPA.
        /// </summary>
        /// <returns>Synthesized text to speech response from PiPA</returns>
        public async Task CreateSpeech()
        {
            string host = Uri;
            string body = "";

            switch (Command)
            {
                case "wake":
                    body = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)'>" + "<break time=\"300ms\" />" +
                  "Pie pa here. How can I help?" + "</voice></speak>";
                    break;
                case "add task":
                    body = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)'>" + "<break time=\"300ms\" />" +
                  "Okay. What would you like to call this task?" + "</voice></speak>";
                    break;
                case "name task":
                    body = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)'>" + "<break time=\"300ms\" />" +
                  $"Your task named, {Text}, has been added to your to do list." + "</voice></speak>";
                    break;
                case "unclear":
                    body = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)'>" + "<break time=\"300ms\" />" +
                  "Sorry, I don't understand that command." + "</voice></speak>";
                    break;
                case "Error":
                    body = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, Jessa24kRUS)'>" + "<break time=\"300ms\" />" +
                  "Sorry, there was a problem adding that to your list." + "</voice></speak>";
                    break;
                default:
                    break;
            }
            

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage())
                {
                    // Set the HTTP method
                    request.Method = HttpMethod.Post;
                    // Construct the URI
                    request.RequestUri = new Uri(host);
                    // Set the content type header
                    request.Content = new StringContent(body, Encoding.UTF8, "application/ssml+xml");
                    // Set additional header, such as Authorization and User-Agent
                    request.Headers.Add("Authorization", "Bearer " + Token);
                    request.Headers.Add("Connection", "Keep-Alive");
                    // Update your resource name
                    request.Headers.Add("User-Agent", "PiPA");
                    request.Headers.Add("X-Microsoft-OutputFormat", "riff-24khz-16bit-mono-pcm");
                    // Create a request
                    Console.WriteLine("Calling the TTS service. Please wait... \n");
                    using (var response = await client.SendAsync(request).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        // Asynchronously read the response
                        using (var dataStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            Console.WriteLine("Your speech file is being written to file...");
                            using (var fileStream = new FileStream(@"sample.wav", FileMode.Create, FileAccess.Write, FileShare.Write))
                            {
                                await dataStream.CopyToAsync(fileStream).ConfigureAwait(false);
                                fileStream.Close();
                            }
                            Console.WriteLine("\nPlaying back file...");
                            using (var audioFile = new AudioFileReader(@"sample.wav"))
                            using (var outputDevice = new WaveOutEvent())
                            {
                                outputDevice.Init(audioFile);
                                outputDevice.Play();
                                while (outputDevice.PlaybackState == PlaybackState.Playing)
                                {
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
