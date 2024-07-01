using mshdemo3.Modal;
using mshdemo3.Services;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace mshdemo3.Services
{
    public class AvatarVideoService
    {
        private readonly HttpClient _httpClient;

        public AvatarVideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> InitiateAvatarCreation(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync("avatars/create/from-video", null);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                var assetId = result.Data.Id.ToString();
                return assetId;
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public async Task<string> RequestVideoUploads(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync($"avatars/{assetId}/video", null);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<UploadResponse>();
            var S3Urlpath = result.data.attributes.url.path.ToString();
            return S3Urlpath;
        }
        public async Task<bool> UploadVideoToS3(string s3Url, string filePath)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, s3Url);

            using (var content = new StreamContent(File.OpenRead(filePath)))
            {
                // Determine MIME type based on file extension
                var mimeType = GetMimeType(Path.GetExtension(filePath));
                content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);

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
                //return response.IsSuccessStatusCode;
            }
        }
        public async Task StartFittingProcess(string assetId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync($"avatars/{assetId}/fit-to-video", null);
            response.EnsureSuccessStatusCode();

        }
      
        private string GetMimeType(string fileExtension)
        {
            return fileExtension.ToLower() switch
            {
                ".mp4" => "video/mp4",
                ".avi" => "video/x-msvideo",
                ".mov" => "video/quicktime",
                ".mkv" => "video/x-matroska",
                _ => "application/octet-stream", // default MIME type
            };
        }
    }
}
