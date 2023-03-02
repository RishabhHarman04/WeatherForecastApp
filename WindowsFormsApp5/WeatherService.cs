using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp5.WeatherData;
using static WindowsFormsApp5.SettingForm;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public class WeatherService
    {
        private HttpClient httpClient = new HttpClient();
        private string apiKey = MyStrings.APIKEY;
        private WeatherSettings settings;

        public  WeatherService(WeatherSettings settings)
        {
            this.settings = settings;
        }

        public async Task<string> GetWeatherData(string city)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"An error occurred while getting the weather data for {city}: {ex.Message}");
                return null;
            }
        }

        public async Task UpdateLabels(Label label1, Label lblHumidity, Label lblAtmosphere, Label lblTemperature, int panelIndex)
        {
            try
            {
                var city = settings.Cities.ElementAt(panelIndex);
                Console.WriteLine(panelIndex.ToString());
                var weatherData = await GetWeatherData(city);
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(weatherData);
                double temperature = json.main.temp;
                double humidity = json.main.humidity;
                double pressure = json.main.pressure;
                label1.Text = city;
                lblHumidity.Text = $"Humidity: {humidity}%";
                lblAtmosphere.Text = $"Atmosphere: {pressure} Pa";
                lblTemperature.Text = $"Temperature: {temperature}°C";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
