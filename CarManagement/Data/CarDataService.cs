using Newtonsoft.Json;
using System.Text;

namespace CarManagement.Data
{
    public static class CarDataService
    {

        public static string baseUri = "https://localhost:7278/api/";
        public static async Task<HttpResponseMessage> HttpMethodCalls(string actionUrl,System.Net.Http.HttpMethod httpMethod,string? body = null)
        {

            HttpResponseMessage response = new HttpResponseMessage();

            string newUri = string.Empty;
            try
            {
                using(HttpClient _httpClient = new HttpClient())
                {
                    newUri = string.Concat(baseUri, actionUrl);
                    StringContent? content = null;
                    if (!string.IsNullOrEmpty(body))
                    {
                        content = new StringContent(body, UnicodeEncoding.UTF8, "application/json");
                    }
                    if(httpMethod == System.Net.Http.HttpMethod.Get)
                    {
                        if (string.IsNullOrEmpty(body))
                            response = await  _httpClient.GetAsync(newUri);

                        else
                        {
                            newUri = string.Concat(newUri, body);
                            response = await _httpClient.GetAsync(newUri);
                        }
                    }
                    else if(httpMethod == System.Net.Http.HttpMethod.Post)
                    {
                        response = await _httpClient.PostAsync(newUri,content);
                    }
                    else
                    {
                        response = new HttpResponseMessage(System.Net.HttpStatusCode.MethodNotAllowed);
                    }

                }
                return response;
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }

    }
}
