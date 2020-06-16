using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Bindings.Helper
{
    public class ApiHelper
    {     
        public static HttpResponseMessage GetRequest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetAsync(url).Result;
                return result;
            }
        }

        public static T DeserialiseReponseMessage<T>(HttpResponseMessage responseMessage)
        {
            var resultContent = responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<T>(resultContent.Result);
            return response;
        }

    }
}
