using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace HQTCSDL.TeamProject.RealEstateAgency.Converters
{
    public class IntegerToIsEnabledNextButtonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
            {
                return DependencyProperty.UnsetValue;
            }
            var count = (int)values[0];
            var selectedIndex = (int)values[1];
            return selectedIndex != count - 1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
