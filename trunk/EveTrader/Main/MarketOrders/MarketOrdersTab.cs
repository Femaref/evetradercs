using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Core.Updaters;
using Core.DomainModel;
using Core.ClassExtenders;
using EveTrader.Analysis;
using EveTrader.Helpers;
using EveTrader.Main.Reports;
using MarketOrder=EveTrader.Analysis.MarketOrders;
using Settings=EveTrader.Settings;

namespace EveTrader.Main.MarketOrders
{
    public partial class MarketOrdersTab : UserControl
    {
        private int lastClickedColumnHeaderIndex = -1;
        private bool sortAscending;
        Func<Core.DomainModel.MarketOrder, object> orderByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationId).Name);
        Func<Core.DomainModel.MarketOrder, object> groupByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationId).Name);

        public MarketOrdersTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.CharactersComboBox.Items.Clear();
            this.BuyOrdersListView.Columns.Clear();

            foreach (Character character in Settings.Instance.Characters)
            {
                CharactersComboBox.Items.Add(character);
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
                n ++;
            }
        }
        public void RenderMarketOrders()
        {
            Character selectedCharacter = (Character) this.CharactersComboBox.SelectedItem;
            this.RenderMarketOrders(selectedCharacter);
        }
        public void RenderMarketOrders(Character character)
        {
            IEnumerable<Core.DomainModel.MarketOrder> marketOrders = character.MarketOrders;
            IEnumerable<WalletTransaction> walletTransactions = character.WalletTransactions;

            marketOrders = this.SortMarketOrders(marketOrders, this.groupByKey, this.orderByKey, this.sortAscending);
            marketOrders = this.FilterMarketOrders(marketOrders, this.FilterByTextBox.Text);

            this.BuyOrdersListView.Items.Clear();
            this.SellOrdersListView.Items.Clear();

            double totalExpectedExcrow = 0;
            double totalEstimatedExcrow = 0;
            double totalExpectedIncome = 0;
            double totalEstimatedIncome = 0;

            ListViewGroup activeSellGroup = null;
            ListViewGroup activeBuyGroup = null;
            int prevSellGroupId = -1;
            int prevBuyGroupId = -1;

            foreach (Core.DomainModel.MarketOrder marketOrder in marketOrders)
            {
                if (this.GroupByProductRadioButton.Checked)
                {
                    if (marketOrder.Type == MarketOrderType.Sell)
                    {
                        if (prevSellGroupId != marketOrder.TypeId)
                        {
                            activeSellGroup =
                                new ListViewGroup(
                                    Core.Resources.Instance.EveObjects.Types.GetTypeById(marketOrder.TypeId).Name);
                            prevSellGroupId = marketOrder.TypeId;
                            this.SellOrdersListView.Groups.Add(activeSellGroup);
                        }
                    }
                    else
                    {
                        if (prevBuyGroupId != marketOrder.TypeId)
                        {
                            activeBuyGroup =
                                new ListViewGroup(
                                    Core.Resources.Instance.EveObjects.Types.GetTypeById(marketOrder.TypeId).Name);
                            prevBuyGroupId = marketOrder.TypeId;
                            this.BuyOrdersListView.Groups.Add(activeBuyGroup);
                        }
                    }
                }
                else if (this.GroupBySolarSystemRadioButton.Checked)
                {
                    if (marketOrder.Type == MarketOrderType.Sell)
                    {
                        if (prevSellGroupId != marketOrder.StationId)
                        {
                            activeSellGroup =
                                new ListViewGroup(
                                    Core.Resources.Instance.EveObjects.Stations.GetStationById(marketOrder.StationId).Name);
                            prevSellGroupId = marketOrder.StationId;
                            this.SellOrdersListView.Groups.Add(activeSellGroup);
                        }
                    }
                    else
                    {
                        if (prevBuyGroupId != marketOrder.StationId)
                        {
                            activeBuyGroup =
                                new ListViewGroup(
                                    Core.Resources.Instance.EveObjects.Stations.GetStationById(marketOrder.StationId).Name);
                            prevBuyGroupId = marketOrder.StationId;
                            this.BuyOrdersListView.Groups.Add(activeBuyGroup);
                        }
                    }
                }

                MarketOrderListViewItem item = MarketOrderListViewItem.Create(
                    marketOrder,  
                    marketOrder.Type == MarketOrderType.Sell ? 
                        activeSellGroup : 
                        activeBuyGroup);

                Font itemFont = new Font(item.Font, item.MarketOrder.Ignore ? FontStyle.Strikeout : FontStyle.Regular);

                item.UseItemStyleForSubItems = false;
                item.Font = itemFont;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    subItem.Font = itemFont;
                }

                switch (marketOrder.Type)
                {
                    case MarketOrderType.Buy:
                        item.SubItems[4].ForeColor = Color.Goldenrod;
                        item.SubItems[6].ForeColor = Color.Goldenrod;
                        this.BuyOrdersListView.Items.Add(item);
                        totalExpectedExcrow += marketOrder.Escrow;
                        totalEstimatedExcrow += MarketOrder.GetEstimatedSoldAmount(marketOrder);
                        break;

                    case MarketOrderType.Sell:
                        item.SubItems[4].ForeColor = Color.ForestGreen;
                        item.SubItems[6].ForeColor = Color.ForestGreen;
                        this.SellOrdersListView.Items.Add(item);
                        totalExpectedIncome += (marketOrder.VolumeRemaining * marketOrder.Price);
                        totalEstimatedIncome += MarketOrder.GetEstimatedSoldAmount(marketOrder);
                        break;
                }
            }

            this.TotalInExcrowLabel.Text = string.Format(
                "{0} / {1}", 
                totalEstimatedExcrow.FormatCurrency(),
                totalExpectedExcrow.FormatCurrency());

            this.TotalIncomeLabel.Text = string.Format(
                "{0} / {1}", 
                totalEstimatedIncome.FormatCurrency(),
                totalExpectedIncome.FormatCurrency());
        }

        private IEnumerable<Core.DomainModel.MarketOrder> SortMarketOrders(IEnumerable<Core.DomainModel.MarketOrder> marketOrders, Func<Core.DomainModel.MarketOrder, object> key1, Func<Core.DomainModel.MarketOrder, object> key2, bool ascending)
        {
            IEnumerable<Core.DomainModel.MarketOrder> sortedMarketOrders;
            
            if (key1 == null)
            {
                if (ascending)
                {
                    sortedMarketOrders = marketOrders.OrderBy(key2);
                }
                else
                {
                    sortedMarketOrders = marketOrders.OrderByDescending(key2);
                }
            }
            else
            {
                if (ascending)
                {
                    sortedMarketOrders = marketOrders.OrderBy(key1).ThenBy(key2);
                }
                else
                {
                    sortedMarketOrders = marketOrders.OrderBy(key1).ThenByDescending(key2);
                }
            }

            return sortedMarketOrders;
        }
        private IEnumerable<Core.DomainModel.MarketOrder> FilterMarketOrders(IEnumerable<Core.DomainModel.MarketOrder> marketOrders, string keyword)
        {
            keyword = keyword.ToLower();
            IEnumerable<Core.DomainModel.MarketOrder> filteredMarketOrders;

            filteredMarketOrders = marketOrders.Where(
                order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationId).Name.ToLower().Contains(keyword) ||
                         Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeId).Name.ToLower().Contains(keyword));

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
                if (columnIndex == this.lastClickedColumnHeaderIndex)
                {
                    sortAscending = !sortAscending;
                }
                else
                {
                    this.lastClickedColumnHeaderIndex = columnIndex;
                    sortAscending = false;
                }
            }

            switch (columnIndex)
            {
                case 0:
                    orderByKey = (order => order.OrderState);
                    break;
                
                case 1:
                    orderByKey = (order => Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeId).Name);
                    break;

                case 2:
                    orderByKey = (order => order.Price);
                    break;

                case 3:
                    orderByKey = (order => order.VolumeRemaining);
                    break;

                case 4:
                    orderByKey = (order => order.VolumeRemaining * order.Price);
                    break;

                case 5:
                    orderByKey = (order => MarketOrder.GetEtcb(order));
                    break;

                case 6:
                    orderByKey = (order => MarketOrder.GetEstimatedSoldAmount(order));
                    break;

                case 7:
                    orderByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationId).Name);
                    break;

                case 8:
                    orderByKey = (order => order.Duration - (DateTime.Now - order.Issued).Days);
                    break;

                default:
                    return;
            }
            
        }

        private void GroupByProductRadioButton_Click(object sender, EventArgs e)
        {
            this.groupByKey = (order => Core.Resources.Instance.EveObjects.Types.GetTypeById(order.TypeId).Name);
            this.RenderMarketOrders();
        }
        private void GroupBySolarSystemRadioButton_Click(object sender, EventArgs e)
        {
            this.groupByKey = (order => Core.Resources.Instance.EveObjects.Stations.GetStationById(order.StationId).Name);
            this.RenderMarketOrders();
        }

        private void DoNotGroupRadioButton_Click(object sender, EventArgs e)
        {
            this.groupByKey = null;
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
    }
}
