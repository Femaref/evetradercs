using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel.Display
{
    public class DisplayWalletHistory
    {
        public string Name { get; set; }
        public IEnumerable<WalletHistories> Histories { get; set; }
    }
}
