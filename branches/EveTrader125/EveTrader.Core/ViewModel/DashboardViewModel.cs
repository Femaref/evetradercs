using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class DashboardViewModel : ViewModel<IDashboardView>
    {
        private TraderModel iModel;

        [ImportingConstructor]
        public DashboardViewModel(IDashboardView view, TraderModel tm) : base(view)
        {
            iModel = tm;
        }
    }
}
