using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    class Core
    {
        public static async Task<dynamic> GetWeather(string zipCode)
        {
            string key = "259130bbae64e04cc392bed27b09cced";
            string queryString = $"http://api.openweathermap.org/data/2.5/weather?zip={zipCode},us&appid={key}&units=imperial";
            //string queryString = "https://samples.openweathermap.org/data/2.5/weather?zip=94040,us&appid=b6907d289e10d714a6e88b30761fae22";
            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results != null)
            {
                OpenWeather openWeather = new OpenWeather();
                openWeather = JsonConvert.DeserializeObject<OpenWeather>(results);
                WeatherData weatherData = new WeatherData();
                weatherData.Title = openWeather.name;
                weatherData.Temperature = $"{openWeather.main.temp} F";
                weatherData.Wind = $"{openWeather.wind.speed} MPH";
                weatherData.Humidity = $"{openWeather.main.humidity}%";
                weatherData.Visibility = $"{openWeather.visibility}";

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds(openWeather.sys.sunrise);
                DateTime sunset = time.AddSeconds(openWeather.sys.sunset);

                weatherData.Sunrise = $"{sunrise} UTC";
                weatherData.Sunset = $"{sunset} UTC";

                return weatherData;
            }
            else
            {
                return null;
            }

        }
    }
}
