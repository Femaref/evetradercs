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
            Dundas.Charting.WinControl.ChartArea chartArea5 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend5 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series9 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series10 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title5 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea6 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend6 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series11 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series12 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title6 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea7 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend7 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series13 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series14 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series15 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title7 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea8 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend8 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series16 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title8 = new Dundas.Charting.WinControl.Title();
            this.ShowForLastWeek = new System.Windows.Forms.RadioButton();
            this.ShowAll = new System.Windows.Forms.RadioButton();
            this.ShowForLast3Month = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowFor30Days = new System.Windows.Forms.RadioButton();
            this.MostProfitableClientsChart = new Dundas.Charting.WinControl.Chart();
            this.MostProfitableStationsChart = new Dundas.Charting.WinControl.Chart();
            this.tcReports = new System.Windows.Forms.TabControl();
            this.tpProduct = new System.Windows.Forms.TabPage();
            this.MostProfitableProductsChart = new Dundas.Charting.WinControl.Chart();
            this.tpStation = new System.Windows.Forms.TabPage();
            this.tpClients = new System.Windows.Forms.TabPage();
            this.tpBalanceHistory = new System.Windows.Forms.TabPage();
            this.BalanceHistory = new Dundas.Charting.WinControl.Chart();
            this.tbItemsDisplayed = new System.Windows.Forms.TextBox();
            this.descItemsDisplayed = new System.Windows.Forms.Label();
            this.btApply = new System.Windows.Forms.Button();
            this.cbAutomaticApply = new System.Windows.Forms.CheckBox();
            this.dtpTransactionLimit = new System.Windows.Forms.DateTimePicker();
            this.descTransactionLimit = new System.Windows.Forms.Label();
            this.cbActivateTransactionLimit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableClientsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableStationsChart)).BeginInit();
            this.tcReports.SuspendLayout();
            this.tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableProductsChart)).BeginInit();
            this.tpStation.SuspendLayout();
            this.tpClients.SuspendLayout();
            this.tpBalanceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceHistory)).BeginInit();
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
            chartArea5.AxisX.Interval = 1;
            chartArea5.AxisX.LabelsAutoFit = false;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX.MinorTickMark.Size = 2F;
            chartArea5.AxisX2.LabelsAutoFit = false;
            chartArea5.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY.MinorTickMark.Size = 2F;
            chartArea5.AxisY2.LabelsAutoFit = false;
            chartArea5.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea5.BackColor = System.Drawing.Color.White;
            chartArea5.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea5.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea5.Name = "Default";
            chartArea5.ShadowOffset = 2;
            this.MostProfitableClientsChart.ChartAreas.Add(chartArea5);
            legend5.Alignment = System.Drawing.StringAlignment.Center;
            legend5.AutoFitText = false;
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend5.BorderWidth = 0;
            legend5.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend5.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend5.MaxAutoSize = 100F;
            legend5.Name = "Default";
            legend5.TextWrapThreshold = 50;
            this.MostProfitableClientsChart.Legends.Add(legend5);
            this.MostProfitableClientsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableClientsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableClientsChart.Name = "MostProfitableClientsChart";
            this.MostProfitableClientsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series9.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series9.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series9.ChartType = "Bar";
            series9.Color = System.Drawing.Color.YellowGreen;
            series9.Name = "Pure profit (gross sales - average buy price - sales tax)";
            series9.PaletteCustomColors = new System.Drawing.Color[0];
            series9.ShadowOffset = 2;
            series9.ShowLabelAsValue = true;
            series9.SmartLabels.Enabled = true;
            series10.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series10.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series10.BorderColor = System.Drawing.Color.Transparent;
            series10.ChartType = "Bar";
            series10.Color = System.Drawing.Color.Gold;
            series10.Name = "Gross sales";
            series10.PaletteCustomColors = new System.Drawing.Color[0];
            series10.ShadowOffset = 2;
            series10.ShowLabelAsValue = true;
            this.MostProfitableClientsChart.Series.Add(series9);
            this.MostProfitableClientsChart.Series.Add(series10);
            this.MostProfitableClientsChart.Size = new System.Drawing.Size(819, 518);
            this.MostProfitableClientsChart.TabIndex = 5;
            this.MostProfitableClientsChart.Text = "chart1";
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title5.Name = "Default Title";
            title5.Text = "Top 15 most profitable clients";
            this.MostProfitableClientsChart.Titles.Add(title5);
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
            chartArea6.AxisX.Interval = 1;
            chartArea6.AxisX.LabelsAutoFit = false;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisX.MinorTickMark.Size = 2F;
            chartArea6.AxisX2.LabelsAutoFit = false;
            chartArea6.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisY.MinorTickMark.Size = 2F;
            chartArea6.AxisY2.LabelsAutoFit = false;
            chartArea6.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea6.BackColor = System.Drawing.Color.White;
            chartArea6.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea6.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea6.Name = "Default";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 75.11221F;
            chartArea6.Position.Width = 91.70782F;
            chartArea6.Position.X = 3.91687F;
            chartArea6.Position.Y = 12.06961F;
            chartArea6.ShadowOffset = 2;
            this.MostProfitableStationsChart.ChartAreas.Add(chartArea6);
            legend6.Alignment = System.Drawing.StringAlignment.Center;
            legend6.AutoFitText = false;
            legend6.BackColor = System.Drawing.Color.Transparent;
            legend6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend6.BorderWidth = 0;
            legend6.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend6.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend6.MaxAutoSize = 100F;
            legend6.Name = "Default";
            legend6.Position.Auto = false;
            legend6.Position.Height = 4.642166F;
            legend6.Position.Width = 44.37653F;
            legend6.Position.X = 27.58252F;
            legend6.Position.Y = 90.18182F;
            legend6.TextWrapThreshold = 50;
            this.MostProfitableStationsChart.Legends.Add(legend6);
            this.MostProfitableStationsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableStationsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableStationsChart.Name = "MostProfitableStationsChart";
            this.MostProfitableStationsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series11.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series11.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series11.ChartType = "Bar";
            series11.Color = System.Drawing.Color.YellowGreen;
            series11.CustomAttributes = "BarLabelStyle=Auto, DrawingStyle=Default, EmptyPointValue=Average, DrawSideBySide" +
                "=Auto, PointWidth=0.8";
            series11.Name = "Pure profit (gross sales - average buy price - sales tax)";
            series11.PaletteCustomColors = new System.Drawing.Color[0];
            series11.ShadowOffset = 2;
            series11.ShowLabelAsValue = true;
            series11.SmartLabels.Enabled = true;
            series11.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series11.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series12.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series12.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series12.BorderColor = System.Drawing.Color.Transparent;
            series12.ChartType = "Bar";
            series12.Color = System.Drawing.Color.Gold;
            series12.CustomAttributes = "BarLabelStyle=Auto, DrawingStyle=Default, EmptyPointValue=Average, DrawSideBySide" +
                "=Auto, PointWidth=0.8";
            series12.Name = "Gross sales";
            series12.PaletteCustomColors = new System.Drawing.Color[0];
            series12.ShadowOffset = 2;
            series12.ShowLabelAsValue = true;
            series12.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series12.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            this.MostProfitableStationsChart.Series.Add(series11);
            this.MostProfitableStationsChart.Series.Add(series12);
            this.MostProfitableStationsChart.Size = new System.Drawing.Size(819, 518);
            this.MostProfitableStationsChart.TabIndex = 4;
            this.MostProfitableStationsChart.Text = "chart1";
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            title6.Name = "Default Title";
            title6.Position.Auto = false;
            title6.Position.Height = 4.618933F;
            title6.Position.Width = 91.70782F;
            title6.Position.X = 3.91687F;
            title6.Position.Y = 4.450677F;
            title6.Text = "Top 15 most profitable stations";
            this.MostProfitableStationsChart.Titles.Add(title6);
            this.MostProfitableStationsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableStationsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.MostProfitableStationsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
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
            this.tpProduct.Controls.Add(this.MostProfitableProductsChart);
            this.tpProduct.Location = new System.Drawing.Point(4, 22);
            this.tpProduct.Name = "tpProduct";
            this.tpProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduct.Size = new System.Drawing.Size(819, 518);
            this.tpProduct.TabIndex = 0;
            this.tpProduct.Text = "Products";
            this.tpProduct.UseVisualStyleBackColor = true;
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
            chartArea7.AxisX.Interval = 1;
            chartArea7.AxisX.LabelsAutoFit = false;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisX.MinorTickMark.Size = 2F;
            chartArea7.AxisX2.LabelsAutoFit = false;
            chartArea7.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisY.MinorTickMark.Size = 2F;
            chartArea7.AxisY2.LabelsAutoFit = false;
            chartArea7.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea7.BackColor = System.Drawing.Color.White;
            chartArea7.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea7.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea7.Name = "Default";
            chartArea7.ShadowOffset = 2;
            this.MostProfitableProductsChart.ChartAreas.Add(chartArea7);
            legend7.Alignment = System.Drawing.StringAlignment.Center;
            legend7.AutoFitText = false;
            legend7.BackColor = System.Drawing.Color.Transparent;
            legend7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend7.BorderWidth = 0;
            legend7.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend7.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend7.MaxAutoSize = 100F;
            legend7.Name = "Default";
            legend7.TextWrapThreshold = 50;
            this.MostProfitableProductsChart.Legends.Add(legend7);
            this.MostProfitableProductsChart.Location = new System.Drawing.Point(0, 0);
            this.MostProfitableProductsChart.Margin = new System.Windows.Forms.Padding(0);
            this.MostProfitableProductsChart.Name = "MostProfitableProductsChart";
            this.MostProfitableProductsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series13.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series13.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series13.ChartType = "Bar";
            series13.Color = System.Drawing.Color.YellowGreen;
            series13.Name = "Pure profit (gross sales - average buy price - sales tax)";
            series13.PaletteCustomColors = new System.Drawing.Color[0];
            series13.ShadowOffset = 2;
            series13.ShowLabelAsValue = true;
            series13.SmartLabels.Enabled = true;
            series14.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series14.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series14.BorderColor = System.Drawing.Color.Transparent;
            series14.ChartType = "Bar";
            series14.Color = System.Drawing.Color.Gold;
            series14.Name = "Gross sales";
            series14.PaletteCustomColors = new System.Drawing.Color[0];
            series14.ShadowOffset = 2;
            series14.ShowLabelAsValue = true;
            series15.BackGradientEndColor = System.Drawing.Color.Blue;
            series15.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series15.BorderColor = System.Drawing.Color.Transparent;
            series15.ChartType = "Bar";
            series15.Color = System.Drawing.Color.LightBlue;
            series15.Name = "Sales Tax";
            series15.PaletteCustomColors = new System.Drawing.Color[0];
            series15.ShadowOffset = 2;
            series15.ShowLabelAsValue = true;
            this.MostProfitableProductsChart.Series.Add(series13);
            this.MostProfitableProductsChart.Series.Add(series14);
            this.MostProfitableProductsChart.Series.Add(series15);
            this.MostProfitableProductsChart.Size = new System.Drawing.Size(823, 522);
            this.MostProfitableProductsChart.TabIndex = 2;
            this.MostProfitableProductsChart.Text = "chart1";
            title7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title7.Name = "Default Title";
            title7.Text = "Top 15 most profitable products";
            this.MostProfitableProductsChart.Titles.Add(title7);
            this.MostProfitableProductsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.MostProfitableProductsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.MostProfitableProductsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
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
            this.tpBalanceHistory.Controls.Add(this.BalanceHistory);
            this.tpBalanceHistory.Location = new System.Drawing.Point(4, 22);
            this.tpBalanceHistory.Name = "tpBalanceHistory";
            this.tpBalanceHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpBalanceHistory.Size = new System.Drawing.Size(819, 518);
            this.tpBalanceHistory.TabIndex = 3;
            this.tpBalanceHistory.Text = "Balance History";
            this.tpBalanceHistory.UseVisualStyleBackColor = true;
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
            chartArea8.AxisX.LabelStyle.Format = "g";
            chartArea8.AxisX.LabelStyle.Interval = 0;
            chartArea8.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea8.AxisX.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.MajorGrid.Interval = 0;
            chartArea8.AxisX.MajorGrid.IntervalOffset = 0;
            chartArea8.AxisX.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisX.MajorTickMark.Interval = 0;
            chartArea8.AxisX.MajorTickMark.IntervalOffset = 0;
            chartArea8.AxisX.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisX2.LabelStyle.Interval = 0;
            chartArea8.AxisX2.LabelStyle.IntervalOffset = 0;
            chartArea8.AxisX2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.MajorGrid.Interval = 0;
            chartArea8.AxisX2.MajorGrid.IntervalOffset = 0;
            chartArea8.AxisX2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisX2.MajorTickMark.Interval = 0;
            chartArea8.AxisX2.MajorTickMark.IntervalOffset = 0;
            chartArea8.AxisX2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisY.LabelStyle.Format = "N2";
            chartArea8.AxisY.LabelStyle.Interval = 0;
            chartArea8.AxisY.LabelStyle.IntervalOffset = 0;
            chartArea8.AxisY.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.MajorGrid.Interval = 0;
            chartArea8.AxisY.MajorGrid.IntervalOffset = 0;
            chartArea8.AxisY.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisY.MajorTickMark.Interval = 0;
            chartArea8.AxisY.MajorTickMark.IntervalOffset = 0;
            chartArea8.AxisY.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisY.StartFromZero = false;
            chartArea8.AxisY2.LabelStyle.Interval = 0;
            chartArea8.AxisY2.LabelStyle.IntervalOffset = 0;
            chartArea8.AxisY2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.MajorGrid.Interval = 0;
            chartArea8.AxisY2.MajorGrid.IntervalOffset = 0;
            chartArea8.AxisY2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.AxisY2.MajorTickMark.Interval = 0;
            chartArea8.AxisY2.MajorTickMark.IntervalOffset = 0;
            chartArea8.AxisY2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea8.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea8.BackColor = System.Drawing.Color.White;
            chartArea8.BorderColor = System.Drawing.Color.Gainsboro;
            chartArea8.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea8.InnerPlotPosition.Auto = false;
            chartArea8.InnerPlotPosition.Height = 90.09591F;
            chartArea8.InnerPlotPosition.Width = 89.22301F;
            chartArea8.InnerPlotPosition.X = 10.77699F;
            chartArea8.InnerPlotPosition.Y = 2.47699F;
            chartArea8.Name = "Default";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 84.78022F;
            chartArea8.Position.Width = 77.58313F;
            chartArea8.Position.X = 3.91687F;
            chartArea8.Position.Y = 10.04376F;
            chartArea8.ShadowOffset = 2;
            this.BalanceHistory.ChartAreas.Add(chartArea8);
            legend8.Name = "Default";
            this.BalanceHistory.Legends.Add(legend8);
            this.BalanceHistory.Location = new System.Drawing.Point(0, 0);
            this.BalanceHistory.Margin = new System.Windows.Forms.Padding(0);
            this.BalanceHistory.Name = "BalanceHistory";
            this.BalanceHistory.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series16.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series16.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series16.BorderWidth = 2;
            series16.ChartType = "Kagi";
            series16.Color = System.Drawing.Color.YellowGreen;
            series16.Name = "Balance";
            series16.PaletteCustomColors = new System.Drawing.Color[0];
            series16.ShadowOffset = 1;
            series16.ShowLabelAsValue = true;
            series16.XValueType = Dundas.Charting.WinControl.ChartValueTypes.DateTime;
            this.BalanceHistory.Series.Add(series16);
            this.BalanceHistory.Size = new System.Drawing.Size(819, 518);
            this.BalanceHistory.TabIndex = 6;
            this.BalanceHistory.Text = "chart1";
            title8.Name = "Title1";
            title8.Text = "Balance";
            this.BalanceHistory.Titles.Add(title8);
            this.BalanceHistory.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.BalanceHistory.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.BalanceHistory.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // tbItemsDisplayed
            // 
            this.tbItemsDisplayed.Location = new System.Drawing.Point(487, 11);
            this.tbItemsDisplayed.Name = "tbItemsDisplayed";
            this.tbItemsDisplayed.Size = new System.Drawing.Size(47, 20);
            this.tbItemsDisplayed.TabIndex = 22;
            this.tbItemsDisplayed.Text = "15";
            this.tbItemsDisplayed.TextChanged += new System.EventHandler(this.tbItemsDisplayed_TextChanged);
            // 
            // descItemsDisplayed
            // 
            this.descItemsDisplayed.AutoSize = true;
            this.descItemsDisplayed.Location = new System.Drawing.Point(396, 14);
            this.descItemsDisplayed.Name = "descItemsDisplayed";
            this.descItemsDisplayed.Size = new System.Drawing.Size(85, 13);
            this.descItemsDisplayed.TabIndex = 23;
            this.descItemsDisplayed.Text = "Items displayed: ";
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(549, 9);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 24;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // cbAutomaticApply
            // 
            this.cbAutomaticApply.AutoSize = true;
            this.cbAutomaticApply.Location = new System.Drawing.Point(639, 13);
            this.cbAutomaticApply.Name = "cbAutomaticApply";
            this.cbAutomaticApply.Size = new System.Drawing.Size(76, 17);
            this.cbAutomaticApply.TabIndex = 25;
            this.cbAutomaticApply.Text = "Auto apply";
            this.cbAutomaticApply.UseVisualStyleBackColor = true;
            this.cbAutomaticApply.CheckedChanged += new System.EventHandler(this.cbAutomaticApply_CheckedChanged);
            // 
            // dtpTransactionLimit
            // 
            this.dtpTransactionLimit.Location = new System.Drawing.Point(144, 577);
            this.dtpTransactionLimit.Name = "dtpTransactionLimit";
            this.dtpTransactionLimit.Size = new System.Drawing.Size(187, 20);
            this.dtpTransactionLimit.TabIndex = 26;
            this.dtpTransactionLimit.ValueChanged += new System.EventHandler(this.dtpTransactionLimit_ValueChanged);
            // 
            // descTransactionLimit
            // 
            this.descTransactionLimit.AutoSize = true;
            this.descTransactionLimit.Location = new System.Drawing.Point(5, 581);
            this.descTransactionLimit.Name = "descTransactionLimit";
            this.descTransactionLimit.Size = new System.Drawing.Size(133, 13);
            this.descTransactionLimit.TabIndex = 27;
            this.descTransactionLimit.Text = "Limit transactions to before";
            // 
            // cbActivateTransactionLimit
            // 
            this.cbActivateTransactionLimit.AutoSize = true;
            this.cbActivateTransactionLimit.Location = new System.Drawing.Point(347, 580);
            this.cbActivateTransactionLimit.Name = "cbActivateTransactionLimit";
            this.cbActivateTransactionLimit.Size = new System.Drawing.Size(85, 17);
            this.cbActivateTransactionLimit.TabIndex = 28;
            this.cbActivateTransactionLimit.Text = "Activate limit";
            this.cbActivateTransactionLimit.UseVisualStyleBackColor = true;
            this.cbActivateTransactionLimit.CheckedChanged += new System.EventHandler(this.cbActivateTransactionLimit_CheckedChanged);
            // 
            // ReportsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbActivateTransactionLimit);
            this.Controls.Add(this.descTransactionLimit);
            this.Controls.Add(this.dtpTransactionLimit);
            this.Controls.Add(this.cbAutomaticApply);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.descItemsDisplayed);
            this.Controls.Add(this.tbItemsDisplayed);
            this.Controls.Add(this.tcReports);
            this.Controls.Add(this.ShowFor30Days);
            this.Controls.Add(this.ShowForLastWeek);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.ShowForLast3Month);
            this.Controls.Add(this.label2);
            this.Name = "ReportsTab";
            this.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.Size = new System.Drawing.Size(829, 607);
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableClientsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableStationsChart)).EndInit();
            this.tcReports.ResumeLayout(false);
            this.tpProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MostProfitableProductsChart)).EndInit();
            this.tpStation.ResumeLayout(false);
            this.tpClients.ResumeLayout(false);
            this.tpBalanceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BalanceHistory)).EndInit();
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
        private System.Windows.Forms.TabControl tcReports;
        private System.Windows.Forms.TabPage tpProduct;
        private System.Windows.Forms.TabPage tpStation;
        private System.Windows.Forms.TabPage tpClients;
        private System.Windows.Forms.TabPage tpBalanceHistory;
        private Dundas.Charting.WinControl.Chart BalanceHistory;
        private Dundas.Charting.WinControl.Chart MostProfitableProductsChart;
        private System.Windows.Forms.TextBox tbItemsDisplayed;
        private System.Windows.Forms.Label descItemsDisplayed;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.CheckBox cbAutomaticApply;
        private System.Windows.Forms.DateTimePicker dtpTransactionLimit;
        private System.Windows.Forms.Label descTransactionLimit;
        private System.Windows.Forms.CheckBox cbActivateTransactionLimit;




    }
}
