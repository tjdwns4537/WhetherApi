using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAPP.Classes;

namespace WeatherAPP.ViewModel.Command
{
    class RefreshCommand : ICommand
    {
        string str;
        public WeatherData WeatherDataToShow = new WeatherData();

        public string InputText { get; set; }
        public WeatherVM VM { get; set; }

        public RefreshCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("VM.City cnt: " + VM.Cities.Count);
            Console.WriteLine("InputText: " + InputText);
            if (string.IsNullOrEmpty(InputText))
            {
                var weather = WeatherApi.GetWeatherData(str);
                VM.WeatherDataToShow.Name = weather.Name;
                VM.WeatherDataToShow.Main = weather.Main;
                VM.WeatherDataToShow.Wind = weather.Wind;
            }
            if ((!VM.Cities.Contains(InputText)) && (!string.IsNullOrEmpty(InputText)))
            {
                str = InputText;
                VM.Cities.Add(InputText);
            }
            if (VM.Cities.Contains(InputText))
            {
                str = InputText;
                var weather = WeatherApi.GetWeatherData(InputText);
                VM.WeatherDataToShow.Name = weather.Name;
                VM.WeatherDataToShow.Main = weather.Main;
                VM.WeatherDataToShow.Wind = weather.Wind;
            }
        }
    }
}
