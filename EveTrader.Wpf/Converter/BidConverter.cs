using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace EveTrader.Wpf.Converter
{
    public class BidConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? input = (value as bool?);
            if (input != null)
            {
                return input.Value ? "Buy" : "Sell";
            }
            throw new ArgumentException("Conversion not supported");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = (value as string);

            if (input == "Buy")
                return true;
            else if (input == "Sell")
                return false;
            else
                throw new ArgumentException("Conversion not supported");
        }

        #endregion
    }
}
