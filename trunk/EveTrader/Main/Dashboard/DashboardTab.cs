using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dundas.Charting.WinControl;
using Core.DomainModel;
using Core.Updaters;
using Core.ClassExtenders;
using EveTrader.Main.Reports;
using EveTrader.Main.Reports;
using Settings=EveTrader.Settings;
using System.Threading;

namespace EveTrader.Main.Dashboard
{
    public partial class DashboardTab : UserControl
    {
        private bool showTotalLabels = true;
        private bool showProfitLabels = true;
        private bool showInvestmentLabels = false;
        private bool showDetailedLabeles = false;

        public bool ReInitialize { get; set; }

        private struct DashboardChartItem
        {
            public DateTime Date { get; set; }
            public string Label { get; set; }
            public double Value { get; set; }
        }

        public DashboardTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            Control[] controls = this.ShowSalesPanel.Controls.Find(string.Format("SalesAmount{0}", UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount), false);
            
            if (controls.Length > 0)
            {
                RadioButton radioButton = (RadioButton) controls[0];
                radioButton.Checked = true;
            }

            this.RenderSalesAmountChart();

        }

        private void RenderSalesAmountChart()
        {
            this.SalesAmountChart.Series.Clear();
            IEnumerable<DashboardChartItem> reportData;

            foreach (Character character in Settings.Instance.Characters)
            {
                this.SalesAmountChart.Series.Add(character.Name);
                reportData = this.GetSalesAmount(character.WalletJournal);
                this.SalesAmountChart.Series[character.Name].Type = SeriesChartType.StackedColumn;
                this.SalesAmountChart.Series[character.Name].ShowLabelAsValue = showDetailedLabeles;
                this.SalesAmountChart.Series[character.Name]["StackedGroupName"] = "General";
                this.SalesAmountChart.Series[character.Name].ShadowOffset = 2;
                this.SalesAmountChart.Series[character.Name].CustomAttributes = "LabelStyle=BottomCenter";
                this.SalesAmountChart.Series[character.Name].Points.DataBindXY(
                    reportData,
                    "Label",
                    reportData,
                    "Value");
            }

            reportData = GetSalesAmount(Settings.Instance.Characters);
            this.SalesAmountChart.Series.Add("Total");
            this.SalesAmountChart.Series["Total"].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
            this.SalesAmountChart.Series["Total"].ChartType = "Point";
            this.SalesAmountChart.Series["Total"].Color = System.Drawing.Color.WhiteSmoke;
            this.SalesAmountChart.Series["Total"].MarkerBorderColor = System.Drawing.Color.Black;
            this.SalesAmountChart.Series["Total"].MarkerSize = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 8 ? 5 : 9;
            this.SalesAmountChart.Series["Total"].FontColor = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 14 ? Color.Gray : Color.Black;
            this.SalesAmountChart.Series["Total"].MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
            this.SalesAmountChart.Series["Total"].Name = "Total";
            this.SalesAmountChart.Series["Total"].PaletteCustomColors = new System.Drawing.Color[0];
            this.SalesAmountChart.Series["Total"].ShadowOffset = 2;
            this.SalesAmountChart.Series["Total"].ShowLabelAsValue = showTotalLabels;
            this.SalesAmountChart.Series["Total"].Points.DataBindXY(
                    reportData,
                    "Label",
                    reportData,
                    "Value");

            
            reportData = this.GetInvestmentsAmount();
            this.SalesAmountChart.Series.Add("Daily investments");
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.Enabled = true;
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.CalloutLineAnchorCap = LineAnchorCap.Diamond;
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.CalloutLineColor = Color.Crimson;
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.CalloutLineWidth = 2;
            this.SalesAmountChart.Series["Daily investments"].SmartLabels.CalloutStyle = LabelCalloutStyle.Box;
            this.SalesAmountChart.Series["Daily investments"].BorderColor = Color.FromArgb(
                this.showInvestmentLabels ? 255 : 100,
                Color.OrangeRed.R,
                Color.OrangeRed.G,
                Color.OrangeRed.B);
            this.SalesAmountChart.Series["Daily investments"].ChartType = "Line";
            this.SalesAmountChart.Series["Daily investments"].Color = Color.FromArgb(
                this.showInvestmentLabels ? 255 : 100,   
                Color.OrangeRed.R,
                Color.OrangeRed.G,
                Color.OrangeRed.B);
            this.SalesAmountChart.Series["Daily investments"].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SalesAmountChart.Series["Daily investments"].FontColor = System.Drawing.Color.Black;
            this.SalesAmountChart.Series["Daily investments"].MarkerSize = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 14 ? 5 : 9;;
            this.SalesAmountChart.Series["Daily investments"].MarkerBorderColor = Color.FromArgb(
                this.showInvestmentLabels ? 255 : 100,
                Color.Crimson.R,
                Color.Crimson.G,
                Color.Crimson.B);
            this.SalesAmountChart.Series["Daily investments"].MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            this.SalesAmountChart.Series["Daily investments"].Name = "Daily investments";
            this.SalesAmountChart.Series["Daily investments"].PaletteCustomColors = new System.Drawing.Color[0];
            this.SalesAmountChart.Series["Daily investments"].ShadowOffset = this.showInvestmentLabels ? 2 : 0;
            this.SalesAmountChart.Series["Daily investments"].BorderWidth = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount <= 14 ? 3 : this.showInvestmentLabels ? 2 : 1;
            this.SalesAmountChart.Series["Daily investments"].CustomAttributes = "LabelStyle=Right";
            this.SalesAmountChart.Series["Daily investments"].ShowLabelAsValue = showInvestmentLabels;
            this.SalesAmountChart.Series["Daily investments"].Points.DataBindXY(
                    reportData,
                    "Label",
                    reportData,
                    "Value");

            reportData = this.GetSalesProfitAmount();
            this.SalesAmountChart.Series.Add("Daily profit");
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.Enabled = true;
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.CalloutLineAnchorCap = LineAnchorCap.Diamond;
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.CalloutLineColor = Color.OliveDrab;
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.CalloutLineWidth = 2;
            this.SalesAmountChart.Series["Daily profit"].SmartLabels.CalloutStyle = LabelCalloutStyle.Box;
            this.SalesAmountChart.Series["Daily profit"].BorderColor = Color.FromArgb(
                this.showProfitLabels ? 255 : 100,   
                Color.GreenYellow.R,
                Color.GreenYellow.G,
                Color.GreenYellow.B);
            this.SalesAmountChart.Series["Daily profit"].ChartType = "Line";
            this.SalesAmountChart.Series["Daily profit"].Color = Color.FromArgb(
                this.showProfitLabels ? 255 : 100,  
                Color.GreenYellow.R,
                Color.GreenYellow.G,
                Color.GreenYellow.B);
            this.SalesAmountChart.Series["Daily profit"].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SalesAmountChart.Series["Daily profit"].FontColor = System.Drawing.Color.Black;
            this.SalesAmountChart.Series["Daily profit"].MarkerSize = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 14 ? 5 : 9;;
            this.SalesAmountChart.Series["Daily profit"].MarkerBorderColor = Color.FromArgb(
                this.showProfitLabels ? 255 : 100,    
                Color.OliveDrab.R,
                Color.OliveDrab.G,
                Color.OliveDrab.B);
            this.SalesAmountChart.Series["Daily profit"].MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            this.SalesAmountChart.Series["Daily profit"].Name = "Daily profit";
            this.SalesAmountChart.Series["Daily profit"].PaletteCustomColors = new System.Drawing.Color[0];
            this.SalesAmountChart.Series["Daily profit"].ShadowOffset = this.showProfitLabels ? 2 : 0;
            this.SalesAmountChart.Series["Daily profit"].BorderWidth = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount <= 14 ? 3 : this.showProfitLabels ? 2 : 1;
            this.SalesAmountChart.Series["Daily profit"].CustomAttributes = "LabelStyle=Right";
            this.SalesAmountChart.Series["Daily profit"].ShowLabelAsValue = showProfitLabels;
            this.SalesAmountChart.Series["Daily profit"].Points.DataBindXY(
                    reportData,
                    "Label",
                    reportData,
                    "Value");

            
            

        }
        private void RenderSalesDetailsChart(IEnumerable<DashboardChartItem> sales)
        {
            this.RenderSalesDetailsChart(sales, null, null);
        }
        private void RenderSalesDetailsChart(IEnumerable<DashboardChartItem> sales, IEnumerable<DashboardChartItem> profit, IEnumerable<DashboardChartItem> investments)
        {
            this.SalesDetailsChart.AntiAliasing = AntiAliasing.All;
            this.SalesDetailsChart.TextAntiAliasingQuality = TextAntiAliasingQuality.High; 

            if (sales == null)
            {
                this.SalesDetailsChart.Series["Sales amount"].Points.Clear();
            }
            else
            {
                this.SalesDetailsChart.Series["Sales amount"].Points.DataBindXY(
                    sales,
                    "Label",
                    sales,
                    "Value");
            }

            if (profit == null)
            {
                this.SalesDetailsChart.Series["Profit"].Points.Clear();
            }
            else
            {
                this.SalesDetailsChart.Series["Profit"].Points.DataBindXY(
                    profit,
                    "Label",
                    profit,
                    "Value");
            }

            if (investments == null)
            {
                this.SalesDetailsChart.Series["Investments"].Points.Clear();
            }
            else
            {
                this.SalesDetailsChart.Series["Investments"].Points.DataBindXY(
                    investments,
                    "Label",
                    investments,
                    "Value");
            }
        }

