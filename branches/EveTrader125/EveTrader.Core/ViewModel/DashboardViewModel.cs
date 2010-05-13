using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    public class DashboardViewModel : ViewModel<IDashboardView>
    {
        private TraderModel iModel;

        public DashboardViewModel(IDashboardView view, TraderModel tm) : base(view)
        {
            iModel = tm;
        }
    }
}
