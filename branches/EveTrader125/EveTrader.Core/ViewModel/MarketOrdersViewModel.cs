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

namespace EveTrader.Core.ViewModel
{
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

        private ICommand iSelectEntityCommand;
        private ICommand iHideExpiredCommand;

        public MarketOrdersViewModel(IMarketOrdersView view, TraderModel model) : base(view)
        {
            iSelectEntityCommand = new DelegateCommand((object o) => SelectEntity((string)o));

            iModel = model;
            iCurrentEntity = iModel.Entity.First();
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

        public ICommand SelectEntityCommand
        {
            get {return iSelectEntityCommand;}
            set
            {
                if (iSelectEntityCommand != value)
                {
                    iSelectEntityCommand = value;
                    RaisePropertyChanged("SelectEntityCommand");
                }
            }
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