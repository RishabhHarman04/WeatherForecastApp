using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class SettingForm : Form
    {
        public WeatherSettings Settings { get; set; }
        
       public SettingForm()
        {
            InitializeComponent();
            Settings = new WeatherSettings();
        }
        public class WeatherSettings
        {
            public List<string> Cities { get; set; }
            public string RefreshTime { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkedListBoxCities.CheckedItems.Count == 0)
            {
                MessageBox.Show(MyStrings.Message);
                return;
            }
            SettingFormMethods.SaveSettingsAndShowWeatherDataForm(Settings, checkedListBoxCities, numericUpDownTime);

            this.Close();

        }                                         
         private void SettingForm_Load_1(object sender, EventArgs e)
        {
            SettingFormMethods.InitializeCitiesListBox(checkedListBoxCities);
            SettingFormMethods.InitializeRefreshTimeNumericUpDown(numericUpDownTime);
        }
    }

}

