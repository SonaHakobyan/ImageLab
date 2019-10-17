using ImageLab.Enumerations;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ImageLab.Converters
{
    public class EntryTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string iconPath = string.Empty;
            if (value is EntryType type)
            {
                iconPath = (type is EntryType.Directory) ? @"..\Resources\folderIcon.jpg" : @"..\Resources\imageIcon.jpg";
            }

            return iconPath;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
