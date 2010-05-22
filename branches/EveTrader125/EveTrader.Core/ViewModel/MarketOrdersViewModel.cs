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

namespace EveTrader.Core.ViewModel
{
    [Export]
    public class MarketOrdersViewModel : ViewModel<IMarketOrdersView>
    {
        private TraderModel iModel;

        private bool iHideExpired = false;
        private Func<MarketOrders, bool> iHideWhere = mo => mo.OrderState == (long)MarketOrderState.OpenActive;

        private Entities iCurrentEntity;
        

        public Entities CurrentEntity
        {
            get { return iCurrentEntity; }
        }

        public ObservableCollection<Entities> CurrentEntities { get; set; }

        private ICommand iHideExpiredCommand;

        [ImportingConstructor]
        public MarketOrdersViewModel(IMarketOrdersView view, TraderModel model) : base(view)
        {
            iModel = model;
            Orders = new ObservableCollection<MarketOrders>();
            CurrentEntities = new ObservableCollection<Entities>();
            view.EntitySelectionChanged += new EventHandler<EntitySelectionChangedEventArgs>(view_EntitySelectionChanged);

            RefreshCurrentEntities();
            SelectEntity(iModel.Entity.First());
        }

        private void RefreshCurrentEntities()
        {
            CurrentEntities.Clear();
            iModel.Entity.Where(e => (e is Characters) || !(e as Corporations).Npc).ToList().ForEach(e => CurrentEntities.Add(e));
        }

        void view_EntitySelectionChanged(object sender, EntitySelectionChangedEventArgs e)
        {
            SelectEntity(e.Selection);
        }

        public ObservableCollection<MarketOrders> Orders { get; set; }

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
            get { return iHideExpired; }
            set
            {
                iHideExpired = value;
                RaisePropertyChanged("HideExpired");
                Refresh();
            }
        }
        public void Refresh()
        {
            Orders.Clear();
            if (iHideExpired)
                iCurrentEntity.MarketOrders.Where(iHideWhere).ToList().ForEach(x => Orders.Add(x));
            else
                iCurrentEntity.MarketOrders.ToList().ForEach(x => Orders.Add(x));

            RaisePropertyChanged("TotalBuyOrders");
            RaisePropertyChanged("TotalSellOrders");
            RaisePropertyChanged("RemainingBuyOrders");
            RaisePropertyChanged("RemainingBuyOrders");

        }
        private void SelectEntity(string name)
        {
            iCurrentEntity = iModel.Entity.Where(e => e.Name == name).First();
            RaisePropertyChanged("CurrentEntity");
            Refresh();
        }
        private void SelectEntity(Entities e)
        {
            iCurrentEntity = e;
            RaisePropertyChanged("CurrentEntity");
            Refresh();
        }

        public ICommand HideExpiredCommand
        {
            get { return iHideExpiredCommand; }
            set
            {
                if (iHideExpiredCommand != value)
                {
                    iHideExpiredCommand = value;
                    RaisePropertyChanged("HideExpiredCommand");
                }
            }
        }
    }
}