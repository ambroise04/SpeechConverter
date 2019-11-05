using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http.Exceptions;
using IBM.Watson.SpeechToText.v1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogicConverter
{
    public class SpeechToText
    {
        private readonly string Key;
        public readonly string Url;

        private static readonly List<string> Extensions = new List<string>
        {
            "flac",
            "mp3",
            "mpeg",
            "mulaw"
        };

        IamAuthenticator authenticator;

        SpeechToTextService speechToTextService;

        public SpeechToText(){
            Key = "YuGYo0MhAKMBJJ1W4ofcvqzN5PCx2c_7C7OBXYyvPSlB";
            Url = "https://gateway-lon.watsonplatform.net/speech-to-text/api";
            Initialisation();
        }

        public SpeechToText(string Key, string Url)
        {
            this.Key = Key;
            this.Url = Url;
            Initialisation();
        }

        private void Initialisation()
        {
            authenticator = new IamAuthenticator(
                apikey: this.Key
            );

            speechToTextService = new SpeechToTextService(authenticator);
            speechToTextService.SetServiceUrl(this.Url);
        }

        public Texte ConvertAudio(string file)
        {
            var extension = CheckExtension(file);
            try
            {
                var result = speechToTextService.Recognize(audio: File.ReadAllBytes(file),
                    contentType: "audio/" + extension
                ); ;

                return TreatResponse(result);
            }
            catch (ServiceResponseException)
            {                
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Texte TreatResponse(IBM.Cloud.SDK.Core.Http.DetailedResponse<IBM.Watson.SpeechToText.v1.Model.SpeechRecognitionResults> response)
        {
            Texte texte = new Texte();

            var jsonResponse = JObject.Parse(response.Response);
            texte.Content = (string)jsonResponse["results"][0]["alternatives"][0]["transcript"];
            texte.StatusCode = response.StatusCode;
            texte.Headers = response.Headers;

            return texte;
        }
        
        private string CheckExtension(string file)
        {
            if (!File.Exists(file))
            {
                throw new InvalidFilePathException();
            }

            StringBuilder extension = new StringBuilder();

            extension.Append(Path.GetExtension(file).Remove(0, 1));

            if (!Extensions.Contains(extension.ToString()))
            {
                throw new UnavailableExtensionException();
            }

            return extension.ToString();
        }
    }
}