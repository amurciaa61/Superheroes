using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Superheroes
{
    class ConvertidorBackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Brushes.IndianRed;
                else
                    return Brushes.PaleGreen;
            }else
                return Brushes.PaleGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
