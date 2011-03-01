using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Collections.ObjectModel;
using System.ComponentModel.Composition;
using EveTrader.Core.Services;
using EveTrader.Core.Model;

namespace EveTrader.Core.ViewModel
{
    public class StationReportViewModel : TransactionReportViewModelBase, IReportPage
    {
        [ImportingConstructor]
        public StationReportViewModel(
            [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm,
            [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] IBasicReportView view,
            IPriceSourceSelector sel,
            ISettingsProvider provider)
            : base(tm, view, sel, provider)
        {
        }

        public override string Name
        {
            get { return "Station"; }
        }

        public int Index
        {
            get { return 1; }
        }

        protected override string Selector(Transactions t)
        {
            return t.StationName;
        }
    }
}
