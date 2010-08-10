using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.ViewModel.Display
{
    [DebuggerDisplay("Date: {Date}, Balance: {Balance}")]
    public class DisplaySingleHistory
    {
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
    }
}
