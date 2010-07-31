using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.View;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model;
using System.Reflection;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.ViewModel.Display;
using EveTrader.Core.ClassExtenders;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class ReportViewModel : ViewModel<IReportView>
    {
        private readonly TraderModel iModel;
        private readonly ISettingsProvider iSettings;
        private bool iUpdating = false;

        public DateTime StartDate
        {
            get
            {
                return iSettings.ReportStartDate;
            }
            set
            {
                iSettings.ReportStartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get
            {
                return iSettings.ReportEndDate;
            }
            set
            {
                iSettings.ReportEndDate = value;
                RaisePropertyChanged("EndDate");

            }
        }
        public bool ApplyDateFilter
        {
            get
            {
                return iSettings.ReportApplyDateFilter;
            }
            set
            {
                iSettings.ReportApplyDateFilter = value;
                RaisePropertyChanged("ApplyDateFilter");
            }
        }

        public bool Updating
        {
            get
            {
                return iUpdating;
            }
            set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }


        public SmartObservableCollection<Selectable<Entities>> Entities { get; set; }
        public SmartObservableCollection<DisplayReport> StationReport { get; set; }
        public SmartObservableCollection<DisplayReport> ItemReport { get; set; }
        public SmartObservableCollection<DisplayReport> BuyerReport { get; set; }

        [ImportingConstructor]
        public ReportViewModel(IReportView view, TraderModel tm, ISettingsProvider settings)
            : base(view)
        {
            iModel = tm;
            iSettings = settings;

            Entities = new SmartObservableCollection<Selectable<Entities>>(ViewCore.BeginInvoke);

            StationReport = new SmartObservableCollection<DisplayReport>(ViewCore.BeginInvoke);
            ItemReport = new SmartObservableCollection<DisplayReport>(ViewCore.BeginInvoke);
            BuyerReport = new SmartObservableCollection<DisplayReport>(ViewCore.BeginInvoke);
        }

        private IEnumerable<DisplayReport> GroupedTransactions(IEnumerable<Transactions> input, Func<Transactions, string> groupBy)
        {
            return input
                    .GroupBy(groupBy)
                    .Select(g => new DisplayReport()
                    {
                        Key = string.Format("{0} x{1}", g.Key, g.Sum(gi => gi.Quantity)),
                        GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                        //PureProfit = Math.Round(g.Sum(gi => ((gi.Price  - gi.SalesTax - (this.iActivateTransactionLimit ? Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID, this.iTransactionTimeLimit) : Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID))) * gi.Quantity) / 1000000), 2),
                        PureProfit = Math.Round(g.Sum(gi => ((gi.Price - iModel.Transactions.AverageBuyPrice(gi.TypeID)) * gi.Quantity) / 1000000), 2),
                        //SalesTax = Math.Round(g.Sum(gi => gi.SalesTax * gi.Quantity / 1000000), 2)
                        SalesTax = 0m
                    });
        }

        private IEnumerable<DisplayReport> Combine (IEnumerable<IEnumerable<DisplayReport>> input)
        {
            return input.SelectMany(d => d.GroupBy(dr => dr.Key)).Select(d => new DisplayReport()
            {
                Key = d.Key,
                GrossSales = d.Sum(dr => dr.GrossSales),
                PureProfit = d.Sum(dr => dr.PureProfit),
                SalesTax = d.Sum(dr => dr.SalesTax)
            });
        }

        public void Refresh()
        {
            Action updater = () =>
                {
                    this.Updating = true;

                    StationReport.Clear();
                    ItemReport.Clear();
                    BuyerReport.Clear();

                    List<IEnumerable<DisplayReport>> currentStation = new List<IEnumerable<DisplayReport>>();
                    List<IEnumerable<DisplayReport>> currentItem = new List<IEnumerable<DisplayReport>>();
                    List<IEnumerable<DisplayReport>> currentBuyer = new List<IEnumerable<DisplayReport>>();

                    foreach (Entities e in Entities.Where(s => s.IsSelected))
                    {
                        //filtered: wt => wt.TransactionDateTime.Date >= iFromDate && wt.TransactionType == WalletTransactionType.Sell

                        var filteredTransactions = e.Wallets.SelectMany(w => w.Transactions).Where(wt => wt.Date >= this.StartDate && wt.Date < this.EndDate && wt.TransactionType == (long)TransactionType.Sell);

                        var stationData = this.GroupedTransactions(filteredTransactions, t => t.StationName);
                        var itemData = this.GroupedTransactions(filteredTransactions, t => t.TypeName);
                        var buyerData = this.GroupedTransactions(filteredTransactions, t => t.ClientName);

                        currentStation.Add(stationData);
                        currentItem.Add(itemData);
                        currentBuyer.Add(buyerData);


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

                    StationReport.AddRange(this.Combine(currentStation));
                    ItemReport.AddRange(this.Combine(currentItem));
                    BuyerReport.AddRange(this.Combine(currentBuyer));

                    this.Updating = false;
                };

            Thread updaterThread = new Thread(new ThreadStart(updater));
            updaterThread.Start();
        }
        
    }
}
