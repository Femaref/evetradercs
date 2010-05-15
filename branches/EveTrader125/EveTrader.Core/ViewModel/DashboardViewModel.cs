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

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class DashboardViewModel : ViewModel<IDashboardView>
    {
        private TraderModel iModel;

        [ImportingConstructor]
        public DashboardViewModel(IDashboardView view, TraderModel tm)
            : base(view)
        {
            iModel = tm;
            DailyInfo = new ObservableCollection<DisplayDashboard>();
            CurrentWallets = new ObservableCollection<string>();
            Refresh();
        }

        public ObservableCollection<DisplayDashboard> DailyInfo { get; private set; }
        public ObservableCollection<string> CurrentWallets { get; private set; }


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

            RefreshWallets();

            //TODO: Datageneration

            var data = (from w in iModel.Transactions
                        let date = new DateTimeHelper() {Year = w.Date.Year, Month = w.Date.Month, Day = w.Date.Day}
                        where w.TransactionType == (long)TransactionType.Buy
                        group w by date into grouped
                        orderby grouped.Key.Year, grouped.Key.Month, grouped.Key.Day
                        select grouped);

            foreach (var grouping in data)
            {
                DisplayDashboard dd = new DisplayDashboard()
                {
                    Key = grouping.Key,
                    Profit = 0m,
                    Investment = new Dictionary<string, decimal>()
                };
                foreach (string s in CurrentWallets)
                {
                    dd.Investment.Add(s, 0m);
                }

                var entityGroup = (from g in grouping
                                   group g by g.Wallet into grouped
                                   select grouped);
                foreach (var groupedEntity in entityGroup)
                {
                    dd.Investment[groupedEntity.Key.Name] = groupedEntity.Sum(ge => ge.Price);
                }
                DailyInfo.Add(dd);
            }

        }
    }
}
