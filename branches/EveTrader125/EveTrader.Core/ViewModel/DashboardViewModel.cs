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
            Details = new ObservableCollection<string>();

            CurrentWallets.CollectionChanged += view.ChartCollectionChanged;
            view.DetailsRequested += new EventHandler<DetailsRequestedEventArgs>(view_DetailsRequested);

            FilterWeekCommand = new DelegateCommand(() => Filter(7));
            FilterTwoWeeksCommand = new DelegateCommand(() => Filter(14));
            FilterMonthCommand = new DelegateCommand(() => Filter(30));
            FilterAllTimeCommand = new DelegateCommand(() => Filter(-1));
            RefreshWallets();
            Refresh();
        }

        void view_DetailsRequested(object sender, DetailsRequestedEventArgs e)
        {
            Details.Clear();
            if (e.BindingKey.Contains("Investment"))
            {
                foreach (var grouping in iModel.Transactions.Where(s => s.Date.Year == e.Key.Year && s.Date.Month == e.Key.Month && s.Date.Day == e.Key.Day && s.TransactionType == (long)TransactionType.Buy).GroupBy(s=> s.Wallet))
                {
                    foreach(var subGroup in grouping.GroupBy(s=> s.TypeName))
                    {

                        Details.Add(string.Format("{0}: {1} {2}x{3} for a total of {4}", grouping.Key.Name, TransactionType.Buy.StringValue(), subGroup.Sum(t => t.Quantity), subGroup.Key, subGroup.Sum(t => t.Quantity * t.Price).ToString("n")));
                    }
                   
                    
                }
                return;
            }
            foreach(var t in iModel.Transactions.Where(s => s.Date.Year == e.Key.Year && s.Date.Month == e.Key.Month && s.Date.Day == e.Key.Day))
            {
                Details.Add(string.Format("{0}: {1} {2}x{3} for {4} each", t.Wallet.Name, ((TransactionType)t.TransactionType).StringValue(), t.Quantity, t.TypeName, t.Price.ToString("n")));
            }
        }

        private void Filter(int days)
        {
            if(days == -1)
                iDateBefore = DateTime.MinValue;
            else
                iDateBefore = DateTime.UtcNow.AddDays(-days);

            Refresh();
        }

        public ObservableCollection<DisplayDashboard> DailyInfo { get; private set; }
        public ObservableCollection<string> CurrentWallets { get; private set; }
        public ObservableCollection<string> Details { get; private set; }


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

            var data = (from w in iModel.Transactions
                        let date = new DateTimeHelper() {Year = w.Date.Year, Month = w.Date.Month, Day = w.Date.Day}
                        where w.Date > iDateBefore
                        group w by date into grouped
                        orderby grouped.Key.Year, grouped.Key.Month, grouped.Key.Day
                        select grouped);

            foreach (var grouping in data)
            {
                DisplayDashboard dd = new DisplayDashboard()
                {
                    Key = grouping.Key,
                    Profit = 0m,
                    Investment = grouping.Where(t => t.TransactionType == (long)TransactionType.Buy).Sum(t => t.Price*t.Quantity),
                    Sales = new Dictionary<string, decimal>()
                };
                foreach (string s in CurrentWallets)
                {
                    dd.Sales.Add(s, 0m);
                }

                var entityGroup = (from g in grouping
                                   where g.TransactionType == (long)TransactionType.Sell
                                   group g by g.Wallet into grouped
                                   select grouped);
                foreach (var groupedEntity in entityGroup)
                {
                    dd.Sales[groupedEntity.Key.Name] = groupedEntity.Sum(ge => ge.Price*ge.Quantity);
                }
                DailyInfo.Add(dd);
            }
        }

    }
}
