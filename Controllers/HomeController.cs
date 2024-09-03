using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UseAPI_Weather_Basic.Molders;
using UseAPI_Weather_Basic.Services;

namespace UseAPI_Weather_Basic.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            string location = "London";

            Dictionary<string, object>? responseDictionary = await _weatherService.GetWeatherLocation(location);
            
           

            string StringLocation = Convert.ToString(responseDictionary["location"]);
            string StringCurrent = Convert.ToString(responseDictionary["current"]);

            var jsonLocation = JsonDocument.Parse(StringLocation);
            var jsonCurrent = JsonDocument.Parse(StringCurrent);

            Location_Infor location_Infor = new Location_Infor() 
            {
                nameCity = jsonLocation.RootElement.GetProperty("name").GetString(),
                region = jsonLocation.RootElement.GetProperty("region").GetString(),
                country = jsonLocation.RootElement.GetProperty("country").GetString(),
                latitude = jsonLocation.RootElement.GetProperty("lat").GetDouble(),
                longitude = jsonLocation.RootElement.GetProperty("lon").GetDouble(),
                timeZone = jsonLocation.RootElement.GetProperty("tz_id").GetString(),
                localTime = jsonLocation.RootElement.GetProperty("localtime").GetString()
                

            };

            Weather weather = new Weather()
            {
                location_Infor = location_Infor,
                last_updated = jsonCurrent.RootElement.GetProperty("last_updated").ToString(),
                temp_c = jsonCurrent.RootElement.GetProperty("temp_c").GetDouble(),
                wind_kph = jsonCurrent.RootElement.GetProperty("wind_kph").GetDouble(),
                humidity = jsonCurrent.RootElement.GetProperty("humidity").GetInt32(),
                cloud = jsonCurrent.RootElement.GetProperty("cloud").GetInt32(),
                uv = jsonCurrent.RootElement.GetProperty("uv").GetDouble()


            };

           

            ViewBag.Weather = weather;
            
            return View();
        }

        [HttpGet]
        [Route("/{location}")]
        public async Task<IActionResult> Index([FromRoute] string location)
        {
            if(location == null)
            {
                location = "London";
            }
           

            Dictionary<string, object>? responseDictionary = await _weatherService.GetWeatherLocation(location);



            string StringLocation = Convert.ToString(responseDictionary["location"]);
            string StringCurrent = Convert.ToString(responseDictionary["current"]);

            var jsonLocation = JsonDocument.Parse(StringLocation);
            var jsonCurrent = JsonDocument.Parse(StringCurrent);

            Location_Infor location_Infor = new Location_Infor()
            {
                nameCity = jsonLocation.RootElement.GetProperty("name").GetString(),
                region = jsonLocation.RootElement.GetProperty("region").GetString(),
                country = jsonLocation.RootElement.GetProperty("country").GetString(),
                latitude = jsonLocation.RootElement.GetProperty("lat").GetDouble(),
                longitude = jsonLocation.RootElement.GetProperty("lon").GetDouble(),
                timeZone = jsonLocation.RootElement.GetProperty("tz_id").GetString(),
                localTime = jsonLocation.RootElement.GetProperty("localtime").GetString()


            };

            Weather weather = new Weather()
            {
                location_Infor = location_Infor,
                last_updated = jsonCurrent.RootElement.GetProperty("last_updated").ToString(),
                temp_c = jsonCurrent.RootElement.GetProperty("temp_c").GetDouble(),
                wind_kph = jsonCurrent.RootElement.GetProperty("wind_kph").GetDouble(),
                humidity = jsonCurrent.RootElement.GetProperty("humidity").GetInt32(),
                cloud = jsonCurrent.RootElement.GetProperty("cloud").GetInt32(),
                uv = jsonCurrent.RootElement.GetProperty("uv").GetDouble()


            };

            ViewBag.Weather = weather;

            return View();
        }
    }
}
