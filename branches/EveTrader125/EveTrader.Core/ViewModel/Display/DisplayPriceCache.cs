using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.ViewModel.Display
{
    public class DisplayPriceCache
    {
        public long TypeID { get; set; }
        public string TypeName { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
