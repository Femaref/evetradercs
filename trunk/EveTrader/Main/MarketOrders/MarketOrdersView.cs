using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.DomainModel;
using Core.Network.EveApi.Entities;
using EveTrader.Helpers;

namespace EveTrader.Main.MarketOrders
{
    public class MarketOrdersView
    {
        private readonly GenericObjectDispatcher iDispatcher;

        private IEnumerable<IWallet> iEntities = new List<IWallet>();

        private Func<MarketOrder, object> iGroupBy = order => order.StationID;
        private Func<MarketOrder, object> iOrderBy = order => order.Issued;
        private bool iAscending = true;

        public BindingList<MarketOrderListViewItem> BuyOrders { get; private set; }
        public BindingList<MarketOrderListViewItem> SellOrders { get; private set; }

        public BindingList<ListViewGroup> BuyGroups { get; private set; }
        public BindingList<ListViewGroup> SellGroups { get; private set; }



        private IEntity iSelectedEntity;
        private IEntity SelectedEntity
        {
            get
            {
                return iSelectedEntity;
            }
            set
            {
                if(value == null)
                    return;

                iSelectedEntity = value;
                lock(iLocker)
                {
                    SortedOrders.Clear();
                    iBaseOrders.Clear();
                    iBaseOrders = new List<MarketOrder>(iEntities.Where(iw => iw == value).Single().MarketOrders);
                    SortedOrders = new BindingList<MarketOrder>(iBaseOrders);

                    SortMarketOrders(iGroupBy, iOrderBy, iAscending);
                    FilterMarketOrders("");

                }
            }
        }

        public MarketOrdersView(GenericObjectDispatcher dispatcher)
        {
            BuyOrders = new BindingList<MarketOrderListViewItem>();
            SellOrders = new  BindingList<MarketOrderListViewItem>();

            iDispatcher = dispatcher;

            iEntities = iDispatcher.GetByType<IWallet>(t => ((t as IGenericObject) is IEntity) && (t).Name != "");


            if (iEntities.Count() > 0)
            {
                SelectedEntity = ((iEntities.First() as IGenericObject).Parent as IEntity);
            }
        }


        private object iLocker = new object();

        private BindingList<MarketOrder> SortedOrders { get; set; }

        private List<MarketOrder> iBaseOrders = new List<MarketOrder>();

        public void SelectEntity(string name)
        {
            SelectedEntity = iEntities.Where(iw => iw.Name == name).SingleOrDefault();
        }
        public void SelectEntity(IEntity entity)
        {
            if(iEntities.Contains((IWallet)entity))
                iSelectedEntity = entity;
        }

        public void SortMarketOrders(Func<MarketOrder, object> groupBy, Func<MarketOrder, object> orderBy, bool ascending)
        {
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


            var filter =  iBaseOrders.Where(
                order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name.ToLower().Contains(keyword) ||
                         Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeID).Name.ToLower().Contains(keyword));
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

            Font itemFont = new Font(item.Font, item.MarketOrder.Ignore ? FontStyle.Strikeout : FontStyle.Regular);

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
        private void AddGroup(ICollection<ListViewGroup> groupList, ICollection<MarketOrderListViewItem> orderList, string groupName, IEnumerable<MarketOrder> orders)
        {
            var testGroup = groupList.Where(g => g.Header == groupName);
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
                MarketOrderListViewItem item = this.CreateListViewItem(mo, currentGroup);
                orderList.Add(item);
            }
        }
    }
}
