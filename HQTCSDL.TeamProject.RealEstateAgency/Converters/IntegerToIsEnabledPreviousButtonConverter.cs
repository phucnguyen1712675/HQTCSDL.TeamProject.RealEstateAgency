using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HQTCSDL.TeamProject.RealEstateAgency.Converters
{
    public class IntegerToIsEnabledPreviousButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue || value == null)
            {
                return value;
            }
            var selectedIndex = (int)value;
            return selectedIndex != 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
