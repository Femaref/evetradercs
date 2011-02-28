using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Waf.Applications;
using System.Windows.Input;
using EveTrader.Core.Collections.ObjectModel;
using EveTrader.Core.Model;
using EveTrader.Core.Model.Static;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.Visual.View;
using EveTrader.Core.Visual.ViewModel.Display;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class MarketOrdersViewModel : ViewModel<IMarketOrdersView>, IRefreshableViewModel
    {
        private readonly TraderModel iModel;
        private readonly StaticModel iStaticData;
        private readonly ISettingsProvider iSettings;

        private object iUpdaterLock = new object();

        private bool iUpdating = false;
        private Func<MarketOrders, bool> iHideWhere = mo => mo.OrderState == (long)MarketOrderState.OpenActive;
        private Entities iCurrentEntity;
        
        public SmartObservableCollection<Entities> CurrentEntities { get; private set; }
        public SmartObservableCollection<DisplayMarketOrders> Orders { get; private set; }
        public Entities CurrentEntity
        {
            get { return iCurrentEntity; }
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
        public decimal TotalBuyOrders
        {
            get { return Orders.Where(mo => mo.OrderState == (long)MarketOrderState.OpenActive && mo.Bid).Sum(mo => mo.Price * mo.VolumeEntered); }
        }
        public decimal TotalSellOrders
        {
            get { return Orders.Where(mo => mo.OrderState == (long)MarketOrderState.OpenActive && !mo.Bid).Sum(mo => mo.Price * mo.VolumeEntered); }
        }
        public decimal RemainingBuyOrders
        {
            get { return Orders.Where(mo => mo.OrderState == (long)MarketOrderState.OpenActive && mo.Bid).Sum(mo => mo.Price * mo.VolumeRemaining); }
        }
        public decimal RemainingSellOrders
        {
            get { return Orders.Where(mo => mo.OrderState == (long)MarketOrderState.OpenActive && !mo.Bid).Sum(mo => mo.Price * mo.VolumeRemaining); }
        }
        public bool HideExpired
        {
            get { return iSettings.HideExpired; }
            set
            {
                iSettings.HideExpired = value;
                RaisePropertyChanged("HideExpired");
                
            }
        }

        public ICommand LoadCommand { get; private set; }

        [ImportingConstructor]
        public MarketOrdersViewModel(IMarketOrdersView view, [Import(RequiredCreationPolicy = CreationPolicy.NonShared)] TraderModel model, StaticModel sm, ISettingsProvider settings)
            : base(view)
        {
            iModel = model;
            iStaticData = sm;
            iSettings = settings;
            Orders = new SmartObservableCollection<DisplayMarketOrders>(view.BeginInvoke);
            CurrentEntities = new SmartObservableCollection<Entities>(view.BeginInvoke);
            view.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs<Entities>>(view_EntitySelectionChanged);
            LoadCommand = new DelegateCommand(() => Refresh());

            RefreshCurrentEntities();
        }

        private void RefreshCurrentEntities()
        {
            lock (iUpdaterLock)
            {
                CurrentEntities.Clear();
                var insert = iModel.Entity.Where(e => (e is Characters) || !(e as Corporations).Npc).ToList();
                CurrentEntities.AddRange(insert);
            }
        }
        private void SelectEntity(string name)
        {
            SelectEntity(iModel.Entity.Where(e => e.Name == name).FirstOrDefault());
        }
        private void SelectEntity(Entities e)
        {
            if (e == null)
                return;
            lock (iUpdaterLock)
            {
                iCurrentEntity = e;
                RaisePropertyChanged("CurrentEntity");
                
            }
        }

        public void Refresh()
        {
            Thread updaterThread = new Thread(new ThreadStart(this.ThreadedRefresh));
            updaterThread.Name = "MarketOrdersRefresh";
            updaterThread.Start();
        }
        private void ThreadedRefresh()
        {
            lock (iUpdaterLock)
            {
                this.Updating = true;
                Orders.Clear();

                IEnumerable<DisplayMarketOrders> output = new List<DisplayMarketOrders>();

                if (iCurrentEntity != null)
                {
                    iCurrentEntity = iModel.Entity.Single(t => t.ID == iCurrentEntity.ID);

                    IEnumerable<MarketOrders> cache = null;
                    cache = iCurrentEntity.MarketOrders.Where(mo => !iSettings.HideExpired || mo.OrderState == (long)MarketOrderState.OpenActive);

                    output = cache.Select(x =>
                    {
                        DisplayMarketOrders y = (DisplayMarketOrders)x;
                        var type = iStaticData.invTypes.Where(t => t.typeID == y.TypeID).FirstOrDefault();
                        var station = iStaticData.staStations.Where(s => s.stationID == y.StationID).FirstOrDefault();
                        y.TypeName = type != null ? type.typeName : "Unknown Type";
                        y.StationName = station != null ? station.stationName : "Unknown Station";
                        return y;
                    }).ToList();

                    Orders.AddRange(output);
                }

                this.Updating = false;
                RaisePropertyChanged("TotalBuyOrders");
                RaisePropertyChanged("TotalSellOrders");
                RaisePropertyChanged("RemainingBuyOrders");
                RaisePropertyChanged("RemainingBuyOrders");
            }
        }

        private void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Entities> e)
        {
            SelectEntity(e.Selection);
        }
        public void DataIncoming(object sender, Services.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentEntities();

            if (CurrentEntity != null && e.UpdatedEntities.Any(en => en.Name == CurrentEntity.Name))
                Refresh();
        }
    }
}

