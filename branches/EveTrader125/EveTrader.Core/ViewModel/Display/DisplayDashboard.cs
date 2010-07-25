using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace EveTrader.Core.ViewModel.Display
{
    public class DisplayDashboard
    {
        public DateTime Key { get; set; }
        public decimal Profit { get; set; }
        public decimal Investment { get; set; }
        public Dictionary<string,decimal> Sales { get; set; }
    }
}
