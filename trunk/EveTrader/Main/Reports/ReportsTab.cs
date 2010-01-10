using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.DomainModel;
using Dundas.Charting.WinControl;

namespace EveTrader.Main.Reports
{
    public partial class ReportsTab : UserControl
    {
        private DateTime iFromDate = DateTime.Now.Date.AddDays(-6);
        private int iItemsDisplayed = 15;
        private bool iAutoApply = false;

        public bool ReInitialize { get; set; }

        private struct ReportChartItem
        {
            public string Label { get; set; }
            public double GrossSales { get; set; }
            public double PureProfit { get; set; }
            public double SalesTax { get; set; }
        }
        private class BalanceChartItem
        {
            public DateTime Key { get; set; }
            public double Value { get; set; }
        }
        private class CharacterBalance
        {
            public string Key { get; set; }
            public List<BalanceChartItem> Values { get; set; }
        }

        public ReportsTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.iItemsDisplayed = UISettings.Instance.ReportSettings.ItemsDisplayed;
            this.iAutoApply = UISettings.Instance.ReportSettings.AutomaticApply;

            this.tbItemsDisplayed.Text = this.iItemsDisplayed.ToString();
            this.cbAutomaticApply.Checked = this.iAutoApply;

            this.RenderReports();
        }

        private void RenderReports()
        {
            this.Cursor = Cursors.WaitCursor;

            IEnumerable<WalletTransaction> unitedWalletTransactions = Analysis.Data.GetUnitedWalletTransactions().Where( t => t.Ignore == false );
            IEnumerable<WalletTransaction> filteredWalletTransactions = unitedWalletTransactions.Where(wt => wt.TransactionDateTime.Date >= iFromDate && wt.TransactionType == WalletTransactionType.Sell);
            
            IEnumerable<ReportChartItem> mostProfitableProducts = this.MostProfitableProductsList(unitedWalletTransactions, filteredWalletTransactions);
            IEnumerable<ReportChartItem> mostProfitableStations = this.MostProfitableStationsList(unitedWalletTransactions, filteredWalletTransactions);
            IEnumerable<ReportChartItem> mostProfitableClients = this.MostProfitableClientsList(unitedWalletTransactions, filteredWalletTransactions);
            
            this.RenderMostProfitableProductsChart(mostProfitableProducts);
            this.RenderMostProfitableStationsChart(mostProfitableStations);
            this.RenderMostProfitableClientsChart(mostProfitableClients);
            this.RenderBalanceHistory(this.BalanceHistoryList(Settings.Instance.Characters));

            this.Cursor = Cursors.Default;
        }

        private void RenderMostProfitableProductsChart(IEnumerable<ReportChartItem> reportItems)
        {
            this.MostProfitableProductsChart.Titles[0].Text = string.Format("Top {0} most profitable products",
                                                                            this.iItemsDisplayed);


            this.MostProfitableProductsChart.Series[0].Points.DataBindXY(
                reportItems,
                "Label",
                reportItems,
                "PureProfit");

            this.MostProfitableProductsChart.Series[1].Points.DataBindXY(
                reportItems,
                "Label",
                reportItems,
                "GrossSales");

            this.MostProfitableProductsChart.Series[2].Points.DataBindXY(
                reportItems,
                "Label",
                reportItems,
                "SalesTax");

            this.MostProfitableProductsChart.ResetAutoValues();
        }

        private void RenderMostProfitableStationsChart(IEnumerable<ReportChartItem> reportItems)
        {
            this.MostProfitableStationsChart.Titles[0].Text = string.Format("Top {0} most profitable stations",
                                                                            this.iItemsDisplayed);
            this.MostProfitableStationsChart.Series[1].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "GrossSales");

