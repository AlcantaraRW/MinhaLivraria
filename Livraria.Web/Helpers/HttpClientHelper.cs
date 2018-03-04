using ModernHttpClient;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Web.Helpers
{
    public static class HttpClientHelper
    {
        public const string BaseUri = "http://localhost:50856/api/";
        private static HttpClient _client;

        static HttpClientHelper()
        {
            _client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        public static async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                var resp = await _client.GetAsync(uri);
                var respText = await resp.Content.ReadAsStringAsync();

                return JsonHelper.FromJson<T>(respText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<T> PostAsync<T>(string uri, T obj)
        {
            try
            {
                var json = JsonHelper.ToJson(obj);

                var resp = await _client.PostAsync(uri, GetStringContent(json));
                var respText = await resp.Content.ReadAsStringAsync();

                return JsonHelper.FromJson<T>(respText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<T> PutAsync<T>(string uri, T obj)
        {
            try
            {
                var json = JsonHelper.ToJson(obj);

                var resp = await _client.PutAsync(uri, GetStringContent(json));
                var respText = await resp.Content.ReadAsStringAsync();

                return JsonHelper.FromJson<T>(respText);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async void DeleteAsync(string uri)
        {
            try
            {
                var resp = await _client.DeleteAsync(uri);
                var respText = await resp.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static StringContent GetStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}