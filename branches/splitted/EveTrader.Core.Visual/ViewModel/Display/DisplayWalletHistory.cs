using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model.Trader;
using System.Diagnostics;

namespace EveTrader.Core.ViewModel.Display
{
    [DebuggerDisplay("Name: {Name}")]
    public class DisplayWalletHistory
    {
        public string Name { get; set; }
        public IEnumerable<DisplaySingleHistory> Histories { get; set; }
    }
}
