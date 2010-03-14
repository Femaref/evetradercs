using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.DomainModel;
using Core.Network.EveApi.Entities;
using EveTrader.Analysis;
using EveTrader.Helpers;

namespace EveTrader.Main.MarketOrders
{
    public class MarketOrdersView : INotifyPropertyChanged
    {
        private readonly IGenericObjectDispatcher iDispatcher;
        private readonly IEnumerable<IWallet> iEntities = new List<IWallet>();
        private readonly object iLocker = new object();
        private bool iAscending = true;
        private List<MarketOrder> iBaseOrders = new List<MarketOrder>();

        private string iFilterBy = "";

        private Func<MarketOrder, object> iGroupBy = order => order.StationID;

        private bool iHideExpired;
        private Func<MarketOrder, object> iOrderBy = order => order.Issued;
        private IEntity iSelectedEntity;
        private double iTotalEstimatedEscrow;
        private double iTotalEstimatedIncome;
        private double iTotalExpectedEscrow;
        private double iTotalExpectedIncome;

        public MarketOrdersView(IGenericObjectDispatcher dispatcher)
        {
            BuyOrders = new BindingList<MarketOrderListViewItem>();
            SellOrders = new BindingList<MarketOrderListViewItem>();

            iDispatcher = dispatcher;

            iEntities = iDispatcher.GetByType<IWallet>(t => ((t as IGenericObject) is IEntity) && (t).Name != "");


            if (iEntities.Count() > 0)
            {
                SelectedEntity = ((iEntities.First()).Parent as IEntity);
            }
        }

        public bool HideExpired
        {
            get { return iHideExpired; }
            set
            {
                iHideExpired = value;
                OnPropertyChanged("HideExpired");
            }
        }

        public string FilterBy
        {
            get { return iFilterBy; }
            set
            {
                iFilterBy = value;
                OnPropertyChanged("FilterBy");
            }
        }


        public BindingList<MarketOrderListViewItem> BuyOrders { get; private set; }
        public BindingList<MarketOrderListViewItem> SellOrders { get; private set; }

        public BindingList<ListViewGroup> BuyGroups { get; private set; }
        public BindingList<ListViewGroup> SellGroups { get; private set; }


        private IEntity SelectedEntity
        {
            get { return iSelectedEntity; }
            set
            {
                if (value == null)
                    return;

                iSelectedEntity = value;
                lock (iLocker)
                {
                    SortedOrders.Clear();
                    iBaseOrders.Clear();
                    iBaseOrders = new List<MarketOrder>(iEntities.Where(iw => iw == value).Single().MarketOrders);
                    SortedOrders = new BindingList<MarketOrder>(iBaseOrders);

                    SortMarketOrders(iGroupBy, iOrderBy, iAscending);
                    FilterMarketOrders("");
                }
                OnPropertyChanged("SelectedEntity");
            }
        }

        private BindingList<MarketOrder> SortedOrders { get; set; }

