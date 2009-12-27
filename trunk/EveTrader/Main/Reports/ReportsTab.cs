using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Core.DomainModel;

namespace EveTrader.Main.Reports
{
    public partial class ReportsTab : UserControl
    {
        private DateTime fromDate = DateTime.Now.Date.AddDays(-6);

        public bool ReInitialize { get; set; }

        private struct ReportChartItem
        {
            public string Label { get; set; }
            public double Value1 { get; set; }
            public double Value2 { get; set; }
        }

        public ReportsTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.RenderReports();
        }

        public void RenderReports()
        {
            this.Cursor = Cursors.WaitCursor;

            IEnumerable<WalletTransaction> unitedWalletTransactions = Analysis.Data.GetUnitedWalletTransactions().Where( t => t.Ignore == false );
            IEnumerable<WalletTransaction> filteredWalletTransactions = unitedWalletTransactions.Where(wt => wt.TransactionDateTime.Date >= fromDate && wt.TransactionType == WalletTransactionType.Sell);
            
            IEnumerable<ReportChartItem> mostProfitableProducts = this.MostProfitableProductsList(unitedWalletTransactions, filteredWalletTransactions);
            IEnumerable<ReportChartItem> mostProfitableStations = this.MostProfitableStationsList(unitedWalletTransactions, filteredWalletTransactions);
            IEnumerable<ReportChartItem> mostProfitableClients = this.MostProfitableClientsList(unitedWalletTransactions, filteredWalletTransactions);
            
            this.RenderMostProfitableProductsChart(mostProfitableProducts);
            this.RenderMostProfitableStationsChart(mostProfitableStations);
            this.RenderMostProfitableClientsChart(mostProfitableClients);
            this.RenderBalanceHistory(this.BalanceHistoryList(Settings.Instance.Characters.First().BalanceHistory));

            this.Cursor = Cursors.Default;
        }

        private void RenderMostProfitableProductsChart(IEnumerable<ReportChartItem> reportItems)
        {
            this.MostProfitableProductsChart.Series[1].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value1");

            this.MostProfitableProductsChart.Series[0].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value2");

            this.MostProfitableProductsChart.ResetAutoValues();
        }
        private void RenderMostProfitableStationsChart(IEnumerable<ReportChartItem> reportItems)
        {
            this.MostProfitableStationsChart.Series[1].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value1");

            this.MostProfitableStationsChart.Series[0].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value2");

            this.MostProfitableStationsChart.ResetAutoValues();
        }
        private void RenderMostProfitableClientsChart(IEnumerable<ReportChartItem> reportItems)
        {

            this.MostProfitableClientsChart.Series[1].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value1");

            this.MostProfitableClientsChart.Series[0].Points.DataBindXY(
                    reportItems,
                    "Label",
                    reportItems,
                    "Value2");

            this.MostProfitableClientsChart.ResetAutoValues();
        }
        private void RenderBalanceHistory(IEnumerable<ReportChartItem> reportItems)
        {
            this.BalanceHistory.Series[0].Points.DataBindXY(reportItems, "Label", reportItems, "Value1");
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
                    Value1 = Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax) * gi.Quantity / 1000000), 2),
                    Value2 = Math.Round(g.Sum(gi => ((gi.Price - gi.SalesTax) - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };

            return reportData.OrderByDescending ( ri => ri.Value2 ).Take(15).OrderBy( ri => ri.Value2 ).ToList();
        }
        private IEnumerable<ReportChartItem> MostProfitableStationsList(IEnumerable<WalletTransaction> walletTransactions, IEnumerable<WalletTransaction> filteredWalletTransactions)
        {
            IEnumerable<ReportChartItem> reportData =
                from wt in filteredWalletTransactions
                group wt by wt.StationName into g
                select new ReportChartItem
                {
                    Label = g.Key,
                    Value1 = Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax) * gi.Quantity / 1000000), 2),
                    Value2 = Math.Round(g.Sum(gi => ((gi.Price - gi.SalesTax) - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };

            return reportData.OrderByDescending(ri => ri.Value2).Take(15).OrderBy(ri => ri.Value2).ToList();
        }
        private IEnumerable<ReportChartItem> MostProfitableClientsList(IEnumerable<WalletTransaction> walletTransactions, IEnumerable<WalletTransaction> filteredWalletTransactions)
        {
            IEnumerable<ReportChartItem> reportData =
                from wt in filteredWalletTransactions
                group wt by wt.ClientName into g
                select new ReportChartItem
                {
                    Label = g.Key,
                    Value1 = Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax) * gi.Quantity / 1000000), 2),
                    Value2 = Math.Round(g.Sum(gi => ((gi.Price - gi.SalesTax) - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };

            return reportData.OrderByDescending(ri => ri.Value2).Take(15).OrderBy(ri => ri.Value2).ToList();
        }
        private IEnumerable<ReportChartItem> BalanceHistoryList(IEnumerable<WalletHistory> history)
        {
            IEnumerable<ReportChartItem> reportData =
                (from wh in history
                 orderby wh.Key
                 select new ReportChartItem
                            {
                                Label = wh.Key.ToString(),
                                Value1 = wh.Value,
                                Value2 = 0
                            });
            return reportData.ToList();
            
        }

        private void ShowForLastWeek_Click(object sender, EventArgs e)
        {
            this.fromDate = DateTime.Now.Date.AddDays(-6);
            this.Initialize();
        }
        private void ShowFor30Days_Click(object sender, EventArgs e)
        {
            this.fromDate = DateTime.Now.Date.AddDays(-29);
            this.Initialize();
        }
        private void ShowForLast3Month_Click(object sender, EventArgs e)
        {
            this.fromDate = DateTime.Now.Date.AddMonths(-3);
            this.Initialize();
        }
        private void ShowAll_Click(object sender, EventArgs e)
        {
            this.fromDate = DateTime.MinValue;
            this.Initialize();
        }
    }
}
