using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;

namespace EveTrader.Core
{
    [ValueConversion(typeof(long), typeof(string))]
    [Export(typeof(RefTypesConverter))]
    public class RefTypesConverter : IValueConverter
    {
        private readonly TraderModel iModel;

        public RefTypesConverter([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm)
        {
            iModel = tm;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            long? val = (value as long?);
            if (!val.HasValue)
                return value;

            return iModel.RefTypes.Single(r => r.ID == val.GetValueOrDefault()).Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = (value as string);
            if (val == null)
                return value;

            return iModel.RefTypes.Single(r => r.Name == val).ID;
        }
    }
}
