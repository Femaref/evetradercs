using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using System.Reflection;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.ViewModel.Display;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class ReportViewModel : ViewModel<IReportView>
    {
        private readonly TraderModel iModel;
        private readonly ISettingsProvider iSettings;

        public DateTime StartDate
        {
            get
            {
                return iSettings.ReportStartDate;
            }
            set
            {
                iSettings.ReportStartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get
            {
                return iSettings.ReportEndDate;
            }
            set
            {
                iSettings.ReportEndDate = value;
                RaisePropertyChanged("EndDate");

            }
        }
        public bool ApplyDateFilter
        {
            get
            {
                return iSettings.ReportApplyDateFilter;
            }
            set
            {
                iSettings.ReportApplyDateFilter = value;
                RaisePropertyChanged("ApplyDateFilter");
            }
        }


        public SmartObservableCollection<Selectable<Entities>> Entities {get;set;}

        [ImportingConstructor]
        public ReportViewModel(IReportView view, TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;

            Entities = new SmartObservableCollection<Selectable<Entities>>(ViewCore.BeginInvoke);
        }

        public void Refresh()
        {

        }
    }
}
