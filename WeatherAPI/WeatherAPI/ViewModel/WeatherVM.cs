using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Classes;
using WeatherAPP.ViewModel.Command;

namespace WeatherAPP.ViewModel
{
    class WeatherVM
    {
        string str;
        public WeatherData WeatherDataToShow { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public RefreshCommand RefreshCommand { get; set; }

        public string InputText { get; set; }

        private string selectedCity;
        public string SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; GetWheather(); }
        }

        public WeatherVM()
        {
            WeatherDataToShow = new WeatherData();
            Cities = new ObservableCollection<string>();
            RefreshCommand = new RefreshCommand(this);

            Cities.Add("London");
            Cities.Add("Paris");
            Cities.Add("Jeonju");
            Cities.Add("Seoul");
        }

        public void GetWheather()
        {
            if(SelectedCity != null)
            {
                var weather = WeatherApi.GetWeatherData(SelectedCity);
                WeatherDataToShow.Name = weather.Name;
                WeatherDataToShow.Main = weather.Main;
                WeatherDataToShow.Wind = weather.Wind;
                
            }
        }

        public void OnInsert()
        {
            if (string.IsNullOrEmpty(InputText))
            {
                var weather = WeatherApi.GetWeatherData(str);
                WeatherDataToShow.Name = weather.Name;
                WeatherDataToShow.Main = weather.Main;
                WeatherDataToShow.Wind = weather.Wind;
            }
            if ((!Cities.Contains(InputText)) && (!string.IsNullOrEmpty(InputText)) )
            {
                str = InputText;
                Cities.Add(InputText);
            }
            if (Cities.Contains(InputText))
            {
                str = InputText;
                var weather = WeatherApi.GetWeatherData(InputText);
                WeatherDataToShow.Name = weather.Name;
                WeatherDataToShow.Main = weather.Main;
                WeatherDataToShow.Wind = weather.Wind;
            }
        }
    }
}
