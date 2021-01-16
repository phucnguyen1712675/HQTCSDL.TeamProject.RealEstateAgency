using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HQTCSDL.TeamProject.RealEstateAgency.Converters
{
    public class BooleanToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue || value == null)
            {
                return value;
            }
            var sex = (bool)value;
            return sex ? "Nam" : "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
