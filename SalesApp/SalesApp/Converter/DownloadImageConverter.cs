namespace SalesApp.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class DownloadImageConverter : BindableObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromUri(new Uri((String)value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
