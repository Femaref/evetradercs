using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class ApplicationLogController : Controller
    {
                MainWindowViewModel iMainView;
        ApplicationLogViewModel iApplicationLogView;

        [ImportingConstructor]
        public ApplicationLogController(MainWindowViewModel mainView, ApplicationLogViewModel applicationLogView)
        {
            iMainView = mainView;
            iApplicationLogView= applicationLogView;
        }

        public void Initialize()
        {
            iMainView.ApplicationLogView = iApplicationLogView.View;
        }
    }
}
