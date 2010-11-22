using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.Visual.ViewModel.Display
{
    [DebuggerDisplay("Key: {Key}, Quantity: {Quantity}, GrossSales: {GrossSales}, PureProfit: {PureProfit}")]
    public class DisplayReport
    {
        public string Key { get; set; }
        public long Quantity { get; set; }
        public decimal GrossSales { get; set; }
        public decimal PureProfit { get; set; }
        public decimal SalesTax { get; set; }
    }
}
