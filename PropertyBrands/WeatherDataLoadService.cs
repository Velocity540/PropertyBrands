using System.Net.Http;
using System.Threading.Tasks;
using PropertyBrands.ReturnTypes;

namespace PropertyBrands
{
    public class WeatherDataLoadService : IWeatherDataLoadService
    {
        private readonly HttpClient _httpClient;
        private readonly WeatherSettings _weatherSettings;


        public WeatherDataLoadService(HttpClient client, WeatherSettings weatherSettings)
        {
            _httpClient = client;
            _weatherSettings = weatherSettings;
        }

        public async Task<Welcome> GetWeatherData(string zipCode)
        {
            var response = await _httpClient.GetAsync($"{_weatherSettings.EndPoint}?zip={zipCode},us&APPID={_weatherSettings.Key}");

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsAsync<Welcome>();

            // ToDo Handle failures?
            return stream ?? new Welcome();
        }
    }
}