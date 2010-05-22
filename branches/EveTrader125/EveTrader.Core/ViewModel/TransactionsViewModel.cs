using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class TransactionsViewModel : ViewModel<ITransactionsView>
    {
        private readonly TraderModel iModel;

        [ImportingConstructor]
        public TransactionsViewModel(ITransactionsView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
        }
    }
}
