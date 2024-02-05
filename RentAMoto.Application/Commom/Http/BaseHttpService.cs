using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using RestSharp;

namespace RentAMoto.Application.Commom.Http
{
    public class BaseHttpService<T> : IBaseHttpService<T> where T : class
    {
        public async Task<T> PatchAsync(string url, object body)
        {
            var requestRest = new RestRequest(Method.PATCH);

            requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
            requestRest.Timeout = 1000000000;
            requestRest.ReadWriteTimeout = 1000000000;
            requestRest.AddJsonBody(body);

            var client = new RestClient(url);

            var response = await client.ExecuteAsync(requestRest);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            var result = JsonConvert.DeserializeObject<T>(response.Content);

            return result;
        }

        public async Task<T> PostJsonAsync<TValue>(string url, TValue value)
        {
            var client = new HttpClient();
            var result = await client.PostAsJsonAsync(url, value);

            if (result.IsSuccessStatusCode)
            {
                var strResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(strResult)!;
            }

            var message = $"HTTP Status {result.StatusCode} - Error retrieving response. Check inner details for more info.";
            throw new ApplicationException(message);
        }

        public async Task<T> SendAsync(string url)
        {
            var requestRest = new RestRequest(Method.GET);

            requestRest.AddHeader("Content-Type", "application/json; charset=utf-8");
            requestRest.Timeout = 1000000000;
            requestRest.ReadWriteTimeout = 1000000000;

            var client = new RestClient(url);

            var response = await client.ExecuteAsync(requestRest);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            var result = JsonConvert.DeserializeObject<T>(response.Content)!;
            return result;
        }
    }

}