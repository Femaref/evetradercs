using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.ViewModel;

namespace EveTrader.Core.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly MainWindowViewModel iMainView;
        private readonly TransactionsViewModel iTransactionsView;

        public TransactionsController(MainWindowViewModel mainView, TransactionsViewModel transactionsView)
        {
            iMainView = mainView;
            iTransactionsView = transactionsView;

            iMainView.TransactionsView = iTransactionsView.View;
        }
    }
}
