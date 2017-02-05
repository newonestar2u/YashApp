using System;
using System.Globalization;
using Xamarin.Forms;

namespace SalesApp.Converter
{
    public class ImageConverter: BindableObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return  ImageSource.FromResource((string) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
