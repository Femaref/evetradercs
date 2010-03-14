using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Network.EveApi.Entities;
using EveTrader.Analysis;

namespace EveTrader.Main.MarketOrders
{
    //FIX for corporations
    public partial class MarketOrdersTab : UserControl
    {
        List<IWallet> entities = new List<IWallet>();


        private int iLastClickedColumnHeaderIndex = -1;
        private bool iSortAscending;
        private bool iHideExpired;
        private Func<MarketOrder, object> iOrderByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name);
        private Func<MarketOrder, object> iGroupByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name);

        public MarketOrdersTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.CharactersComboBox.Items.Clear();
            this.BuyOrdersListView.Columns.Clear();
            this.iHideExpired = UISettings.Instance.OrderSettings.HideExpiredOrders;

            //need to remove the EventHandler before the init, otherwise an exception is thrown
            this.cbHideExpired.CheckedChanged -= this.cbHideExpired_CheckedChanged;
            this.cbHideExpired.Checked = this.iHideExpired;
            this.cbHideExpired.CheckedChanged += this.cbHideExpired_CheckedChanged;

            entities.Clear();
            foreach (Character character in Settings.Instance.Characters)
            {
                if (!CharactersComboBox.Items.Contains(character.Name))
                {
                    CharactersComboBox.Items.Add(character.Name);
                    entities.Add(character);
                }
                if (!CharactersComboBox.Items.Contains(character.Corporation.Name))
                {
                    CharactersComboBox.Items.Add(character.Corporation.Name);
                    entities.Add(character.Corporation);
                }
            }

            if (this.CharactersComboBox.Items.Count > 0)
            {
                this.CharactersComboBox.SelectedIndex = 0;
                this.RenderMarketOrders();
            }

            int n = 0;
            Dictionary<int, string> replaceStrings = new Dictionary<int, string>();
            replaceStrings.Add(4, "In escrow");

            foreach(ColumnHeader columnHeader in this.SellOrdersListView.Columns)
            {
                ColumnHeader newColumnHeader = (ColumnHeader) columnHeader.Clone();

                if (replaceStrings.ContainsKey(n))
                {
                    newColumnHeader.Text = replaceStrings[n];
                }

                this.BuyOrdersListView.Columns.Add(newColumnHeader);
                n++;
            }
        }
        public void RenderMarketOrders()
        {
            this.RenderMarketOrders(this.SelectedEntity());
        }

        public IWallet SelectedEntity()
        {
            return entities.Where(e => e.Name == this.CharactersComboBox.Text).Single();
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
        private void AddGroup(ListView lv, string groupName, IEnumerable<MarketOrder> orders)
        {
            ListViewGroup currentGroup = new ListViewGroup(groupName);
            lv.Groups.Add(currentGroup);

            foreach (MarketOrder mo in orders)
            {
                MarketOrderListViewItem item = this.CreateListViewItem(mo, currentGroup);
                lv.Items.Add(item);
            }
        }




        public void RenderMarketOrders(IWallet entity)
        {
            IEnumerable<MarketOrder> marketOrders = new List<MarketOrder>(entity.MarketOrders);

            marketOrders = this.SortMarketOrders(marketOrders, this.iGroupByKey, this.iOrderByKey,
                                                 this.iSortAscending);
            marketOrders = this.FilterMarketOrders(marketOrders, this.FilterByTextBox.Text);

            //filters expired orders
            if (iHideExpired)
                marketOrders =
                    marketOrders.Where(
                        order =>
                        order.OrderState == MarketOrderState.OpenActive || order.OrderState == MarketOrderState.Pending);

            this.BuyOrdersListView.Items.Clear();
            this.SellOrdersListView.Items.Clear();

            double totalExpectedEscrow = 
                marketOrders.Where(mo => mo.Type == MarketOrderType.Buy).Sum(mo => mo.Escrow);
            double totalEstimatedEscrow =
                marketOrders.Where(mo => mo.Type == MarketOrderType.Buy).Sum(mo => mo.GetEstimatedSoldAmount());
            double totalExpectedIncome =
                marketOrders.Where(mo => mo.Type == MarketOrderType.Sell).Sum(mo => mo.VolumeRemaining*mo.Price);
            double totalEstimatedIncome =
                marketOrders.Where(mo => mo.Type == MarketOrderType.Sell).Sum(mo => mo.GetEstimatedSoldAmount());




            if (GroupByProductRadioButton.Checked || GroupByStationRadioButton.Checked)
            {
                foreach (var grouping in marketOrders.GroupBy(mo => GroupByProductRadioButton.Checked ? mo.TypeID : mo.StationID))
                {
                    foreach (var orderTypeGroup in grouping.GroupBy(mo => mo.Type))
                    {
                        if (orderTypeGroup.Key == MarketOrderType.Sell)
                        {
                            string groupName = GroupByProductRadioButton.Checked
                                                   ? Core.Resources.Instance.EveObjects.Types.GetTypeById(
                                                         grouping.Key).Name
                                                   : Core.Resources.Instance.EveObjects.Stations.
                                                         GetStationById(grouping.Key).Name;

                            AddGroup(SellOrdersListView, groupName, orderTypeGroup);
                        }
                        else
                        {
                            string groupName = GroupByProductRadioButton.Checked
                                                   ? Core.Resources.Instance.EveObjects.Types.GetTypeById(
                                                         grouping.Key).Name
                                                   : Core.Resources.Instance.EveObjects.Stations.
                                                         GetStationById(grouping.Key).Name;

                            AddGroup(BuyOrdersListView, groupName, orderTypeGroup);

                        }
                    }
                }
            }
            else
            {
                foreach (var orderTypeGroup in marketOrders.GroupBy(mo => mo.Type))
                {
                    if (orderTypeGroup.Key == MarketOrderType.Sell)
                    {
                        foreach (MarketOrder mo in orderTypeGroup)
                        {
                            MarketOrderListViewItem item = this.CreateListViewItem(mo, null);
                            SellOrdersListView.Items.Add(item);
                        }
                    }
                    else
                    {
                        foreach (MarketOrder mo in orderTypeGroup)
                        {
                            MarketOrderListViewItem item = this.CreateListViewItem(mo, null);
                            BuyOrdersListView.Items.Add(item);
                        }
                    }
                }
            }


            this.TotalInExcrowLabel.Text = string.Format(
                "{0} / {1}",
                totalEstimatedEscrow.FormatCurrency(),
                totalExpectedEscrow.FormatCurrency());

            this.TotalIncomeLabel.Text = string.Format(
                "{0} / {1}",
                totalEstimatedIncome.FormatCurrency(),
                totalExpectedIncome.FormatCurrency());
        }

        private IEnumerable<MarketOrder> SortMarketOrders(IEnumerable<MarketOrder> marketOrders, Func<MarketOrder, object> groupBy, Func<MarketOrder, object> orderBy, bool ascending)
        {
            IEnumerable<Core.DomainModel.MarketOrder> sortedMarketOrders;
            
            if (groupBy == null)
            {
                if (ascending)
                {
                    sortedMarketOrders = marketOrders.OrderBy(orderBy);
                }
                else
                {
                    sortedMarketOrders = marketOrders.OrderByDescending(orderBy);
                }
            }
            else
            {
                if (ascending)
                {
                    sortedMarketOrders = marketOrders.OrderBy(groupBy).ThenBy(orderBy);
                }
                else
                {
                    sortedMarketOrders = marketOrders.OrderBy(groupBy).ThenByDescending(orderBy);
                }
            }

            return sortedMarketOrders;
        }
        private IEnumerable<MarketOrder> FilterMarketOrders(IEnumerable<MarketOrder> marketOrders, string keyword)
        {
            keyword = keyword.ToLower();
            IEnumerable<Core.DomainModel.MarketOrder> filteredMarketOrders;

            filteredMarketOrders = marketOrders.Where(
                order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name.ToLower().Contains(keyword) ||
                         Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeID).Name.ToLower().Contains(keyword));

            return filteredMarketOrders;
        }

        private void CharactersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RenderMarketOrders();
        }
        private void SellOrdersListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.SetSorting(e.Column);
            this.RenderMarketOrders();
        }
        private void BuyOrdersListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.SetSorting(e.Column);
            this.RenderMarketOrders();
        }
        private void SetSorting(int columnIndex)
        {
            this.SetSorting(columnIndex, true);
        }
        private void SetSorting(int columnIndex, bool changeSorting)
        {
            if (changeSorting)
            {
                if (columnIndex == this.iLastClickedColumnHeaderIndex)
                {
                    iSortAscending = !iSortAscending;
                }
                else
                {
                    this.iLastClickedColumnHeaderIndex = columnIndex;
                    iSortAscending = false;
                }
            }

            switch (columnIndex)
            {
                case 0:
                    iOrderByKey = (order => order.OrderState);
                    break;
                
                case 1:
                    iOrderByKey = (order => Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeID).Name);
                    break;

                case 2:
                    iOrderByKey = (order => order.Price);
                    break;

                case 3:
                    iOrderByKey = (order => order.VolumeRemaining);
                    break;

                case 4:
                    iOrderByKey = (order => order.VolumeRemaining * order.Price);
                    break;

                case 5:
                    iOrderByKey = (order => order.GetEtcb());
                    break;

                case 6:
                    iOrderByKey = (order => order.GetEstimatedSoldAmount());
                    break;

                case 7:
                    iOrderByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name);
                    break;

                case 8:
                    iOrderByKey = (order => order.Duration - (DateTime.Now - order.Issued).Days);
                    break;

                default:
                    return;
            }
            
        }

        private void GroupByProductRadioButton_Click(object sender, EventArgs e)
        {
            this.iGroupByKey = (order => Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeID).Name);
            this.RenderMarketOrders();
        }
        private void GroupBySolarSystemRadioButton_Click(object sender, EventArgs e)
        {
            this.iGroupByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationID).Name);
            this.RenderMarketOrders();
        }
        private void DoNotGroupRadioButton_Click(object sender, EventArgs e)
        {
            this.iGroupByKey = null;
            this.RenderMarketOrders();
        }

        private void FilterByTextBox_TextChanged(object sender, EventArgs e)
        {
            this.RenderMarketOrders();
        }
        private void filterByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.BuyOrdersListView.SelectedItems.Count == 1)
            {
                this.FilterByTextBox.Text = this.BuyOrdersListView.SelectedItems[0].SubItems[1].Text;
                this.RenderMarketOrders();
                return;
            }
            else if (this.SellOrdersListView.SelectedItems.Count == 1)
            {
                this.FilterByTextBox.Text = this.SellOrdersListView.SelectedItems[0].SubItems[1].Text;
                this.RenderMarketOrders();
                return;
            }
        }
        private void filterBySolarSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.BuyOrdersListView.SelectedItems.Count == 1)
            {
                string text =this.BuyOrdersListView.SelectedItems[0].SubItems[7].Text;
                this.FilterByTextBox.Text = text.Substring(0, text.IndexOf(" "));
                this.RenderMarketOrders();
                return;
            }
            else if (this.SellOrdersListView.SelectedItems.Count == 1)
            {
                string text =this.SellOrdersListView.SelectedItems[0].SubItems[7].Text;
                this.FilterByTextBox.Text = text.Substring(0, text.IndexOf(" "));
                this.RenderMarketOrders();
                return;
            }
        }
        private void filterByStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.BuyOrdersListView.SelectedItems.Count == 1)
            {
                this.FilterByTextBox.Text = this.BuyOrdersListView.SelectedItems[0].SubItems[7].Text;
                this.RenderMarketOrders();
                return;
            }
            else if (this.SellOrdersListView.SelectedItems.Count == 1)
            {
                this.FilterByTextBox.Text = this.SellOrdersListView.SelectedItems[0].SubItems[7].Text;
                this.RenderMarketOrders();
                return;
            }
        }

        private void FilterByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1)
            {
                this.FilterByTextBox.SelectionStart = 0;
                this.FilterByTextBox.SelectionLength = this.FilterByTextBox.Text.Length;
            }
        }

        private void cbHideExpired_CheckedChanged(object sender, EventArgs e)
        {
            this.iHideExpired = (sender as CheckBox).Checked;
            UISettings.Instance.OrderSettings.HideExpiredOrders = this.iHideExpired;
            this.RenderMarketOrders();
        }
    }
}
