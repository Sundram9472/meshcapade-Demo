using mshdemo3.Modal;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace mshdemo3.Services
{
    public class CommonAvtarService
    {
        private readonly HttpClient _httpClient;

        public CommonAvtarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AvatarMeasurements> RetrieveAvatarMeasurements(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"avatars/{assetId}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AvatarMeasurements>();
            return result;
        }
    }
}
