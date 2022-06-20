using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Classes;

namespace WeatherAPP.ViewModel
{
    class WeatherApi
    {
        public const string API_KEY = "894364bc711881e02cce7b03693639e7";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";
        public static WeatherData GetWeatherData(string cityName)
        {
            WeatherData result = new WeatherData();
            string url = string.Format(BASE_URL, cityName, API_KEY);
            HttpClient client = new HttpClient();

            var response = client.GetAsync(url);
            string resultString = response.Result.Content.ReadAsStringAsync().Result;
            client.Dispose();

            result = JsonConvert.DeserializeObject<WeatherData>(resultString);


            return result;
        }
    }
}
