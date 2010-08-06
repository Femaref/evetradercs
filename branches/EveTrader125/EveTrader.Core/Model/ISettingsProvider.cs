using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Model
{
    public interface ISettingsProvider
    {
        bool AutoUpdate { get; set; }
        bool HideExpired { get; set; }
        TimeSpan JournalTimeframe { get; set; }
        TimeSpan TransactionTimeframe { get; set; }
        DateTime ReportStartDate { get; set; }
        DateTime ReportEndDate { get; set; }
        bool ReportApplyStartFilter { get; set; }
        bool ReportApplyEndFilter { get; set; }
    }
}
