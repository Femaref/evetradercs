using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Visual.ViewModel.Display;
using EveTrader.Core.Services;
using System.Threading;
using EveTrader.Core.Model;
using System.Threading.Tasks;

namespace EveTrader.Core.ViewModel
{
    public abstract class ReportPageViewModelBase<T, U> : ViewModel<T>
        where T : IView
    {
        protected TraderModel model;
        protected IPriceSourceSelector priceSelector;
        protected readonly object locker = new object();
        private ISettingsProvider settings;
        private bool updating;

        public ReportPageViewModelBase([Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, 
            T view, 
            IPriceSourceSelector sel,
            ISettingsProvider provider)
            : base(view)
        {
            this.model = tm;
            this.priceSelector = sel;
            this.settings = provider;
        }

        protected IEnumerable<DisplayReport> GroupedTransactions(IEnumerable<Transactions> input, Func<Transactions, string> groupBy)
        {
            return input
                    .GroupBy(groupBy)
                    .Select(g => new DisplayReport()
                    {
                        Key = g.Key,
                        Quantity = g.Sum(gi => gi.Quantity),
                        GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                        //PureProfit = Math.Round(g.Sum(gi => ((gi.Price  - gi.SalesTax - (this.iActivateTransactionLimit ? Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID, this.iTransactionTimeLimit) : Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID))) * gi.Quantity) / 1000000), 2),
                        PureProfit = Math.Round(g.Sum(gi => ((gi.Price - priceSelector.Current(gi.TypeID, OrderType.Buy)) * gi.Quantity) / 1000000), 2),
                        //SalesTax = Math.Round(g.Sum(gi => gi.SalesTax * gi.Quantity / 1000000), 2)
                        SalesTax = 0m
                    });
        }
        protected IEnumerable<DisplayReport> Combine(IEnumerable<IEnumerable<DisplayReport>> input)
        {
            return input.SelectMany(d => d).GroupBy(d => d.Key).Select(d => new DisplayReport()
            {
                Key = d.Key,
                GrossSales = d.Sum(dr => dr.GrossSales),
                PureProfit = d.Sum(dr => dr.PureProfit),
                SalesTax = d.Sum(dr => dr.SalesTax)
            });
        }

        public void Refresh(object sender, EntitiesUpdatedEventArgs<long> e)
        {
            Thread t = new Thread(new ThreadStart(() => ThreadedRefresh(e.UpdatedEntities)));
            t.Name = string.Format("{0} refresh", this.Name);
            t.Start();
        }

        CancellationTokenSource cts = new CancellationTokenSource();

        private void ThreadedRefresh(IEnumerable<long> data)
        {
            lock (locker)
            {
                cts.Cancel();

                
                cts = new CancellationTokenSource();
                cts.Token.Register(() => Updating = false);


                Task t = Task.Factory.StartNew(() => Updating = true)
                    .ContinueWith(task => InnerRefresh(this.model.Entity.Where(e => data.Contains(e.ID))), cts.Token)
                    .ContinueWith(task => Updating = false);

                //Updating = true;
                //InnerRefresh(this.model.Entity.Where(e => data.Contains(e.ID)));
                //Updating = false;
            }
        }

        protected bool Filter(U obj, Func<U, DateTime> selector)
        {
            return (!this.settings.ReportApplyStartFilter || selector(obj) >= this.settings.ReportStartDate) && (!this.settings.ReportApplyEndFilter || selector(obj) <= this.settings.ReportEndDate);
        }

        protected abstract void InnerRefresh(IEnumerable<Entities> data);

        public abstract string Name { get; }


        public bool Updating 

        {
            get { return updating; }
            set
            {
                updating = value;
                RaisePropertyChanged("Updating");
            }
        }
    }
}
