using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Reflection;

namespace EveTrader.Wpf.Selectors
{
    public class DashboardSelector : DataTemplateSelector
    {
        public DataTemplate ProfitTemplate { get; set; }
        public DataTemplate InvestmentTemplate { get; set; }
        public DataTemplate SalesTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            PropertyInfo pi = (item as PropertyInfo);
            if (pi == null)
                throw new ArgumentNullException("item");

            if (pi.Name == "Profit")
                return ProfitTemplate;
            if (pi.Name == "Investment")
                return InvestmentTemplate;
            if (pi.Name == "Sales")
                return SalesTemplate;

            return null;
        }
    }
}
