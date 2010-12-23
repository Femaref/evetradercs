using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.Visual.ViewModel.Display
{
    [DebuggerDisplay("TypeName: {TypeName}, BuyPrice: {BuyPrice}, SellPrice: {SellPrice}")]
    public class DisplayPriceCache
    {
        public long TypeID { get; set; }
        public string TypeName { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
