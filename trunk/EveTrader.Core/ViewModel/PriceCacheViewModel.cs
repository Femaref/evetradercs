using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.View;
using EveTrader.Core.Model;
using System.Collections.ObjectModel;
using MoreLinq;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel.Display;
using EveTrader.Core.Collections.ObjectModel;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class PriceCacheViewModel : ViewModel<IPriceCacheView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;
        private readonly StaticModel iStaticData;

        private object iUpdaterLock = new object();
        private bool iUpdating;

        public SmartObservableCollection<DisplayPriceCache> Prices { get; private set; }
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

        [ImportingConstructor]
        public PriceCacheViewModel(IPriceCacheView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel tm, StaticModel sm)
            : base(view)
        {
            iModel = tm;
            iStaticData = sm;

            Prices = new SmartObservableCollection<DisplayPriceCache>(view.BeginInvoke);

            Refresh();
        }

        public void Refresh()
        {
            Thread updaterThread = new Thread(new ThreadStart(this.ThreadedRefresh));
            updaterThread.Name = "PriceCacheRefresh";
            updaterThread.Start();

        }
        private void ThreadedRefresh()
        {
            lock (iUpdaterLock)
            {
                Prices.Clear();

                var x = iModel.CachedPriceInfo.Select(c => new DisplayPriceCache()
                {
                    TypeID = c.TypeID,
                    BuyPrice = c.BuyPrice,
                    SellPrice = c.SellPrice
                }).ToList();
                x.ForEach(c =>
                {
                    c.TypeName = iStaticData.invTypes.First(ty => ty.typeID == c.TypeID).typeName;

                });
                Prices.AddRange(x.OrderBy(c => c.TypeName));
            }
        }

        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            Refresh();
        }
    }
}
