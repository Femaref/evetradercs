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
    public class StationReportViewModel : ReportPageViewModelBase<IBasicReportView, Transactions>, IReportPage
    {
        public SmartObservableCollection<DisplayReport> Report { get; private set; }
                
        [ImportingConstructor]
        public StationReportViewModel([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm,
           [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] IBasicReportView view, 
            IPriceSourceSelector sel,
            ISettingsProvider provider)
            : base(tm, view, sel, provider)
        {
            this.Report = new SmartObservableCollection<DisplayReport>(view.BeginInvoke);
        }

        private bool Filter(Transactions trans)
        {
            return Filter(trans, t => t.DateTime);
        }

        protected override void InnerRefresh(IEnumerable<Entities> data)
        {
            lock (locker)
            {
                var currentItem = new List<IEnumerable<DisplayReport>>();
                Report.Clear();

                foreach (Entities e in data)
                {
                    var filteredTransactions = e.Wallets.SelectMany(w => w.Transactions).Where(wt => wt.TransactionType == (long)TransactionType.Sell).Where(Filter);

                    var itemData = this.GroupedTransactions(filteredTransactions, t => t.StationName).ToList();

                    currentItem.Add(itemData);


                    /*            IEnumerable<ReportChartItem> reportData =
                    from wt in filteredWalletTransactions
                    group wt by wt.TypeName into g
                    select new ReportChartItem
                    {
                        Label = string.Format(
                            "{0} x{1}", 
                            g.Key, 
                            g.Sum(gi => gi.Quantity)),
                        GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                        PureProfit = Math.Round(g.Sum(gi => ((gi.Price  - gi.SalesTax - (this.iActivateTransactionLimit ? Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID, this.iTransactionTimeLimit) : Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID))) * gi.Quantity) / 1000000), 2),
                        SalesTax = Math.Round(g.Sum(gi => gi.SalesTax * gi.Quantity / 1000000), 2)
                    };*/
                }

                Report.AddRange(this.Combine(currentItem).OrderBy(d => d.PureProfit));
            }
        }

        public override string Name
        {
            get { return "Station"; }
        }


        public int Index
        {
            get { return 2; }
        }
    }
}
