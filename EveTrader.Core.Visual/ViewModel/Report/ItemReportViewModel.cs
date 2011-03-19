using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.View;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Services;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    public class ItemReportViewModel : TransactionReportViewModelBase, IReportPage
    {
        [ImportingConstructor]
        public ItemReportViewModel([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm,
            [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] IBasicReportView view,
            IPriceSourceSelector sel,
            ISettingsProvider provider)
            : base(tm, view, sel, provider)
        {
        }

        public override string Name
        {
            get { return "Items"; }
        }

        public int Index
        {
            get { return 0; }
        }

        protected override string Selector(Transactions t)
        {
            return t.TypeName;
        }

        #region IReportPage Members


        public void Cancel(object sender, System.EventArgs e)
        {
            cts.Cancel();
        }

        #endregion
    }
}
