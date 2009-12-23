using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Main.Dashboard
{
    public class DashboardSettings
    {
        public int DaysToShowInSalesAmount { get; set; }

        public DashboardSettings()
        {
            this.DaysToShowInSalesAmount = 7;
        }
    }
}