        private IEnumerable<DashboardChartItem> GetSalesAmount(IEnumerable<Character> characters)
        {
            IList<WalletJournalRecord> walletJournal = new List<WalletJournalRecord>();

            foreach (Character character in characters)
            {
                walletJournal = walletJournal.Union(
                    character.WalletJournal.Where(
                        wjr => wjr.Ignore == false)
                    ).ToList();
            }

            return this.GetSalesAmount(walletJournal);
        }
        private IEnumerable<DashboardChartItem> GetSalesAmount(IList<WalletJournalRecord> walletJournal)
        {
            IList<DashboardChartItem> reportData = new List<DashboardChartItem>();

            for (int day = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount; day >= 0; day--)
            {
                DateTime date = DateTime.Now.Date.AddDays(-day);
                double value = walletJournal
                    .Where(r =>
                        r.Date.Date == DateTime.Now.Date.AddDays(-day) &&
                        r.Amount > 0 &&
                        r.ReferenceTypeId == 2 &&
                        r.Ignore == false)
                    .Sum(r => r.Amount) / 1000000;

                reportData.Add(
                    new DashboardChartItem
                    {
                        Date = date,
                        Label = date.ToString("MMM dd"),
                        Value = Math.Round(value, 1) 
                    });
                
            }

            return reportData;
        }
        private IEnumerable<DashboardChartItem> GetDaySalesAmount(IEnumerable<WalletTransaction> walletTransactions, DateTime date)
        {
            IEnumerable<DashboardChartItem> reportData =
                from wt in walletTransactions 
                where 
                    wt.TransactionDateTime.Date == date && 
                    wt.TransactionType == WalletTransactionType.Sell &&
                    wt.Ignore == false
                group wt by wt.TypeName into g
                select new DashboardChartItem
                {
                    Date = date,
                    Label = string.Format(
                        "{0} x{1}", 
                        g.Key, 
                        g.Sum(gi => gi.Quantity)),
                    Value = Math.Round(g.Sum(gi => gi.Price * gi.Quantity) / 1000000, 2)
                };


            return reportData.OrderBy ( ri => ri.Value).ToList();
        }
        private IEnumerable<DashboardChartItem> GetDayInvestmentsAmount(IEnumerable<WalletTransaction> walletTransactions, DateTime date)
        {
            IEnumerable<DashboardChartItem> reportData =
                from wt in walletTransactions 
                where 
                    wt.TransactionDateTime.Date == date && 
                    wt.TransactionType == WalletTransactionType.Buy &&
                    wt.Ignore == false
                group wt by wt.TypeName into g
                select new DashboardChartItem
                {
                    Date = date,
                    Label = string.Format(
                        "{0} x{1}", 
                        g.Key, 
                        g.Sum(gi => gi.Quantity)),
                    Value = Math.Round(g.Sum(gi => gi.Price * gi.Quantity) / 1000000, 2)
                };


            return reportData.OrderBy ( ri => ri.Value).ToList();
        }
        private IEnumerable<DashboardChartItem> GetDayProfitAmount(IEnumerable<WalletTransaction> walletTransactions, DateTime date)
        {
            IEnumerable<DashboardChartItem> reportData =
                from wt in walletTransactions 
                where 
                    wt.TransactionDateTime.Date == date && 
                    wt.TransactionType == WalletTransactionType.Sell &&
                    wt.Ignore == false
                group wt by wt.TypeName into g
                select new DashboardChartItem
                {
                    Date = date,
                    Label = string.Format(
                        "{0} x{1}", 
                        g.Key, 
                        g.Sum(gi => gi.Quantity)),
                    Value = Math.Round(g.Sum(gi => (gi.Price - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
                };


            return reportData.OrderBy ( ri => ri.Value).ToList();
        }
        private IEnumerable<DashboardChartItem> GetSalesProfitAmount()
        {
            DateTime fromDate = DateTime.Now.Date.AddDays(-UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount);
            IEnumerable<WalletTransaction> unitedWalletTransactions = Analysis.Data.GetUnitedWalletTransactions().Where( t => t.Ignore == false );
            IList<DashboardChartItem> reportData = new List<DashboardChartItem>();

            for (int day = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount; day >= 0; day--)
            {
                DateTime date = DateTime.Now.Date.AddDays(-day);
                IEnumerable<double> values = 
                    from wt in unitedWalletTransactions 
                    where 
                        wt.TransactionDateTime.Date == date && 
                        wt.TransactionType == WalletTransactionType.Sell
                    group wt by wt.TransactionDateTime.Date into g
                    select Math.Round(g.Sum(gi => (gi.Price - Analysis.Products.GetProductAverageBuyPrice(unitedWalletTransactions, gi.TypeID)) * gi.Quantity / 1000000), 2);

                double value = 0;

                try
                {
                    value = values.First();
                }
                catch
                {
                    
                }

                reportData.Add(
                    new DashboardChartItem
                    {
                        Date = date,
                        Label = date.ToString("MMM dd"),
                        Value = Math.Round(value, 1) 
                    });
                
            }

            return reportData;
        }
        private IEnumerable<DashboardChartItem> GetInvestmentsAmount()
        {
            DateTime fromDate = DateTime.Now.Date.AddDays(-UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount);
            IEnumerable<WalletTransaction> unitedWalletTransactions = Analysis.Data.GetUnitedWalletTransactions().Where( t => t.Ignore == false );
            IList<DashboardChartItem> reportData = new List<DashboardChartItem>();

            for (int day = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount; day >= 0; day--)
            {
                DateTime date = DateTime.Now.Date.AddDays(-day);
                IEnumerable<double> values = 
                    from wt in unitedWalletTransactions 
                    where 
                        wt.TransactionDateTime.Date == date && 
                        wt.TransactionType == WalletTransactionType.Buy
                    group wt by wt.TransactionDateTime.Date into g
                    select Math.Round(g.Sum(gi => gi.Price * gi.Quantity / 1000000), 2);

                double value = 0;

                try
                {
                    value = values.First();
                }
                catch
                {
                    
                }

                reportData.Add(
                    new DashboardChartItem
                    {
                        Date = date,
                        Label = date.ToString("MMM dd"),
                        Value = Math.Round(value, 1) 
                    });
                
            }

            return reportData;
        }

        private void SalesAmountChart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = this.SalesAmountChart.HitTest( e.X, e.Y );
            IEnumerable<DashboardChartItem> reportData;
            IEnumerable<WalletTransaction> unitedWalletTransactions = Analysis.Data.GetUnitedWalletTransactions().Where( t => t.Ignore == false );

            switch (result.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
                    this.Cursor = Cursors.Hand;
                    break;

                default:
                    this.Cursor = Cursors.Default;
                    return;
            }

            switch (result.Series.Name)
            {
                case "Daily profit":
                    reportData = this.GetDayProfitAmount(unitedWalletTransactions, DateTime.Now.Date.AddDays(result.PointIndex - UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount));
                    this.RenderSalesDetailsChart(null, reportData, null);
                    break;

                case "Daily investments":
                    reportData = this.GetDayInvestmentsAmount(unitedWalletTransactions, DateTime.Now.Date.AddDays(result.PointIndex - UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount));
                    this.RenderSalesDetailsChart(null, null, reportData);
                    break;

                case "Total":
                    reportData = this.GetDaySalesAmount(unitedWalletTransactions, DateTime.Now.Date.AddDays(result.PointIndex - UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount));
                    this.RenderSalesDetailsChart(reportData);
                    break;

                default:
                    Character selectCharacter = GetCharacterByName(result.Series.Name);
                    reportData = this.GetDaySalesAmount(selectCharacter.WalletTransactions, DateTime.Now.Date.AddDays(result.PointIndex - UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount));
                    this.RenderSalesDetailsChart(reportData);
                    break;
            }
        }
        private Character GetCharacterByName(string name)
        {
            return Settings.Instance.Characters.First( character => character.Name == name );
        }
        private void DashboardTab_Load(object sender, EventArgs e)
        {

        }
        private void ChangeSalesAmountDaysToShow_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton) sender;
            UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount = radioButton.Tag.ToString().ToInt32();
            this.RenderSalesAmountChart();
        }

        private void ShowProfitLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.showProfitLabels)
            {
                return;
            }

            this.showProfitLabels = true;
            this.showInvestmentLabels = false;
            this.showDetailedLabeles = false;

            this.RenderSalesAmountChart();
        }
        private void ShowInvestmentLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.showInvestmentLabels)
            {
                return;
            }

            this.showProfitLabels = false;
            this.showInvestmentLabels = true;
            this.showDetailedLabeles = false;

            this.RenderSalesAmountChart();
        }
        private void ShowDetailedLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.showDetailedLabeles)
            {
                return;
            }

            this.showProfitLabels = false;
            this.showInvestmentLabels = false;
            this.showDetailedLabeles = true;

            this.RenderSalesAmountChart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    
    }
}