            this.MostProfitableStationsChart.Series[0].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "PureProfit");

            this.MostProfitableStationsChart.ResetAutoValues();
        }
        private void RenderMostProfitableClientsChart(IEnumerable<ReportChartItem> reportItems)
        {
            this.MostProfitableClientsChart.Titles[0].Text = string.Format("Top {0} most profitable clients",
                                                                this.iItemsDisplayed);
            this.MostProfitableClientsChart.Series[1].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "GrossSales");

            this.MostProfitableClientsChart.Series[0].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "PureProfit");

            this.MostProfitableClientsChart.ResetAutoValues();
        }
        private void RenderBalanceHistory(IEnumerable<CharacterBalance> reportItems)
        {
            this.BalanceHistory.Series.Clear();
            foreach(CharacterBalance er in reportItems)
            {
                Series s = this.BalanceHistory.Series.Add(er.Key);

                s.XValueType = ChartValueTypes.DateTime;
                s.YValueType = ChartValueTypes.Double;
                s.Type = SeriesChartType.StepLine;
                s.PaletteCustomColors = new System.Drawing.Color[] { };
                s.ShadowOffset = 1;
                s.BorderWidth = 2;
                s.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;

                s.Points.DataBindXY(er.Values, "Key", er.Values, "Value"); 
            }
            
            this.BalanceHistory.ResetAutoValues();
        }

        private IEnumerable<ReportChartItem> MostProfitableProductsList(IEnumerable<WalletTransaction> walletTransactions, IEnumerable<WalletTransaction> filteredWalletTransactions)
        {
            IEnumerable<ReportChartItem> reportData =
                from wt in filteredWalletTransactions
                group wt by wt.TypeName into g
                select new ReportChartItem
                {
                    Label = string.Format(
                        "{0} x{1}", 
                        g.Key, 
                        g.Sum(gi => gi.Quantity)),
                    GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                    PureProfit = Math.Round(g.Sum(gi => (gi.Price  - gi.SalesTax - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2),
                    SalesTax = Math.Round(g.Sum(gi => gi.SalesTax * gi.Quantity / 1000000), 2)
                };

            return reportData.OrderByDescending ( ri => ri.PureProfit ).Take(this.iItemsDisplayed).OrderBy( ri => ri.PureProfit ).ToList();
        }
        private IEnumerable<ReportChartItem> MostProfitableStationsList(IEnumerable<WalletTransaction> walletTransactions, IEnumerable<WalletTransaction> filteredWalletTransactions)
        {
            IEnumerable<ReportChartItem> reportData =
                from wt in filteredWalletTransactions
                group wt by wt.StationName into g
                select new ReportChartItem
                {
                    Label = g.Key,
                    GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                    PureProfit = Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };

            return reportData.OrderByDescending(ri => ri.PureProfit).Take(this.iItemsDisplayed).OrderBy(ri => ri.PureProfit).ToList();
        }
        private IEnumerable<ReportChartItem> MostProfitableClientsList(IEnumerable<WalletTransaction> walletTransactions, IEnumerable<WalletTransaction> filteredWalletTransactions)
        {
            IEnumerable<ReportChartItem> reportData =
                from wt in filteredWalletTransactions
                group wt by wt.ClientName into g
                select new ReportChartItem
                {
                    Label = g.Key,
                    GrossSales = Math.Round(g.Sum(gi => (gi.Price * gi.Quantity) / 1000000), 2),
                    PureProfit = Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };

            return reportData.OrderByDescending(ri => ri.PureProfit).Take(this.iItemsDisplayed).OrderBy(ri => ri.PureProfit).ToList();
        }
        private IEnumerable<CharacterBalance> BalanceHistoryList(IEnumerable<Character> characters)
        {
            List<CharacterBalance> output = new List<CharacterBalance>();
            foreach(Character c in characters)
            {
                CharacterBalance cb = new CharacterBalance();
                cb.Key = c.Name;

                cb.Values = (from wh in c.BalanceHistory
                             where wh.Key > this.iFromDate
                             orderby wh.Key
                             select new BalanceChartItem()
                                        {
                                            Key = wh.Key,
                                            Value = wh.Value
                                        }).ToList();
                output.Add(cb);
            }

            return output;
        }

        private void ShowForLastWeek_Click(object sender, EventArgs e)
        {
            this.iFromDate = DateTime.Now.Date.AddDays(-6);
            this.Initialize();
        }
        private void ShowFor30Days_Click(object sender, EventArgs e)
        {
            this.iFromDate = DateTime.Now.Date.AddDays(-29);
            this.Initialize();
        }
        private void ShowForLast3Month_Click(object sender, EventArgs e)
        {
            this.iFromDate = DateTime.Now.Date.AddMonths(-3);
            this.Initialize();
        }
        private void ShowAll_Click(object sender, EventArgs e)
        {
            this.iFromDate = DateTime.MinValue;
            this.Initialize();
        }

        private void ChangeItemDisplayCount()
        {
            int count;
            if(int.TryParse(tbItemsDisplayed.Text, out count))
            {
                this.iItemsDisplayed = count;
                UISettings.Instance.ReportSettings.ItemsDisplayed = count;
                this.Initialize();
            }
        }

        private void tbItemsDisplayed_TextChanged(object sender, EventArgs e)
        {
            if (this.iAutoApply)
                this.ChangeItemDisplayCount();
        }
        private void cbAutomaticApply_CheckedChanged(object sender, EventArgs e)
        {
            this.iAutoApply = (sender as CheckBox).Checked;
            UISettings.Instance.ReportSettings.AutomaticApply = this.iAutoApply;
            this.ChangeItemDisplayCount();
        }
        private void btApply_Click(object sender, EventArgs e)
        {
            this.ChangeItemDisplayCount();
        }
    }
}
