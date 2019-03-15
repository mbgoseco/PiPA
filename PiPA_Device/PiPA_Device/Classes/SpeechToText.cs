using Microsoft.CognitiveServices.Speech;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace PiPA_Device.Classes
{
    public class SpeechToText : AddToDb
    {
        private readonly string _subKey;
        private readonly string _regionUri;
        public string Speech { get; set; }
        public string Command { get; set; }
        public bool TaskReady { get; set; } = false;

        public SpeechToText(string subKey, string regionUri)
        {
            _subKey = subKey;
            _regionUri = regionUri;
        }

        /// <summary>
        /// Starts speech recognition, and returns after a single utterance is recognized. The end of a single utterance is determined by listening for silence at the end or until a maximum of 15 seconds of audio is processed. The task returns the recognition text as result.
        /// </summary>
        /// <returns>User's speech rendered as text and response from PiPA device</returns>
        public async Task RecognizeSpeechAsync()
        {
            var config = SpeechConfig.FromSubscription(_subKey, _regionUri);
            config.OutputFormat = OutputFormat.Detailed;

            // Creates a speech recognizer.
            using (var recognizer = new SpeechRecognizer(config))
            {
                Console.WriteLine("Say something...");
                
                var result = await recognizer.RecognizeOnceAsync();

                // Checks result and perform action based on result text.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"We recognized: {result.Text}");

                    // Speech result logic
                    if ((result.Text.ToLower().Contains("add task") || result.Text.ToLower().Contains("add a task")) && TaskReady == false)
                    {
                        Command = "add task";
                        TaskReady = true;
                    }
                    else if (TaskReady)
                    {
                        TaskReady = false;
                        Command = "name task";
                        Speech = result.Text;
                        
                        Command = await AddAsync(Speech);
                    }
                    else
                    {
                        Command = "unclear";
                        TaskReady = false;
                    }
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    Command = "";
                    TaskReady = false;
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }

        /// <summary>
        /// Starts an instance of continuous speech regocnition. Task will return only when an recognized block of speech contains the keyphrase to wake up PiPA.
        /// </summary>
        /// <returns>Response from PiPA after wake up command is heard</returns>
        public async Task SpeechContinuousRecognitionAsync()
        {
            var config = SpeechConfig.FromSubscription(_subKey, _regionUri);
            bool wakeupKeyword = false;
            Speech = "";

            // Creates a speech recognizer from microphone.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Subscribes to events.
                recognizer.Recognizing += (s, e) => {
                    Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                };

                recognizer.Recognized += (s, e) => {
                    var result = e.Result;
                    Console.WriteLine($"Reason: {result.Reason.ToString()}");
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Console.WriteLine($"Final result: Text: {result.Text}.");
                        Speech = result.Text;
                        if (result.Text.ToLower().Contains("hello piper") || result.Text.ToLower().Contains("hello papa") || result.Text.ToLower().Contains("hello paper"))
                        {
                            Console.WriteLine("wakeup keyword hit!");
                            Command = "wake";
                            wakeupKeyword = true;
                        }
                    }
                };

                recognizer.Canceled += (s, e) => {
                    Console.WriteLine($"\n    Recognition Canceled. Reason: {e.Reason.ToString()}, CanceledReason: {e.Reason}");
                };

                recognizer.SessionStarted += (s, e) => {
                    Console.WriteLine("\n    Session started event.");
                };

                recognizer.SessionStopped += (s, e) => {
                    Console.WriteLine("\n    Session stopped event.");
                };

                // Starts continuous recognition.
                await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
                
                do
                {
                    // Continue listening until wake up phrase is heard.
                } while (!wakeupKeyword);

                // Stops continuous recognition.
                await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            }
        }
    }
}
