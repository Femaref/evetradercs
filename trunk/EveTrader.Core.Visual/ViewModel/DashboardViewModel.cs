using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Visual.View;
using EveTrader.Core.Model.Trader;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using ClassExtenders;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.Services;
using System.Reflection;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class DashboardViewModel : ViewModel<IDashboardView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;

        private object iDetailLock = new object();
        private object iUpdaterLock = new object();
        private int iWorkingCount = 0;
        private int iCurrentIndex = 0;
        private bool iWorking = false;
        private bool iDetailsUpdating = false;
        private DateTime iDateBefore = DateTime.MinValue;
        private DateTime iCurrentKey = new DateTime();
        private string iCurrentBindingKey = "";
        private bool iUpdating;
        private IPriceLookup iLookup;
        private bool iOverviewHidden;
        private IPriceSourceSelector iSource;
        

        public ICommand FilterWeekCommand { get; private set; }
        public ICommand FilterTwoWeeksCommand { get; private set; }
        public ICommand FilterMonthCommand { get; private set; }
        public ICommand FilterAllTimeCommand { get; private set; }
        public ICommand OverviewHideCommand { get; private set; }

        public SmartObservableCollection<DisplayDashboard> DailyInfo { get; private set; }
        public SmartObservableCollection<KeyValuePair<PropertyInfo, IEnumerable<string>>> CurrentWallets { get; private set; }
        public SmartObservableCollection<DisplayDetail> Investment { get; private set; }
        public SmartObservableCollection<DisplayDetail> Sales { get; private set; }
        public SmartObservableCollection<DisplayDetail> Profit { get; private set; }
        public bool Updating
        {
            get
            {
                return iUpdating;
            }
            private set
            {
                iUpdating = value;
                RaisePropertyChanged("Updating");
            }
        }
        public Type CurrentType { get { return typeof(DisplayDashboard); } }

        public int WorkingCount
        {
            get { return iWorkingCount; }
            set
            {
                iWorkingCount = value;
                RaisePropertyChanged("WorkingCount");
            }
        }
        public int CurrentIndex
        {
            get { return iCurrentIndex; }
            set
            {
                iCurrentIndex = value;
                RaisePropertyChanged("CurrentIndex");
            }
        }
        public bool Working
        {
            get { return iWorking; }
            set
            {
                iWorking = value;
                RaisePropertyChanged("Working");
            }
        }
        public decimal ProfitAverage
        {
            get { return DailyInfo.Count != 0 ? DailyInfo.Average(d => d.Profit) : 0m; }
        }
        public bool DetailsUpdating
        {
            get
            {
                return iDetailsUpdating;
            }
            set
            {
                iDetailsUpdating = value;
                RaisePropertyChanged("DetailsUpdating");
            }
        }

        public bool OverviewHidden
        {
            get { return iOverviewHidden; }
            set
            {
                iOverviewHidden = value;
                RaisePropertyChanged("OverviewHidden");
            }
        }


        [ImportingConstructor]
        public DashboardViewModel(IDashboardView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, IPriceLookup ipl, IPriceSourceSelector ips)
            : base(view)
        {
            iModel = tm;
            DailyInfo = new SmartObservableCollection<DisplayDashboard>(view.BeginInvoke);
            CurrentWallets = new SmartObservableCollection<KeyValuePair<PropertyInfo,IEnumerable<string>>>(view.BeginInvoke);
            Investment = new SmartObservableCollection<DisplayDetail>(view.BeginInvoke);
            Sales = new SmartObservableCollection<DisplayDetail>(view.BeginInvoke);
            Profit = new SmartObservableCollection<DisplayDetail>(view.BeginInvoke);
            iLookup = ipl;
            iSource = ips;

            view.DetailsRequested += new EventHandler<DetailsRequestedEventArgs>(view_DetailsRequested);

            FilterWeekCommand = new DelegateCommand(() => Filter(7));
            FilterTwoWeeksCommand = new DelegateCommand(() => Filter(14));
            FilterMonthCommand = new DelegateCommand(() => Filter(30));
            FilterAllTimeCommand = new DelegateCommand(() => Filter(-1));
            OverviewHideCommand = new DelegateCommand(() => OverviewHidden = !OverviewHidden);
            Filter(7);

            RefreshWallets();
        }

        private void Filter(int days)
        {
            if (days == -1)
                iDateBefore = DateTime.MinValue;
            else
                iDateBefore = DateTime.UtcNow.AddDays(-days);

            Refresh();
        }

        private PropertyInfo iSalesPropertyInfo = typeof(DisplayDashboard).GetProperty("Sales");
        public void RefreshWallets()
        {
            lock (iUpdaterLock)
            {
                CurrentWallets.Clear();
                var insert = iModel.Wallets.Select(w => w).ToList().Select(w => w.DisplayName).ToList();
                CurrentWallets.Add(new KeyValuePair<PropertyInfo, IEnumerable<string>>(iSalesPropertyInfo, insert));
            }
        }
        public void Refresh()
        {
            Thread workerThread = new Thread(new ThreadStart(this.ThreadedRefresh));
            workerThread.Name = "DashboardRefresh";
            workerThread.Start();
        }

        private void ThreadedRefresh()
        {
            lock (iUpdaterLock)
            {
                Working = true;
                DailyInfo.Clear();

               // iModel.Connection.Open();

                var investment = (from w in iModel.Transactions
                                  where w.Date > iDateBefore
                                  group w by w.Date into grouped
                                  orderby grouped.Key
                                  select grouped);

                WorkingCount = investment.Count();
                CurrentIndex = 0;

                List<DisplayDashboard> cache = new List<DisplayDashboard>();

                IEnumerable<string> indexes = CurrentWallets.Single(x => x.Key == typeof(DisplayDashboard).GetProperty("Sales")).Value;
                foreach (var i in investment)
                {
                    DisplayDashboard dd = new DisplayDashboard()
                    {
                        Key = i.Key,
                        Profit = 0m,
                        Investment = 0m,
                    };

                    foreach (var s in indexes)
                    {
                        dd.Sales.Add(s, 0m);
                    }

                    dd.Investment = i.Where(t => t.TransactionType == (long)TransactionType.Buy).Sum(t => t.Price * t.Quantity);
                    dd.Profit = i.Where(t => t.TransactionType == (long)TransactionType.Sell).GroupBy(g => g.Date).Select(g => g.Sum(gt => Math.Round((gt.Price - 
                        iSource.Current(gt.TypeID, OrderType.Buy, 10000002)//iModel.Transactions.AverageBuyPrice(gt.TypeID)
                        ) * gt.Quantity, 2))).FirstOrDefault();

                    var entityGroup = (from g in i
                                       where g.TransactionType == (long)TransactionType.Sell
                                       group g by g.Wallet into grouped
                                       select grouped);

                    foreach (var groupedEntity in entityGroup)
                    {
                        dd.Sales[groupedEntity.Key.DisplayName] = groupedEntity.Sum(ge => ge.Price * ge.Quantity);
                    }

                    cache.Add(dd);
                    CurrentIndex++;
                }
                DailyInfo.AddRange(cache);

              //  iModel.Connection.Close();

                RaisePropertyChanged("ProfitAverage");
                Working = false;
            }
        }
        private void ThreadedDetailsRefresh(DetailsRequestedEventArgs e)
        {
            lock (iUpdaterLock)
            {
                lock (iDetailLock)
                {
                    if (iCurrentKey == e.Key && iCurrentBindingKey == e.BindingKey)
                        return;
                    iCurrentKey = e.Key;
                    iCurrentBindingKey = e.BindingKey;


                    this.DetailsUpdating = true;
                    Investment.Clear();
                    Sales.Clear();
                    Profit.Clear();

                    if (e.BindingKey.Contains("Investment"))
                    {
                        foreach (var grouping in iModel.Transactions.Where(s => s.Date == e.Key && s.TransactionType == (long)TransactionType.Buy).GroupBy(s => s.Wallet))
                        {
                            foreach (var subGroup in grouping.GroupBy(s => s.TypeName))
                            {
                                Investment.Add(new DisplayDetail() { TypeName = string.Format("{0}x {1}", subGroup.Sum(t => t.Quantity), subGroup.Key), Value = subGroup.Sum(t => t.Quantity * t.Price) });
                            }
                        }
                    }
                    if (e.BindingKey.Contains("Sales"))
                    {
                        foreach (var grouping in iModel.Transactions.Where(s => s.Date == e.Key && s.TransactionType == (long)TransactionType.Sell).GroupBy(s => s.Wallet))
                        {
                            foreach (var subGroup in grouping.GroupBy(s => s.TypeName))
                            {
                                Sales.Add(new DisplayDetail() { TypeName = string.Format("{0}x {1}", subGroup.Sum(t => t.Quantity), subGroup.Key), Value = subGroup.Sum(t => t.Quantity * t.Price) });
                            }
                        }
                    }
                    if (e.BindingKey.Contains("Profit"))
                    {
                        foreach (var grouping in iModel.Transactions.Where(t => t.TransactionType == (long)TransactionType.Sell && t.Date == e.Key).GroupBy(t => t.TypeName))
                        {
                            var val = grouping.Sum(gt => Math.Round((gt.Price - iModel.Transactions.AverageBuyPrice(gt.TypeID)) * gt.Quantity, 2));
                            Profit.Add(new DisplayDetail() { TypeName = string.Format("{0}x {1}", grouping.Sum(t => t.Quantity), grouping.Key), Value = val });
                        }
                    }
                    this.DetailsUpdating = false;
                }
            }
        }

        
        private void view_DetailsRequested(object sender, DetailsRequestedEventArgs e)
        {
            Action updater = () =>
            {
                ThreadedDetailsRefresh(e);
            };
            Thread detailThread = new Thread(new ThreadStart(updater));
            detailThread.Name = "DashboardDetailRefresh";
            detailThread.Start();
        }
        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            Refresh();
        }
    }
}

