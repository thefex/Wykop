using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Data;

namespace Wykop.ApiProvider.Common.ValueConverters
{
    public class WykopImageUriSizeChangerValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var imageUri = (Uri) value;
            string regexPatternToReplace = @",w\d*h\d*";
            string replacementString = String.Empty;

            if (RequestedWidth > 0 && RequestedHeight > 0)
                replacementString = ",w" + RequestedWidth + "h" + RequestedHeight;

            string fullSizeImageUri = Regex.Replace(imageUri.OriginalString, regexPatternToReplace, replacementString);
            return new Uri(fullSizeImageUri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public int RequestedWidth { get; set; }
        public int RequestedHeight { get; set; }
    }
}