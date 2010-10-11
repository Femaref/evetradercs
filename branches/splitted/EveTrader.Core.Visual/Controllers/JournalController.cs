using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;
using System.ComponentModel.Composition;
using EveTrader.Core.Services;

namespace EveTrader.Core.Controllers
{
    [Export]
    public class JournalController : Controller
    {
        private readonly MainWindowViewModel iMainView;
        private readonly JournalViewModel iJournalView;

        [ImportingConstructor]
        public JournalController(MainWindowViewModel mainView, JournalViewModel journalView, IUpdateService updater)
        {
            iMainView = mainView;
            iJournalView = journalView;

            iMainView.JournalView = iJournalView.View;

            updater.Updated += iJournalView.DataIncoming;
        }
    }
}
