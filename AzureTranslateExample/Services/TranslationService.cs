using AzureTranslateExample.Interfaces;
using AzureTranslateExample.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AzureTranslateExample.Services
{
    public class TranslationService : ITranslationService
    {
        private DateTime _activeTokenTimestamp = DateTime.MinValue;
        private string _activeToken;

        public async Task<TranslationResponse> Translate(TranslationRequest request)
        {
            TranslationResponse response = await TryGetTranslation(request);
            if (response!= null && response.Success) return response;

            try
            {
                await RefreshBearerToken();
            }
            catch (Exception ex)
            {
                return new TranslationResponse()
                {
                    Success = false,
                    Message = "Unable to authenticate against the Azure Translation Service."
                };
            }

            response = await TryGetTranslation(request);
            if (response != null && response.Success) return response;
    
            response.Success = false;
            string str = string.Format("There was an error in getting the translation from the Azure Translation Service: {0}", (object) response.Message);
            response.Message = str;
            return response;
        }

        private async Task RefreshBearerToken()
        {
            TimeSpan timeSpan = DateTime.UtcNow - _activeTokenTimestamp;
            if (!string.IsNullOrEmpty(_activeToken) && timeSpan.TotalMinutes <= 8.0) return;

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();

            request.Headers.Add("Accept", "application/jwt");
            request.Headers.Add("Ocp-Apim-Subscription-Key", "9b4ceca92a814d46a9f6849a478b314f");
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri("https://api.cognitive.microsoft.com/sts/v1.0/issueToken");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(string.Format("Got back a {0} from the Azure Authentication Service.", response.StatusCode));
            }
            
            _activeToken = await response.Content.ReadAsStringAsync();
        }

        private async Task<TranslationResponse> TryGetTranslation(TranslationRequest request)
        {
            string uriString = string.Format("https://api.microsofttranslator.com/v2/http.svc/Translate?text={0}&from=en&to={1}", Uri.EscapeDataString(request.Text), Uri.EscapeDataString(request.ToLanguageISOCode));
            
            HttpClient httpClient = new HttpClient();
            var requestMessage = new HttpRequestMessage();

            requestMessage.Headers.Add("Authorization", string.Format("Bearer {0}", _activeToken));
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri(uriString);
         
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var serializer = new DataContractSerializer(Type.GetType("System.String"));
                Stream stream = await responseMessage.Content.ReadAsStreamAsync();
                string str = (string) serializer.ReadObject(stream);

                return new TranslationResponse()
                {
                    Success = true,
                    Text = str
                };
            }

            var response = new TranslationResponse();
            response.Success = false;
            response.Message = string.Format("{0}", responseMessage.StatusCode);
 
            return response;
        }
    }
}