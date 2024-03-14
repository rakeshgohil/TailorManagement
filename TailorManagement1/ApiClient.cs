using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagement1
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

        public async Task<T> GetAsync<T>(string getApi)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(getApi);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            return default(T);
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
        public async Task<T> PutAsync<T>(T entity, string putApi)
        {
            HttpResponseMessage response = await _httpClient.PutAsync(putApi, new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            return default(T);
        }

        public async Task<bool> DeleteAsync(string deleteApi)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(deleteApi);
            return response.IsSuccessStatusCode;
        }
    }
}
