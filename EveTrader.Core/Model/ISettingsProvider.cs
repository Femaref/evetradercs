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
        DateTime JournalStartDate { get; set; }
        DateTime JournalEndDate { get; set; }
        bool JournalApplyStartFilter { get; set; }
        bool JournalApplyEndFilter { get; set; }
        DateTime TransactionsStartDate { get; set; }
        DateTime TransactionsEndDate { get; set; }
        bool TransactionsApplyStartFilter { get; set; }
        bool TransactionsApplyEndFilter { get; set; }
        DateTime ReportStartDate { get; set; }
        DateTime ReportEndDate { get; set; }
        bool ReportApplyStartFilter { get; set; }
        bool ReportApplyEndFilter { get; set; }
    }
}
