namespace Common.Services.Impl
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class CountryProxy : ICountryProxy
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CountryProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<T>> GetCountriesAsync<T>()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<T>>(json, _options);
        }

        public async Task<IEnumerable<T>> GetCountriesByRegionAsync<T>(string region)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/region/{region}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<T>>(json, _options);
        }

        public async Task<IEnumerable<T>> GetCountriesByNameAsync<T>(string name)
        {
            var response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(json, _options);
        }
    }
}
