using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Visual.ViewModel;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class SettingsController : Controller
    {
        [ImportingConstructor]
        public SettingsController(MainWindowViewModel mainView, SettingsViewModel view)
        {
            mainView.SettingsView = view.View;
            view.Closed += (obj, e) => mainView.SettingsShown = false;
        }
    }
}
