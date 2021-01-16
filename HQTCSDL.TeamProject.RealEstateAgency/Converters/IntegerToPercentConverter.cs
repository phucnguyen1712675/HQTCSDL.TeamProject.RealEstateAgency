﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HQTCSDL.TeamProject.RealEstateAgency.Converters
{
    public class IntegerToPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue || value == null)
            {
                return value;
            }
            int number = (int)value;
            return $"{number}%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
