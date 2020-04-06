using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cat0logic.MoviesLibrary
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string url, T data)
        {
            var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, payload);
            return response;
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string url, T data)
        {
            var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, payload);
            return response;
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch (Exception)
            {
            }
            return default(T);
        }
    }
}