        public double TotalEstimatedIncome
        {
            get { return iTotalEstimatedIncome; }
            set
            {
                iTotalEstimatedIncome = value;
                OnPropertyChanged("TotalEstimatedIncome");
            }
        }
        public double TotalExpectedIncome
        {
            get { return iTotalExpectedIncome; }
            set
            {
                iTotalExpectedIncome = value;
                OnPropertyChanged("TotalExpectedIncome");
            }
        }
        public double TotalEstimatedEscrow
        {
            get { return iTotalEstimatedEscrow; }
            set
            {
                iTotalEstimatedEscrow = value;
                OnPropertyChanged("TotalEstimatedEscrow");
            }
        }
        public double TotalExpectedEscrow
        {
            get { return iTotalExpectedEscrow; }
            set
            {
                iTotalExpectedEscrow = value;
                OnPropertyChanged("TotalExpectedEscrow");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void SelectEntity(string name)
        {
            SelectedEntity = iEntities.Where(iw => iw.Name == name).SingleOrDefault();
            Refresh();
        }

        public void SelectEntity(IEntity entity)
        {
            if (iEntities.Contains((IWallet) entity))
                iSelectedEntity = entity;
            Refresh();
        }

        public void Refresh()
        {
            SellOrders.Clear();
            BuyOrders.Clear();
            SellGroups.Clear();
            BuyGroups.Clear();

            SortMarketOrders(iGroupBy, iOrderBy, iAscending);
            FilterMarketOrders(FilterBy);
            if (iHideExpired)
            {
                IEnumerable<MarketOrder> toHide = SortedOrders.Where(order =>
                                                                     order.OrderState == MarketOrderState.OpenActive ||
                                                                     order.OrderState == MarketOrderState.Pending);
                foreach (MarketOrder mo in toHide)
                {
                    SortedOrders.Remove(mo);
                }
            }

            if (iGroupBy != null)
            {
                IEnumerable<IGrouping<object, MarketOrder>> x = SortedOrders.GroupBy(iGroupBy);
                foreach (var grouping in x)
                {
                    foreach (var orderTypeGroup in grouping.GroupBy(mo => mo.Type))
                    {
                        if (orderTypeGroup.Key == MarketOrderType.Sell)
                        {
                            string groupName = orderTypeGroup.First().TypeID == (int) grouping.Key
                                                   ? Resources.Instance.EveObjects.Types.GetTypeById(
                                                         (int) grouping.Key).Name
                                                   : Resources.Instance.EveObjects.Stations.
                                                         GetStationById((int) grouping.Key).Name;

                            AddGroup(SellGroups, SellOrders, groupName, orderTypeGroup);
                        }
                        else
                        {
                            string groupName = orderTypeGroup.First().TypeID == (int) grouping.Key
                                                   ? Resources.Instance.EveObjects.Types.GetTypeById(
                                                         (int) grouping.Key).Name
                                                   : Resources.Instance.EveObjects.Stations.
                                                         GetStationById((int) grouping.Key).Name;

                            AddGroup(BuyGroups, BuyOrders, groupName, orderTypeGroup);
                        }
                    }
                }
            }
            else
            {
                foreach (var orderTypeGroup in SortedOrders.GroupBy(mo => mo.Type))
                {
                    if (orderTypeGroup.Key == MarketOrderType.Sell)
                    {
                        foreach (MarketOrder mo in orderTypeGroup)
                        {
                            MarketOrderListViewItem item = CreateListViewItem(mo, null);
                            SellOrders.Add(item);
                        }
                    }
                    else
                    {
                        foreach (MarketOrder mo in orderTypeGroup)
                        {
                            MarketOrderListViewItem item = CreateListViewItem(mo, null);
                            BuyOrders.Add(item);
                        }
                    }
                }
            }


            TotalExpectedEscrow =
                SortedOrders.Where(mo => mo.Type == MarketOrderType.Buy).Sum(mo => mo.Escrow);
            TotalEstimatedEscrow =
                SortedOrders.Where(mo => mo.Type == MarketOrderType.Buy).Sum(mo => mo.GetEstimatedSoldAmount());
            TotalExpectedIncome =
                SortedOrders.Where(mo => mo.Type == MarketOrderType.Sell).Sum(mo => mo.VolumeRemaining*mo.Price);
            TotalEstimatedIncome =
                SortedOrders.Where(mo => mo.Type == MarketOrderType.Sell).Sum(mo => mo.GetEstimatedSoldAmount());
        }

        public void SortMarketOrders(Func<MarketOrder, object> groupBy, Func<MarketOrder, object> orderBy,
                                     bool ascending)
        {
            iGroupBy = groupBy;
            iOrderBy = orderBy;
            iAscending = ascending;
            lock (iLocker)
            {
                if (groupBy == null)
                {
                    if (ascending)
                        SortedOrders.OrderBy(orderBy);
                    else
                        SortedOrders.OrderByDescending(orderBy);
                }
                else
                {
                    if (ascending)
                        SortedOrders.OrderBy(groupBy).ThenBy(orderBy);
                    else
                        SortedOrders.OrderBy(groupBy).ThenByDescending(orderBy);
                }
            }
        }

        public void FilterMarketOrders(string keyword)
        {
            keyword = keyword.ToLower();


            IEnumerable<MarketOrder> filter = iBaseOrders.Where(
                order =>
                Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name.ToLower().Contains(keyword) ||
                Resources.Instance.EveObjects.Types.GetTypeById(order.TypeID).Name.ToLower().Contains(keyword));
            if (iBaseOrders.Count > filter.Count())
            {
                lock (iLocker)
                {
                    SortedOrders.Clear();
                    foreach (MarketOrder mo in filter)
                    {
                        SortedOrders.Add(mo);
                    }
                }
            }
        }

        private MarketOrderListViewItem CreateListViewItem(MarketOrder order, ListViewGroup group)
        {
            MarketOrderListViewItem item = MarketOrderListViewItem.Create(order, group);

            var itemFont = new Font(item.Font, item.MarketOrder.Ignore ? FontStyle.Strikeout : FontStyle.Regular);

            item.UseItemStyleForSubItems = false;
            item.Font = itemFont;

            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                subItem.Font = itemFont;
            }
            switch (order.Type)
            {
                case MarketOrderType.Buy:
                    item.SubItems[4].ForeColor = Color.Goldenrod;
                    item.SubItems[6].ForeColor = Color.Goldenrod;
                    break;

                case MarketOrderType.Sell:
                    item.SubItems[4].ForeColor = Color.ForestGreen;
                    item.SubItems[6].ForeColor = Color.ForestGreen;
                    break;
            }
            return item;
        }

        private void AddGroup(ICollection<ListViewGroup> groupList, ICollection<MarketOrderListViewItem> orderList,
                              string groupName, IEnumerable<MarketOrder> orders)
        {
            IEnumerable<ListViewGroup> testGroup = groupList.Where(g => g.Header == groupName);
            ListViewGroup currentGroup;
            if (testGroup.Count() == 1)
                currentGroup = testGroup.Single();
            else
            {
                currentGroup = new ListViewGroup(groupName);
                groupList.Add(currentGroup);
            }
            foreach (MarketOrder mo in orders)
            {
                MarketOrderListViewItem item = CreateListViewItem(mo, currentGroup);
                orderList.Add(item);
            }
        }

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }
    }
}