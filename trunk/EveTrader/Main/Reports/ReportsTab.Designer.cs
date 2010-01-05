namespace EveTrader.Main.Reports
{
    partial class ReportsTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series2 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea2 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend2 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series3 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series4 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title2 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea3 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend3 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series5 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series6 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title3 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea4 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend4 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series7 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series8 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series9 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title4 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea5 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend5 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series10 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title5 = new Dundas.Charting.WinControl.Title();
            this.ShowForLastWeek = new System.Windows.Forms.RadioButton();
            this.ShowAll = new System.Windows.Forms.RadioButton();
            this.ShowForLast3Month = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowFor30Days = new System.Windows.Forms.RadioButton();
            this.MostProfitableClientsChart = new Dundas.Charting.WinControl.Chart();
            this.MostProfitableStationsChart = new Dundas.Charting.WinControl.Chart();
            this.MostProfitableProductsChart = new Dundas.Charting.WinControl.Chart();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.tpProduct = new System.Windows.Forms.TabPage();
            this.chart1 = new Dundas.Charting.WinControl.Chart();
            this.tpStation = new System.Windows.Forms.TabPage();
            this.tpClients = new System.Windows.Forms.TabPage();
            this.tpBalanceHistory = new System.Windows.Forms.TabPage();
            this.BalanceHistory = new Dundas.Charting.WinControl.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableClientsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableStationsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableProductsChart)).BeginInit();
            this.tcReports.SuspendLayout();
            this.tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tpStation.SuspendLayout();
            this.tpClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceHistory)).BeginInit();
            this.tpBalanceHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowForLastWeek
            // 
            this.ShowForLastWeek.AutoSize = true;
            this.ShowForLastWeek.Checked = true;
            this.ShowForLastWeek.Location = new System.Drawing.Point(104, 12);
            this.ShowForLastWeek.Name = "ShowForLastWeek";
            this.ShowForLastWeek.Size = new System.Drawing.Size(56, 17);
            this.ShowForLastWeek.TabIndex = 15;
            this.ShowForLastWeek.TabStop = true;
            this.ShowForLastWeek.Text = "7 days";
            this.ShowForLastWeek.UseVisualStyleBackColor = true;
            this.ShowForLastWeek.Click += new System.EventHandler(this.ShowForLastWeek_Click);
            // 
            // ShowAll
            // 
            this.ShowAll.AutoSize = true;
            this.ShowAll.Location = new System.Drawing.Point(308, 12);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(58, 17);
            this.ShowAll.TabIndex = 17;
            this.ShowAll.Text = "All time";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // ShowForLast3Month
            // 
            this.ShowForLast3Month.AutoSize = true;
            this.ShowForLast3Month.Location = new System.Drawing.Point(234, 12);
            this.ShowForLast3Month.Name = "ShowForLast3Month";
            this.ShowForLast3Month.Size = new System.Drawing.Size(68, 17);
            this.ShowForLast3Month.TabIndex = 16;
            this.ShowForLast3Month.Text = "3 months";
            this.ShowForLast3Month.UseVisualStyleBackColor = true;
            this.ShowForLast3Month.Click += new System.EventHandler(this.ShowForLast3Month_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Show reports for:";
            // 
            // ShowFor30Days
            // 
            this.ShowFor30Days.AutoSize = true;
            this.ShowFor30Days.Location = new System.Drawing.Point(166, 12);
            this.ShowFor30Days.Name = "ShowFor30Days";
            this.ShowFor30Days.Size = new System.Drawing.Size(62, 17);
            this.ShowFor30Days.TabIndex = 18;
            this.ShowFor30Days.Text = "30 days";
            this.ShowFor30Days.UseVisualStyleBackColor = true;
            this.ShowFor30Days.Click += new System.EventHandler(this.ShowFor30Days_Click);
            // 
            // MostProfitableClientsChart
            // 
            this.MostProfitableClientsChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MostProfitableClientsChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MostProfitableClientsChart.BackGradientEndColor = System.Drawing.Color.White;
            this.MostProfitableClientsChart.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.MostProfitableClientsChart.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableClientsChart.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.MostProfitableClientsChart.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableClientsChart.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableClientsChart.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MostProfitableClientsChart.BorderSkin.FrameBorderWidth = 2;
            this.MostProfitableClientsChart.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.MostProfitableClientsChart.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.LabelsAutoFit = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorTickMark.Size = 2F;
            chartArea1.AxisX2.LabelsAutoFit = false;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorTickMark.Size = 2F;
            chartArea1.AxisY2.LabelsAutoFit = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea1.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowOffset = 2;
            this.MostProfitableClientsChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.AutoFitText = false;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend1.BorderWidth = 0;
            legend1.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend1.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend1.MaxAutoSize = 100F;
            legend1.Name = "Default";
            legend1.TextWrapThreshold = 50;
            this.MostProfitableClientsChart.Legends.Add(legend1);
            this.MostProfitableClientsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableClientsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableClientsChart.Name = "MostProfitableClientsChart";
            this.MostProfitableClientsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series1.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series1.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series1.ChartType = "Bar";
            series1.Color = System.Drawing.Color.YellowGreen;
            series1.Name = "Pure profit (gross sales - average buy price)";
            series1.PaletteCustomColors = new System.Drawing.Color[0];
            series1.ShadowOffset = 2;
            series1.ShowLabelAsValue = true;
            series1.SmartLabels.Enabled = true;
            series2.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series2.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.ChartType = "Bar";
            series2.Color = System.Drawing.Color.Gold;
            series2.Name = "Gross sales";
            series2.PaletteCustomColors = new System.Drawing.Color[0];
            series2.ShadowOffset = 2;
            series2.ShowLabelAsValue = true;
            this.MostProfitableClientsChart.Series.Add(series1);
            this.MostProfitableClientsChart.Series.Add(series2);
            this.MostProfitableClientsChart.Size = new System.Drawing.Size(819, 518);
            this.MostProfitableClientsChart.TabIndex = 5;
            this.MostProfitableClientsChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Default Title";
            title1.Text = "Top 15 most profitable clients";
            this.MostProfitableClientsChart.Titles.Add(title1);
            this.MostProfitableClientsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableClientsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.MostProfitableClientsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // MostProfitableStationsChart
            // 
            this.MostProfitableStationsChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MostProfitableStationsChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MostProfitableStationsChart.BackGradientEndColor = System.Drawing.Color.White;
            this.MostProfitableStationsChart.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.MostProfitableStationsChart.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableStationsChart.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.MostProfitableStationsChart.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableStationsChart.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableStationsChart.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MostProfitableStationsChart.BorderSkin.FrameBorderWidth = 2;
            this.MostProfitableStationsChart.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.MostProfitableStationsChart.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea2.AxisX.Interval = 1;
            chartArea2.AxisX.LabelsAutoFit = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorTickMark.Size = 2F;
            chartArea2.AxisX2.LabelsAutoFit = false;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorTickMark.Size = 2F;
            chartArea2.AxisY2.LabelsAutoFit = false;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea2.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea2.Name = "Default";
            chartArea2.ShadowOffset = 2;
            this.MostProfitableStationsChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.AutoFitText = false;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend2.BorderWidth = 0;
            legend2.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend2.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend2.MaxAutoSize = 100F;
            legend2.Name = "Default";
            legend2.TextWrapThreshold = 50;
            this.MostProfitableStationsChart.Legends.Add(legend2);
            this.MostProfitableStationsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableStationsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableStationsChart.Name = "MostProfitableStationsChart";
            this.MostProfitableStationsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series3.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series3.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series3.ChartType = "Bar";
            series3.Color = System.Drawing.Color.YellowGreen;
            series3.Name = "Pure profit (gross sales - average buy price)";
            series3.PaletteCustomColors = new System.Drawing.Color[0];
            series3.ShadowOffset = 2;
            series3.ShowLabelAsValue = true;
            series3.SmartLabels.Enabled = true;
            series4.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series4.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series4.BorderColor = System.Drawing.Color.Transparent;
            series4.ChartType = "Bar";
            series4.Color = System.Drawing.Color.Gold;
            series4.Name = "Gross sales";
            series4.PaletteCustomColors = new System.Drawing.Color[0];
            series4.ShadowOffset = 2;
            series4.ShowLabelAsValue = true;
            this.MostProfitableStationsChart.Series.Add(series3);
            this.MostProfitableStationsChart.Series.Add(series4);
            this.MostProfitableStationsChart.Size = new System.Drawing.Size(819, 518);
            this.MostProfitableStationsChart.TabIndex = 4;
            this.MostProfitableStationsChart.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Default Title";
            title2.Text = "Top 15 most profitable stations";
            this.MostProfitableStationsChart.Titles.Add(title2);
            this.MostProfitableStationsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableStationsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.MostProfitableStationsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // MostProfitableProductsChart
            // 
            this.MostProfitableProductsChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MostProfitableProductsChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MostProfitableProductsChart.BackGradientEndColor = System.Drawing.Color.White;
            this.MostProfitableProductsChart.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.MostProfitableProductsChart.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableProductsChart.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.MostProfitableProductsChart.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableProductsChart.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.MostProfitableProductsChart.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MostProfitableProductsChart.BorderSkin.FrameBorderWidth = 2;
            this.MostProfitableProductsChart.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.MostProfitableProductsChart.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea3.AxisX.Interval = 1;
            chartArea3.AxisX.LabelsAutoFit = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MinorTickMark.Size = 2F;
            chartArea3.AxisX2.LabelsAutoFit = false;
            chartArea3.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MinorTickMark.Size = 2F;
            chartArea3.AxisY2.LabelsAutoFit = false;
            chartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea3.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea3.Name = "Default";
            chartArea3.ShadowOffset = 2;
            this.MostProfitableProductsChart.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.AutoFitText = false;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend3.BorderWidth = 0;
            legend3.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend3.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend3.MaxAutoSize = 100F;
            legend3.Name = "Default";
            legend3.TextWrapThreshold = 50;
            this.MostProfitableProductsChart.Legends.Add(legend3);
            this.MostProfitableProductsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableProductsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableProductsChart.Name = "MostProfitableProductsChart";
            this.MostProfitableProductsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series5.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series5.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series5.ChartType = "Bar";
            series5.Color = System.Drawing.Color.YellowGreen;
            series5.Name = "Pure profit (gross sales - average buy price)";
            series5.PaletteCustomColors = new System.Drawing.Color[0];
            series5.ShadowOffset = 2;
            series5.ShowLabelAsValue = true;
            series5.SmartLabels.Enabled = true;
            series6.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series6.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series6.BorderColor = System.Drawing.Color.Transparent;
            series6.ChartType = "Bar";
            series6.Color = System.Drawing.Color.Gold;
            series6.Name = "Gross sales";
            series6.PaletteCustomColors = new System.Drawing.Color[0];
            series6.ShadowOffset = 2;
            series6.ShowLabelAsValue = true;
            this.MostProfitableProductsChart.Series.Add(series5);
            this.MostProfitableProductsChart.Series.Add(series6);
            this.MostProfitableProductsChart.Size = new System.Drawing.Size(823, 522);
            this.MostProfitableProductsChart.TabIndex = 2;
            this.MostProfitableProductsChart.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title3.Name = "Default Title";
            title3.Text = "Top 15 most profitable products";
            this.MostProfitableProductsChart.Titles.Add(title3);
            this.MostProfitableProductsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableProductsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.MostProfitableProductsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // tcReports
            // 
            this.tcReports.Controls.Add(this.tpProduct);
            this.tcReports.Controls.Add(this.tpStation);
            this.tcReports.Controls.Add(this.tpClients);
            this.tcReports.Controls.Add(this.tpBalanceHistory);
            this.tcReports.Location = new System.Drawing.Point(3, 30);
            this.tcReports.Name = "tcReports";
            this.tcReports.SelectedIndex = 0;
            this.tcReports.Size = new System.Drawing.Size(827, 544);
            this.tcReports.TabIndex = 21;
            // 
            // tpProduct
            // 
            this.tpProduct.Controls.Add(this.chart1);
            this.tpProduct.Controls.Add(this.MostProfitableProductsChart);
            this.tpProduct.Location = new System.Drawing.Point(4, 22);
            this.tpProduct.Name = "tpProduct";
            this.tpProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduct.Size = new System.Drawing.Size(819, 518);
            this.tpProduct.TabIndex = 0;
            this.tpProduct.Text = "Products";
            this.tpProduct.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackGradientEndColor = System.Drawing.Color.White;
            this.chart1.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.chart1.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.chart1.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.chart1.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.chart1.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chart1.BorderSkin.FrameBorderWidth = 2;
            this.chart1.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.chart1.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea4.AxisX.Interval = 1;
            chartArea4.AxisX.LabelsAutoFit = false;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisX.MinorTickMark.Size = 2F;
            chartArea4.AxisX2.LabelsAutoFit = false;
            chartArea4.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisY.MinorTickMark.Size = 2F;
            chartArea4.AxisY2.LabelsAutoFit = false;
            chartArea4.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea4.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea4.Name = "Default";
            chartArea4.ShadowOffset = 2;
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Center;
            legend4.AutoFitText = false;
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend4.BorderWidth = 0;
            legend4.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend4.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend4.MaxAutoSize = 100F;
            legend4.Name = "Default";
            legend4.TextWrapThreshold = 50;
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(-2, -2);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series7.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series7.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series7.ChartType = "Bar";
            series7.Color = System.Drawing.Color.YellowGreen;
            series7.Name = "Pure profit (gross sales - average buy price)";
            series7.PaletteCustomColors = new System.Drawing.Color[0];
            series7.ShadowOffset = 2;
            series7.ShowLabelAsValue = true;
            series7.SmartLabels.Enabled = true;
            series8.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series8.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series8.BorderColor = System.Drawing.Color.Transparent;
            series8.ChartType = "Bar";
            series8.Color = System.Drawing.Color.Gold;
            series8.Name = "Gross sales";
            series8.PaletteCustomColors = new System.Drawing.Color[0];
            series8.ShadowOffset = 2;
            series8.ShowLabelAsValue = true;
            series9.ChartType = "Bar";
            series9.Name = "Sales Tax";
            series9.PaletteCustomColors = new System.Drawing.Color[0];
            series9.ShowLabelAsValue = true;
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(823, 522);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title4.Name = "Default Title";
            title4.Text = "Top 15 most profitable products";
            this.chart1.Titles.Add(title4);
            this.chart1.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.chart1.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // tpStation
            // 
            this.tpStation.Controls.Add(this.MostProfitableStationsChart);
            this.tpStation.Location = new System.Drawing.Point(4, 22);
            this.tpStation.Name = "tpStation";
            this.tpStation.Padding = new System.Windows.Forms.Padding(3);
            this.tpStation.Size = new System.Drawing.Size(819, 518);
            this.tpStation.TabIndex = 1;
            this.tpStation.Text = "Stations";
            this.tpStation.UseVisualStyleBackColor = true;
            // 
            // tpClients
            // 
            this.tpClients.Controls.Add(this.MostProfitableClientsChart);
            this.tpClients.Location = new System.Drawing.Point(4, 22);
            this.tpClients.Name = "tpClients";
            this.tpClients.Padding = new System.Windows.Forms.Padding(3);
            this.tpClients.Size = new System.Drawing.Size(819, 518);
            this.tpClients.TabIndex = 2;
            this.tpClients.Text = "Clients";
            this.tpClients.UseVisualStyleBackColor = true;
            // 
            // tpBalanceHistory
            // 
            // 
            // BalanceHistory
            // 
            this.BalanceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BalanceHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BalanceHistory.BackGradientEndColor = System.Drawing.Color.White;
            this.BalanceHistory.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.BalanceHistory.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.BalanceHistory.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.BalanceHistory.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.BalanceHistory.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.BalanceHistory.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BalanceHistory.BorderSkin.FrameBorderWidth = 2;
            this.BalanceHistory.BorderSkin.PageColor = System.Drawing.Color.AliceBlue;
            this.BalanceHistory.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea5.AxisX.LabelStyle.Format = "g";
            chartArea5.AxisX.LabelStyle.Interval = 0;
            chartArea5.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea5.AxisX.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.MajorGrid.Interval = 0;
            chartArea5.AxisX.MajorGrid.IntervalOffset = 0;
            chartArea5.AxisX.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX.MajorTickMark.Interval = 0;
            chartArea5.AxisX.MajorTickMark.IntervalOffset = 0;
            chartArea5.AxisX.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX2.LabelStyle.Interval = 0;
            chartArea5.AxisX2.LabelStyle.IntervalOffset = 0;
            chartArea5.AxisX2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.MajorGrid.Interval = 0;
            chartArea5.AxisX2.MajorGrid.IntervalOffset = 0;
            chartArea5.AxisX2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX2.MajorTickMark.Interval = 0;
            chartArea5.AxisX2.MajorTickMark.IntervalOffset = 0;
            chartArea5.AxisX2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.LabelStyle.Format = "N2";
            chartArea5.AxisY.LabelStyle.Interval = 0;
            chartArea5.AxisY.LabelStyle.IntervalOffset = 0;
            chartArea5.AxisY.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.MajorGrid.Interval = 0;
            chartArea5.AxisY.MajorGrid.IntervalOffset = 0;
            chartArea5.AxisY.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.MajorTickMark.Interval = 0;
            chartArea5.AxisY.MajorTickMark.IntervalOffset = 0;
            chartArea5.AxisY.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.StartFromZero = false;
            chartArea5.AxisY2.LabelStyle.Interval = 0;
            chartArea5.AxisY2.LabelStyle.IntervalOffset = 0;
            chartArea5.AxisY2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.MajorGrid.Interval = 0;
            chartArea5.AxisY2.MajorGrid.IntervalOffset = 0;
            chartArea5.AxisY2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY2.MajorTickMark.Interval = 0;
            chartArea5.AxisY2.MajorTickMark.IntervalOffset = 0;
            chartArea5.AxisY2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea5.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.BackColor = System.Drawing.Color.White;
            chartArea5.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea5.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea5.InnerPlotPosition.Auto = false;
            chartArea5.InnerPlotPosition.Height = 90.09591F;
            chartArea5.InnerPlotPosition.Width = 89.22301F;
            chartArea5.InnerPlotPosition.X = 10.77699F;
            chartArea5.InnerPlotPosition.Y = 2.47699F;
            chartArea5.Name = "Default";
            chartArea5.Position.Auto = false;
            chartArea5.Position.Height = 84.78022F;
            chartArea5.Position.Width = 77.58313F;
            chartArea5.Position.X = 3.91687F;
            chartArea5.Position.Y = 10.04376F;
            chartArea5.ShadowOffset = 2;
            this.BalanceHistory.ChartAreas.Add(chartArea5);
            legend5.Name = "Default";
            this.BalanceHistory.Legends.Add(legend5);
            this.BalanceHistory.Location = new System.Drawing.Point(0, 0);
            this.BalanceHistory.Margin = new System.Windows.Forms.Padding(0);
            this.BalanceHistory.Name = "BalanceHistory";
            this.BalanceHistory.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series10.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series10.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series10.BorderWidth = 2;
            series10.ChartType = "Kagi";
            series10.Color = System.Drawing.Color.YellowGreen;
            series10.Name = "Balance";
            series10.PaletteCustomColors = new System.Drawing.Color[0];
            series10.ShadowOffset = 1;
            series10.ShowLabelAsValue = true;
            series10.XValueType = Dundas.Charting.WinControl.ChartValueTypes.DateTime;
            this.BalanceHistory.Series.Add(series10);
            this.BalanceHistory.Size = new System.Drawing.Size(819, 518);
            this.BalanceHistory.TabIndex = 6;
            this.BalanceHistory.Text = "chart1";
            title5.Name = "Title1";
            title5.Text = "Balance";
            this.BalanceHistory.Titles.Add(title5);
            this.BalanceHistory.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.BalanceHistory.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.BalanceHistory.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            this.tpBalanceHistory.Controls.Add(this.BalanceHistory);
            this.tpBalanceHistory.Location = new System.Drawing.Point(4, 22);
            this.tpBalanceHistory.Name = "tpBalanceHistory";
            this.tpBalanceHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpBalanceHistory.Size = new System.Drawing.Size(819, 518);
            this.tpBalanceHistory.TabIndex = 3;
            this.tpBalanceHistory.Text = "Balance History";
            this.tpBalanceHistory.UseVisualStyleBackColor = true;
            // 
            // ReportsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcReports);
            this.Controls.Add(this.ShowFor30Days);
            this.Controls.Add(this.ShowForLastWeek);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.ShowForLast3Month);
            this.Controls.Add(this.label2);
            this.Name = "ReportsTab";
            this.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.Size = new System.Drawing.Size(833, 574);
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableClientsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableStationsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableProductsChart)).EndInit();
            this.tcReports.ResumeLayout(false);
            this.tpProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tpStation.ResumeLayout(false);
            this.tpClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BalanceHistory)).EndInit();
            this.tpBalanceHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ShowForLastWeek;
        private System.Windows.Forms.RadioButton ShowAll;
        private System.Windows.Forms.RadioButton ShowForLast3Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton ShowFor30Days;
        private Dundas.Charting.WinControl.Chart MostProfitableClientsChart;
        private Dundas.Charting.WinControl.Chart MostProfitableStationsChart;
        private Dundas.Charting.WinControl.Chart MostProfitableProductsChart;
        private System.Windows.Forms.TabControl tcReports;
        private System.Windows.Forms.TabPage tpProduct;
        private System.Windows.Forms.TabPage tpStation;
        private System.Windows.Forms.TabPage tpClients;
        private System.Windows.Forms.TabPage tpBalanceHistory;
        private Dundas.Charting.WinControl.Chart chart1;
        private Dundas.Charting.WinControl.Chart BalanceHistory;




    }
}
