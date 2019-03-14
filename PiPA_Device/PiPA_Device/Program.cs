using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiPA_Device.Classes;
using System.Threading;

namespace PiPA_Device
{
    class Program
    {
        static void Main(string[] args)
        {
            string subKey = "01d2f52608044953b50c6b2e29891b92";
            string tokenUri = "https://westus2.api.cognitive.microsoft.com/sts/v1.0/issueToken";
            string regionUri = "westus2";
            string ttsUri = "https://westus2.tts.speech.microsoft.com/cognitiveservices/v1";
            Console.WriteLine("Hello! This is PiPA!");
            Authentication authenticator = new Authentication(subKey);
            string token = authenticator.GetAccessToken();

            SpeechToText speechToText = new SpeechToText(subKey, regionUri);

            while (true)
            {
                speechToText.SpeechContinuousRecognitionAsync().Wait();

                TextToSpeech textToSpeech = new TextToSpeech(speechToText.Command, token, ttsUri);
                textToSpeech.CreateSpeech().Wait();

                speechToText.RecognizeSpeechAsync().Wait();

                if (speechToText.Command == "add task")
                {
                    textToSpeech.Command = speechToText.Command;
                    textToSpeech.CreateSpeech().Wait();

                    speechToText.RecognizeSpeechAsync().Wait();
                    if (speechToText.Command == "name task")
                    {
                        textToSpeech.Text = speechToText.Speech;
                        textToSpeech.Command = speechToText.Command;
                        textToSpeech.CreateSpeech().Wait();

                        if(speechToText.Command == "Error")
                        {
                            textToSpeech.Command = speechToText.Command;
                            textToSpeech.CreateSpeech().Wait();
                        }
                    }
                }
                else if (speechToText.Command == "unclear")
                {
                    textToSpeech.Command = speechToText.Command;
                    textToSpeech.CreateSpeech().Wait();
                }
            }
        }
    }
}