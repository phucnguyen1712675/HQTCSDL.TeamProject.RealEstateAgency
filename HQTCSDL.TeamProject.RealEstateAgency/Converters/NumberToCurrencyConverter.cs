using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace HQTCSDL.TeamProject.RealEstateAgency.Converters
{
    public class NumberToCurrencyConverter : IValueConverter
    {
        private readonly List<string> badWordList;

        public NumberToCurrencyConverter()
        {
            this.badWordList = new List<string>()
            {
                " đồng",
                "."
            };
        }

        private static string GetNumbers(string input)
            => new string(input.Where(c => char.IsDigit(c)).ToArray());

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue || value == null)
            {
                return value;
            }
            var money = (decimal)value;
            if (money < 100000)
            {
                money *= 1000;
            }
            return money != 0 ? money.ToString("#,###", CultureInfo.GetCultureInfo("vi-VN").NumberFormat) + badWordList[0] : money.ToString() + badWordList[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string money = (string)value;

            foreach (string badWord in badWordList)
            {
                money = money.Replace(badWord, string.Empty);
            }

            if (!money.All(char.IsDigit) && !string.IsNullOrEmpty(money))
            {
                money = GetNumbers(money);
                return double.Parse(money, CultureInfo.InvariantCulture);
            }

            return money;
        }
    }
}
