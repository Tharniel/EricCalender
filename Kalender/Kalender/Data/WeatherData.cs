using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kalender.Data
{
    internal class WeatherData
    {
        public static async Task<List<Models.WeatherApi>> GetWeather(string uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "0SdiJM+HXPbdpg973bh43w==ZTSJKQf13WtqqxiM");

            List<Models.WeatherApi> weather = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<List<Models.WeatherApi>>(responseString);
            }
            return weather;
        }
    }
}
