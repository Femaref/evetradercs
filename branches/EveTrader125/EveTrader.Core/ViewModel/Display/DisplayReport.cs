using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.ViewModel.Display
{
    public class DisplayReport
    {
        public string Key { get; set; }
        public decimal GrossSales { get; set; }
        public decimal PureProfit { get; set; }
        public decimal SalesTax { get; set; }
    }
}
