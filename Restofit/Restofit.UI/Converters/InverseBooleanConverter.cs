using System;
using System.Globalization;
using Xamarin.Forms;

namespace Restofit.UI.Converters
{
    public class InverseBooleanConverter: IValueConverter
    {
        public static InverseBooleanConverter Instance = new InverseBooleanConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

    }
}