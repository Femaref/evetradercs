using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.Visual.ViewModel.Display
{
    [DebuggerDisplay("Name: {Name} Balance: {Balance}")]
    public class DisplayWallets
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
