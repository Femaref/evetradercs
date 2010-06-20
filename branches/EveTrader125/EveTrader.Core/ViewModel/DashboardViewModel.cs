using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using EveTrader.Core.ClassExtenders;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class DashboardViewModel : ViewModel<IDashboardView>
    {
        private TraderModel iModel;

        public ICommand FilterWeekCommand { get; private set; }
        public ICommand FilterTwoWeeksCommand { get; private set; }
        public ICommand FilterMonthCommand { get; private set; }
        public ICommand FilterAllTimeCommand { get; private set; }

        [ImportingConstructor]
        public DashboardViewModel(IDashboardView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            DailyInfo = new ObservableCollection<DisplayDashboard>();
            CurrentWallets = new ObservableCollection<string>();
            Investment = new ObservableCollection<DisplayDetail>();

            CurrentWallets.CollectionChanged += view.ChartCollectionChanged;
            view.DetailsRequested += new EventHandler<DetailsRequestedEventArgs>(view_DetailsRequested);

            FilterWeekCommand = new DelegateCommand(() => Filter(7));
            FilterTwoWeeksCommand = new DelegateCommand(() => Filter(14));
            FilterMonthCommand = new DelegateCommand(() => Filter(30));
            FilterAllTimeCommand = new DelegateCommand(() => Filter(-1));
            RefreshWallets();
            Filter(7);
        }

        void view_DetailsRequested(object sender, DetailsRequestedEventArgs e)
        {
            Investment.Clear();

            if (e.BindingKey.Contains("Investment"))
            {
                foreach (var grouping in iModel.Transactions.Where(s => s.Date == e.Key && s.TransactionType == (long)TransactionType.Buy).GroupBy(s => s.Wallet))
                {
                    foreach (var subGroup in grouping.GroupBy(s => s.TypeName))
                    {
                        Investment.Add(new DisplayDetail() { TypeName = string.Format("{0}x {1}", subGroup.Sum(t => t.Quantity), subGroup.Key), Value = subGroup.Sum(t => t.Quantity * t.Price) });

                        //Details.Add(string.Format("{0}: {1} {2}x{3} for a total of {4}", grouping.Key.Name, TransactionType.Buy.StringValue(), , subGroup.Key, subGroup.Sum(t => t.Quantity * t.Price).ToString("n")));
                    }


                }
                return;
            }

            //Details.Clear();
            //if (e.BindingKey.Contains("Investment"))
            //{
            //    foreach (var grouping in iModel.Transactions.Where(s => s.Date.Year == e.Key.Year && s.Date.Month == e.Key.Month && s.Date.Day == e.Key.Day && s.TransactionType == (long)TransactionType.Buy).GroupBy(s => s.Wallet))
            //    {
            //        foreach (var subGroup in grouping.GroupBy(s => s.TypeName))
            //        {

            //            Details.Add(string.Format("{0}: {1} {2}x{3} for a total of {4}", grouping.Key.Name, TransactionType.Buy.StringValue(), subGroup.Sum(t => t.Quantity), subGroup.Key, subGroup.Sum(t => t.Quantity * t.Price).ToString("n")));
            //        }


            //    }
            //    return;
            //}
            //foreach (var t in iModel.Transactions.Where(s => s.Date.Year == e.Key.Year && s.Date.Month == e.Key.Month && s.Date.Day == e.Key.Day))
            //{
            //    Details.Add(string.Format("{0}: {1} {2}x{3} for {4} each", t.Wallet.Name, ((TransactionType)t.TransactionType).StringValue(), t.Quantity, t.TypeName, t.Price.ToString("n")));
            //}
        }

        private void Filter(int days)
        {
            if (days == -1)
                iDateBefore = DateTime.MinValue;
            else
                iDateBefore = DateTime.UtcNow.AddDays(-days);

            Refresh();
        }

        public ObservableCollection<DisplayDashboard> DailyInfo { get; private set; }
        public ObservableCollection<string> CurrentWallets { get; private set; }
        public ObservableCollection<DisplayDetail> Investment { get; private set; }

        private int iWorkingCount = 0;
        public int WorkingCount
        {
            get { return iWorkingCount; }
            set
            {
                iWorkingCount = value;
                RaisePropertyChanged("WorkingCount");
            }
        }

        private int iCurrentIndex = 0;
        public int CurrentIndex
        {
            get { return iCurrentIndex; }
            set
            {
                iCurrentIndex = value;
                RaisePropertyChanged("CurrentIndex");
            }
        }

        private bool iWorking = false;
        public bool Working
        {
            get { return iWorking; }
            set
            {
                iWorking = value;
                RaisePropertyChanged("Working");
            }
        }

        private DateTime iDateBefore = DateTime.MinValue;
        

        public void RefreshWallets()
        {
            CurrentWallets.Clear();

            foreach (Wallets w in iModel.Wallets)
            {
                CurrentWallets.Add(w.Name);
            }
        }


        public void Refresh()
        {
            DailyInfo.Clear();
            //TODO: Datageneration

            

            var investment = (from w in iModel.Transactions
                              where w.Date > iDateBefore
                              group w by w.Date into grouped
                              orderby grouped.Key
                              select grouped);

            Working = true;
            WorkingCount = investment.Count();
            CurrentIndex = 0;

            List<DisplayDashboard> transformedInvestment = new List<DisplayDashboard>();

            Thread workerThread = new Thread(() =>
                {
                    List<DisplayDashboard> cache = new List<DisplayDashboard>();
                    foreach (var i in investment)
                    {
                        DisplayDashboard dd = new DisplayDashboard()
                        {
                            Key = i.Key,
                            Profit = 0m,
                            Investment = 0m,
                            Sales = new Dictionary<string, decimal>()
                        };
                        foreach (string s in CurrentWallets)
                        {
                            dd.Sales.Add(s, 0m);
                        }

                        dd.Investment = i.Where(t => t.TransactionType == (long)TransactionType.Buy).Sum(t => t.Price * t.Quantity);
                        dd.Profit = i.Where(t => t.TransactionType == (long)TransactionType.Sell).GroupBy(g => g.Date).Select(g => g.Sum(gt => Math.Round(gt.Price - iModel.Transactions.AverageBuyPrice(gt.TypeID) * gt.Quantity, 2))).FirstOrDefault();

                        var entityGroup = (from g in i
                                           where g.TransactionType == (long)TransactionType.Sell
                                           group g by g.Wallet into grouped
                                           select grouped);

                        foreach (var groupedEntity in entityGroup)
                        {
                            dd.Sales[groupedEntity.Key.Name] = groupedEntity.Sum(ge => ge.Price * ge.Quantity);
                        }

                        cache.Add(dd);
                        CurrentIndex++;
                    }
                    cache.ForEach(dd => this.ViewCore.BeginInvoke(new Action(() => { DailyInfo.Add(dd); })));
                    Working = false;
                });

            workerThread.Start();

            
        }
    }
}

