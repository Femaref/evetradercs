using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;
using System.ComponentModel.Composition;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ReportController : Controller
    {
        MainWindowViewModel iMainView;
        ReportViewModel iReportView;

        [ImportingConstructor]
        public ReportController(MainWindowViewModel mainView, ReportViewModel reportView)
        {
            iMainView = mainView;
            iReportView = reportView;
            iMainView.ReportView = iReportView.View;
        }

        public void Refresh()
        {
            iReportView.Refresh();
        }
    }
}
