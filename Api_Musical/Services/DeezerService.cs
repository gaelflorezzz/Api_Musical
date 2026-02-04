using Api_Musical.Models;
using System.Text.Json;

namespace Api_Musical.Services
{
    public class DeezerService
    {
        private readonly HttpClient _httpClient;

        public DeezerService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["Deezer:BaseUrl"]);
        }

        public async Task<List<Cancion>> GetCancion(string nombreCancion)
        {
            var url = $"search/track?q={Uri.EscapeDataString(nombreCancion)}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<DeezerResponse>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return data?.Data ?? new List<Cancion>();
        }

        public async Task<List<Cancion>> GetTopGlobales()
        {
            var url = "chart";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<DeezerResponse>(json, options);

            return data.tracks.Data ?? new List<Cancion>();
        }
    }
}
