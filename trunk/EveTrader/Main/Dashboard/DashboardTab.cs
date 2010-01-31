using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.ClassExtenders;
using Core.DomainModel;
using Dundas.Charting.WinControl;

namespace EveTrader.Main.Dashboard
{
    public partial class DashboardTab : UserControl
    {
        private bool iShowTotalLabels = true;
        private bool iShowProfitLabels = true;
        private bool iShowInvestmentLabels = false;
        private bool iShowDetailedLabeles = false;

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
                //TODO: FIX for character.Wallets == null
                reportData = this.GetSalesAmount(character.Wallets.Single().Journal);
                this.SalesAmountChart.Series[character.Name].Type = SeriesChartType.StackedColumn;
                this.SalesAmountChart.Series[character.Name].ShowLabelAsValue = iShowDetailedLabeles;
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
            this.SalesAmountChart.Series["Total"].ShowLabelAsValue = iShowTotalLabels;
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
                this.iShowInvestmentLabels ? 255 : 100,
                Color.OrangeRed.R,
                Color.OrangeRed.G,
                Color.OrangeRed.B);
            this.SalesAmountChart.Series["Daily investments"].ChartType = "Line";
            this.SalesAmountChart.Series["Daily investments"].Color = Color.FromArgb(
                this.iShowInvestmentLabels ? 255 : 100,
                Color.OrangeRed.R,
                Color.OrangeRed.G,
                Color.OrangeRed.B);
            this.SalesAmountChart.Series["Daily investments"].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SalesAmountChart.Series["Daily investments"].FontColor = System.Drawing.Color.Black;
            this.SalesAmountChart.Series["Daily investments"].MarkerSize = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 14 ? 5 : 9;;
            this.SalesAmountChart.Series["Daily investments"].MarkerBorderColor = Color.FromArgb(
                this.iShowInvestmentLabels ? 255 : 100,
                Color.Crimson.R,
                Color.Crimson.G,
                Color.Crimson.B);
            this.SalesAmountChart.Series["Daily investments"].MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            this.SalesAmountChart.Series["Daily investments"].Name = "Daily investments";
            this.SalesAmountChart.Series["Daily investments"].PaletteCustomColors = new System.Drawing.Color[0];
            this.SalesAmountChart.Series["Daily investments"].ShadowOffset = this.iShowInvestmentLabels ? 2 : 0;
            this.SalesAmountChart.Series["Daily investments"].BorderWidth = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount <= 14 ? 3 : this.iShowInvestmentLabels ? 2 : 1;
            this.SalesAmountChart.Series["Daily investments"].CustomAttributes = "LabelStyle=Right";
            this.SalesAmountChart.Series["Daily investments"].ShowLabelAsValue = iShowInvestmentLabels;
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
                this.iShowProfitLabels ? 255 : 100,   
                Color.GreenYellow.R,
                Color.GreenYellow.G,
                Color.GreenYellow.B);
            this.SalesAmountChart.Series["Daily profit"].ChartType = "Line";
            this.SalesAmountChart.Series["Daily profit"].Color = Color.FromArgb(
                this.iShowProfitLabels ? 255 : 100,  
                Color.GreenYellow.R,
                Color.GreenYellow.G,
                Color.GreenYellow.B);
            this.SalesAmountChart.Series["Daily profit"].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SalesAmountChart.Series["Daily profit"].FontColor = System.Drawing.Color.Black;
            this.SalesAmountChart.Series["Daily profit"].MarkerSize = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount > 14 ? 5 : 9;;
            this.SalesAmountChart.Series["Daily profit"].MarkerBorderColor = Color.FromArgb(
                this.iShowProfitLabels ? 255 : 100,    
                Color.OliveDrab.R,
                Color.OliveDrab.G,
                Color.OliveDrab.B);
            this.SalesAmountChart.Series["Daily profit"].MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            this.SalesAmountChart.Series["Daily profit"].Name = "Daily profit";
            this.SalesAmountChart.Series["Daily profit"].PaletteCustomColors = new System.Drawing.Color[0];
            this.SalesAmountChart.Series["Daily profit"].ShadowOffset = this.iShowProfitLabels ? 2 : 0;
            this.SalesAmountChart.Series["Daily profit"].BorderWidth = UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount <= 14 ? 3 : this.iShowProfitLabels ? 2 : 1;
            this.SalesAmountChart.Series["Daily profit"].CustomAttributes = "LabelStyle=Right";
            this.SalesAmountChart.Series["Daily profit"].ShowLabelAsValue = iShowProfitLabels;
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
                //TODO: FIX for character.Wallets == null
                walletJournal = walletJournal.Union(
                    character.Wallets.Single().Journal.Where(
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
                        r.ReferenceTypeID == 2 &&
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
                    Value = Math.Round(g.Sum(gi => (gi.Price  * gi.Quantity) / 1000000), 2)
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
                    Value = Math.Round(g.Sum(gi => (gi.Price  * gi.Quantity) / 1000000), 2)
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
                    Value = Math.Round(g.Sum(gi => (gi.Price  - Analysis.Products.GetProductAverageBuyPrice(walletTransactions, gi.TypeID)) * gi.Quantity) / 1000000, 2)
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

                double value = values.FirstOrDefault();

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
                    select Math.Round(g.Sum(gi => (gi.Price - gi.SalesTax) * gi.Quantity / 1000000), 2);

                double value = values.FirstOrDefault();

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
                    //TODO: FIX for character.Wallets == null
                    reportData = this.GetDaySalesAmount(selectCharacter.Wallets.Single().Transactions, DateTime.Now.Date.AddDays(result.PointIndex - UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount));
                    this.RenderSalesDetailsChart(reportData);
                    break;
            }
        }
        private Character GetCharacterByName(string name)
        {
            return Settings.Instance.Characters.First( character => character.Name == name );
        }
        private void ChangeSalesAmountDaysToShow_Click(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton) sender;
            UISettings.Instance.DashboardSettings.DaysToShowInSalesAmount = radioButton.Tag.ToString().ToInt32();
            this.RenderSalesAmountChart();
        }

        private void ShowProfitLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.iShowProfitLabels)
            {
                return;
            }

            this.iShowProfitLabels = true;
            this.iShowInvestmentLabels = false;
            this.iShowDetailedLabeles = false;

            this.RenderSalesAmountChart();
        }
        private void ShowInvestmentLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.iShowInvestmentLabels)
            {
                return;
            }

            this.iShowProfitLabels = false;
            this.iShowInvestmentLabels = true;
            this.iShowDetailedLabeles = false;

            this.RenderSalesAmountChart();
        }
        private void ShowDetailedLabelsRadioButton_Click(object sender, EventArgs e)
        {
            if (this.iShowDetailedLabeles)
            {
                return;
            }

            this.iShowProfitLabels = false;
            this.iShowInvestmentLabels = false;
            this.iShowDetailedLabeles = true;

            this.RenderSalesAmountChart();
        }
    }
}
