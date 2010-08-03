using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using EveTrader.Core.Model;
using System.Waf.Applications;
using System.Windows.Input;
using System.Collections.ObjectModel;
using EveTrader.Core.View;
using System.ComponentModel.Composition;
using EveTrader.Core.ViewModel.Display;
using MoreLinq;
using EveTrader.Core.Collections.ObjectModel;
using System.Threading;

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MarketOrdersViewModel : ViewModel<IMarketOrdersView>, IRefreshableViewModel
    {
        private TraderModel iModel;

        private Func<MarketOrders, bool> iHideWhere = mo => mo.OrderState == (long)MarketOrderState.OpenActive;

        private Entities iCurrentEntity;
        

        public Entities CurrentEntity
        {
            get { return iCurrentEntity; }
        }

        public SmartObservableCollection<Entities> CurrentEntities { get; set; }

        private readonly StaticModel iStaticData;
        private readonly ISettingsProvider iSettings;
        private bool iUpdating = false;

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

        private object iUpdaterLock = new object();

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

            RefreshCurrentEntities();
            SelectEntity(CurrentEntities.FirstOrDefault());
        }

        private void RefreshCurrentEntities()
        {
            CurrentEntities.Clear();
            iModel.Entity.Where(e => (e is Characters) || !(e as Corporations).Npc).ToList().ForEach(e => CurrentEntities.Add(e));
        }

        void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs<Entities> e)
        {
            SelectEntity(e.Selection);
        }

        public SmartObservableCollection<DisplayMarketOrders> Orders { get; set; }

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
                Refresh();
            }
        }
        public void Refresh()
        {

            Action updater = () =>
            {
                lock (iUpdaterLock)
                {
                    this.Updating = true;
                    Orders.Clear();

                    IEnumerable<DisplayMarketOrders> output = null;

                    if (iSettings.HideExpired)
                        output = iCurrentEntity.MarketOrders.Where(iHideWhere).Select(x =>
                            {
                                DisplayMarketOrders y = (DisplayMarketOrders)x;
                                y.TypeName = iStaticData.invTypes.Where(t => t.typeID == y.TypeID).First().typeName;
                                y.StationName = iStaticData.staStations.Where(s => s.stationID == y.StationID).First().stationName;
                                return y;
                            });
                    else
                        output = iCurrentEntity.MarketOrders.Select(x =>
                            {
                                DisplayMarketOrders y = (DisplayMarketOrders)x;
                                y.TypeName = iStaticData.invTypes.Where(t => t.typeID == y.TypeID).First().typeName;
                                y.StationName = iStaticData.staStations.Where(s => s.stationID == y.StationID).First().stationName;
                                return y;
                            });

                    Orders.AddRange(output);

                    this.Updating = false;
                    RaisePropertyChanged("TotalBuyOrders");
                    RaisePropertyChanged("TotalSellOrders");
                    RaisePropertyChanged("RemainingBuyOrders");
                    RaisePropertyChanged("RemainingBuyOrders");
                }
                
            };
            Thread updaterThread = new Thread(new ThreadStart(updater));
            updaterThread.Start();

        }
        private void SelectEntity(string name)
        {
            iCurrentEntity = iModel.Entity.Where(e => e.Name == name).First();
            RaisePropertyChanged("CurrentEntity");
            Refresh();
        }
        private void SelectEntity(Entities e)
        {
            if (e == null)
                return;

            iCurrentEntity = e;
            RaisePropertyChanged("CurrentEntity");
            Refresh();
        }

        public void DataIncoming(object sender, Controllers.EntitiesUpdatedEventArgs e)
        {
            RefreshCurrentEntities();

            if (e.UpdatedEntities.Any(en => en.Name == CurrentEntity.Name))
                Refresh();
        }
    }
}

