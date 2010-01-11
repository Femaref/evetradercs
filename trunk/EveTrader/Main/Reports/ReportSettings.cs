using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Main.Reports
{
    public class ReportSettings
    {
        public int ItemsDisplayed { get; set; }
        public bool AutomaticApply { get; set; }
        public ReportTimeSetting GraphTimeSpan { get; set; }

        public ReportSettings()
        {
            this.ItemsDisplayed = 15;
            this.AutomaticApply = false;
            this.GraphTimeSpan = ReportTimeSetting.Week;
        }
    }
}
