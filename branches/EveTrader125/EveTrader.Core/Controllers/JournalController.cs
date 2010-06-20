using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    public class JournalController : Controller
    {
                private readonly MainWindowViewModel iMainView;
        private readonly JournalViewModel iJournalView;

        public JournalController(MainWindowViewModel mainView, JournalViewModel journalView)
        {
            iMainView = mainView;
            iJournalView = journalView;

            iMainView.JournalView = iJournalView.View;
        }
    }
}
