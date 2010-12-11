using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace EveTrader.Wpf.Converter
{
    class TransactionsForConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            long? input = (value as long?);
            if (input != null)
            {
                switch (input.Value)
                {
                    case 0: return "Undefined";
                    case 1: return "Personal";
                    case 2: return "Corporation";
                }
            }
            throw new ArgumentException("Conversion not supported");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = (value as string);

            if (input == "Undefined")
                return 0;
            else if (input == "Personal")
                return 1;
            else if (input == "Corporation")
                return 2;
            else
                throw new ArgumentException("Conversion not supported");
        }

        #endregion
    }
}
