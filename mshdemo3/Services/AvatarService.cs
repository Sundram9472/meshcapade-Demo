using Microsoft.AspNetCore.Components.Web;
using mshdemo3.Modal;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using static System.Net.WebRequestMethods;

namespace mshdemo3.Services
{
    public class AvatarService
    {
        private readonly HttpClient _httpClient;
        public AvatarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> InitiateAvatarCreation(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync("avatars/create/from-images", null);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
            return result.Data.Id.ToString();
        }

        public async Task<string> RequestImageUploads(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync($"avatars/{assetId}/images", null);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var uploadResponse = System.Text.Json.JsonSerializer.Deserialize<UploadResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var result = uploadResponse.data.attributes.url.path;
            return result.ToString();
        }

        public async Task<bool> UploadImageToS3(string uploadUrl, Stream imageStream)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, uploadUrl);
            using (var content = new StreamContent(imageStream))
            {
                request.Content = content;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task StartFittingProcess(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync($"avatars/{assetId}/fit-to-images", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<AvatarMeasurements> RetrieveAvatarMeasurements(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"avatars/{assetId}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AvatarMeasurements>();
            return result;
        }

        public async Task<AvatarExport> ExportAvatar(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var requestBody = new
            {
                format = "OBJ",
                pose = "a"
            };
            var response = await _httpClient.PostAsJsonAsync($"avatars/{assetId}/export", requestBody);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AvatarExport>();
            return result;
        }

        public async Task<AvatarMeasurements> DownloadAvatar(string baseUrl, string assetId)
        {

            try
            {
                var response = await _httpClient.GetAsync(baseUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                // Process the content as needed
                Console.WriteLine(content);
            }
            catch (HttpRequestException e)
            {
                // Handle error
                Console.WriteLine($"Request error: {e.Message}");
            }
            AvatarMeasurements hh = new AvatarMeasurements();
            return hh;
        }

        private string CreateUrlWithQueryParams(string baseUrl, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(baseUrl);
            var query = new StringBuilder();

            foreach (var param in queryParams)
            {
                if (query.Length > 0)
                {
                    query.Append("&");
                }
                query.Append($"{param.Key}={param.Value}");
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }


    }

    public class ApiResponse
    {
        public ApiData Data { get; set; }
    }
    public class ApiData
    {
        public string Id { get; set; }
    }
}
