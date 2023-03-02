using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp5.SettingForm;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using WindowsFormsApp5.Properties;

namespace WindowsFormsApp5
{
    public class SettingFormMethods
    {
        public static void InitializeCitiesListBox(CheckedListBox checkedListBoxCities)
        {
            checkedListBoxCities.Items.Add(MyStrings.City1);
            checkedListBoxCities.Items.Add(MyStrings.City2);
            checkedListBoxCities.Items.Add(MyStrings.City3);
            checkedListBoxCities.Items.Add(MyStrings.City4);
            checkedListBoxCities.Items.Add(MyStrings.City5);
            checkedListBoxCities.CheckOnClick = true;
        }

        public static void InitializeRefreshTimeNumericUpDown(NumericUpDown numericUpDownTime)
        {
            numericUpDownTime.Minimum = 5;
            numericUpDownTime.Maximum = 15;
            numericUpDownTime.Value = 5;
            numericUpDownTime.Increment = 5;
        }
       

        public static void SaveSettingsAndShowWeatherDataForm(WeatherSettings Settings, CheckedListBox checkedListBoxCities, NumericUpDown numericUpDownTime)
        {
            Settings.Cities = new List<string>();
            foreach (var item in checkedListBoxCities.CheckedItems)
            {
                Settings.Cities.Add(item.ToString());
            }
            Settings.RefreshTime = numericUpDownTime.Value.ToString();

            // Check if an instance of WeatherData already exists
            WeatherData weatherDataForm = Application.OpenForms.OfType<WeatherData>().FirstOrDefault();

            if (weatherDataForm != null)
            {
                // Show existing instance of WeatherData form
                weatherDataForm.Show();
            }
            else
            {
                // Create new instance of WeatherData form
                WeatherData weatherData = new WeatherData(Settings);
                weatherData.Show();
            }

        }
    }
}
