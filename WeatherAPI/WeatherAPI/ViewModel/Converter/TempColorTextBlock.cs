using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WeatherAPP.ViewModel.Converter
{
    class TempColorTextBlock : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double OriginValue = (double)value;
            double KelvinValue = (double)(OriginValue - 273.15);
            if (KelvinValue > 20)
            {
                return new SolidColorBrush(Colors.Red);

            }
            if (KelvinValue < 20)
            {
                return new SolidColorBrush(Colors.Blue);

            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
