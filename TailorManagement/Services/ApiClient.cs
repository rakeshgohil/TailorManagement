using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagement.Services
{

    public class ApiClient
    {
        private static ApiClient apiClient;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static ApiClient GetApiClient()
        {
            if (apiClient == null)
            {
                apiClient = new ApiClient();
            }
            return apiClient;
        }

        public async Task<T> PostAsync<T>(T entity, string postApi)
        {            
            HttpResponseMessage response = await _httpClient.PostAsync(postApi, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(responseBody);
                return result;
            }
            else
            {
                return default(T);
            }
        }
    }
}
