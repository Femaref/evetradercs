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
    public class TransactionsViewModel : ViewModel<ITransactionsView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        [ImportingConstructor]
        public TransactionsViewModel(ITransactionsView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm)
            : base(view)
        {
            iModel = tm;
        }

        public void Refresh()
        {

        }

        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
