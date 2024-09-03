
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using UseAPI_Weather_Basic.ServiceContracts;

namespace UseAPI_Weather_Basic.Services
{
    public class WeatherService : IWeather
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>> GetWeatherLocation(string location)
        {
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?key={_configuration["WeatherToken"]}&q={location}")
                };

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();
                StreamReader streamReader = new StreamReader(stream);

                string response = streamReader.ReadToEnd();
                Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (responseDictionary == null)
                {
                    throw new InvalidOperationException("No reponse from weather api server");
                }

                if (responseDictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException("Not Found");
                }

                return responseDictionary;

            }
        }
    }
}
