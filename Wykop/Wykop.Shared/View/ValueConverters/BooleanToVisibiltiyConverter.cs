using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Wykop.View.ValueConverters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var currentVisibility = (Visibility) value;
            return currentVisibility == Visibility.Visible;
        }
    }
}