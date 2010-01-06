namespace EveTrader.Main.Dashboard
{
    partial class DashboardTab
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
            System.Windows.Forms.RadioButton SalesAmount7;
            System.Windows.Forms.RadioButton SalesAmount14;
            System.Windows.Forms.RadioButton SalesAmount30;
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series2 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series3 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea2 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend2 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series4 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series5 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title2 = new Dundas.Charting.WinControl.Title();
            this.SalesDetailsChart = new Dundas.Charting.WinControl.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SalesAmountChart = new Dundas.Charting.WinControl.Chart();
            this.ShowSalesPanel = new System.Windows.Forms.Panel();
            this.SalesAmount21 = new System.Windows.Forms.RadioButton();
            this.ShowSalesFor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShowInvestmentLabelsRadioButton = new System.Windows.Forms.RadioButton();
            this.ShowDetailedLabelsRadioButton = new System.Windows.Forms.RadioButton();
            this.ShowProfitLabelsRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            SalesAmount7 = new System.Windows.Forms.RadioButton();
            SalesAmount14 = new System.Windows.Forms.RadioButton();
            SalesAmount30 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDetailsChart)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAmountChart)).BeginInit();
            this.ShowSalesPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SalesAmount7
            // 
            SalesAmount7.AutoSize = true;
            SalesAmount7.Location = new System.Drawing.Point(292, -2);
            SalesAmount7.Name = "SalesAmount7";
            SalesAmount7.Size = new System.Drawing.Size(56, 17);
            SalesAmount7.TabIndex = 14;
            SalesAmount7.TabStop = true;
            SalesAmount7.Tag = "7";
            SalesAmount7.Text = "7 days";
            SalesAmount7.UseVisualStyleBackColor = true;
            SalesAmount7.Click += new System.EventHandler(this.ChangeSalesAmountDaysToShow_Click);
            // 
            // SalesAmount14
            // 
            SalesAmount14.AutoSize = true;
            SalesAmount14.Location = new System.Drawing.Point(224, -2);
            SalesAmount14.Name = "SalesAmount14";
            SalesAmount14.Size = new System.Drawing.Size(62, 17);
            SalesAmount14.TabIndex = 12;
            SalesAmount14.TabStop = true;
            SalesAmount14.Tag = "14";
            SalesAmount14.Text = "14 days";
            SalesAmount14.UseVisualStyleBackColor = true;
            SalesAmount14.Click += new System.EventHandler(this.ChangeSalesAmountDaysToShow_Click);
            // 
            // SalesAmount30
            // 
            SalesAmount30.AutoSize = true;
            SalesAmount30.Location = new System.Drawing.Point(88, -2);
            SalesAmount30.Name = "SalesAmount30";
            SalesAmount30.Size = new System.Drawing.Size(62, 17);
            SalesAmount30.TabIndex = 11;
            SalesAmount30.TabStop = true;
            SalesAmount30.Tag = "30";
            SalesAmount30.Text = "30 days";
            SalesAmount30.UseVisualStyleBackColor = true;
            SalesAmount30.Click += new System.EventHandler(this.ChangeSalesAmountDaysToShow_Click);

            // 
            // SalesDetailsChart
            // 
            this.SalesDetailsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesDetailsChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SalesDetailsChart.BackGradientEndColor = System.Drawing.Color.White;
            this.SalesDetailsChart.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.SalesDetailsChart.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.SalesDetailsChart.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.SalesDetailsChart.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.SalesDetailsChart.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.SalesDetailsChart.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.SalesDetailsChart.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Light = Dundas.Charting.WinControl.LightStyle.Realistic;
            chartArea1.AxisX.Crossing = -1.7976931348623157E+308;
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.LabelsAutoFit = false;
            chartArea1.AxisX.LabelsAutoFitStyle = ((Dundas.Charting.WinControl.LabelsAutoFitStyle)((((Dundas.Charting.WinControl.LabelsAutoFitStyle.IncreaseFont | Dundas.Charting.WinControl.LabelsAutoFitStyle.DecreaseFont)
                        | Dundas.Charting.WinControl.LabelsAutoFitStyle.OffsetLabels)
                        | Dundas.Charting.WinControl.LabelsAutoFitStyle.WordWrap)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.ScrollBar.Buttons = Dundas.Charting.WinControl.ScrollBarButtonStyle.None;
            chartArea1.AxisX.View.Zoomable = false;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorTickMark.Style = Dundas.Charting.WinControl.TickMarkStyle.Cross;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            this.SalesDetailsChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend1.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend1.Name = "Default";
            this.SalesDetailsChart.Legends.Add(legend1);
            this.SalesDetailsChart.Location = new System.Drawing.Point(-2, 0);
            this.SalesDetailsChart.Margin = new System.Windows.Forms.Padding(0);
            this.SalesDetailsChart.Name = "SalesDetailsChart";
            this.SalesDetailsChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series1.AxisLabel = "Label";
            series1.BackGradientEndColor = System.Drawing.Color.ForestGreen;
            series1.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.ChartType = "Bar";
            series1.Color = System.Drawing.Color.YellowGreen;
            series1.CustomAttributes = "PieLabelStyle=Outside";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Name = "Profit";
            series1.PaletteCustomColors = new System.Drawing.Color[0];
            series1.ShadowOffset = 2;
            series1.ShowLabelAsValue = true;
            series1.SmartLabels.Enabled = true;
            series1.ValueMembersY = "Value";
            series1.ValueMemberX = "Label";
            series1.XValueType = Dundas.Charting.WinControl.ChartValueTypes.String;
            series1.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series2.BackGradientEndColor = System.Drawing.Color.DarkOrange;
            series2.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series2.BorderWidth = 0;
            series2.ChartType = "Bar";
            series2.Color = System.Drawing.Color.Gold;
            series2.Name = "Sales amount";
            series2.PaletteCustomColors = new System.Drawing.Color[0];
            series2.ShadowOffset = 2;
            series2.ShowLabelAsValue = true;
            series2.ValueMembersY = "Value";
            series2.ValueMemberX = "Label";
            series3.BackGradientEndColor = System.Drawing.Color.Crimson;
            series3.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalRight;
            series3.BorderWidth = 0;
            series3.ChartType = "Bar";
            series3.Color = System.Drawing.Color.OrangeRed;
            series3.Name = "Investments";
            series3.PaletteCustomColors = new System.Drawing.Color[0];
            series3.ShadowOffset = 2;
            series3.ShowLabelAsValue = true;
            series3.ValueMembersY = "Label";
            series3.ValueMemberX = "Value";
            this.SalesDetailsChart.Series.Add(series1);
            this.SalesDetailsChart.Series.Add(series2);
            this.SalesDetailsChart.Series.Add(series3);
            this.SalesDetailsChart.Size = new System.Drawing.Size(358, 470);
            this.SalesDetailsChart.TabIndex = 4;
            this.SalesDetailsChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Daily sales details";
            this.SalesDetailsChart.Titles.Add(title1);
            this.SalesDetailsChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.SalesDetailsChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.SalesDetailsChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SalesAmountChart);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SalesDetailsChart);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(887, 470);
            this.splitContainer1.SplitterDistance = 519;
            this.splitContainer1.TabIndex = 9;
            // 
            // SalesAmountChart
            // 
            this.SalesAmountChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SalesAmountChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SalesAmountChart.BackGradientEndColor = System.Drawing.Color.White;
            this.SalesAmountChart.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.SalesAmountChart.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.SalesAmountChart.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.SalesAmountChart.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.SalesAmountChart.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.SalesAmountChart.BorderSkin.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SalesAmountChart.BorderSkin.FrameBorderWidth = 2;
            this.SalesAmountChart.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.SalesAmountChart.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorTickMark.Size = 2F;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorTickMark.Size = 2F;
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.LightGray;
            chartArea2.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea2.Name = "Default";
            chartArea2.ShadowOffset = 2;
            this.SalesAmountChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            legend2.BorderWidth = 0;
            legend2.Docking = Dundas.Charting.WinControl.LegendDocking.Bottom;
            legend2.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend2.Name = "Default";
            legend2.TextWrapThreshold = 100;
            this.SalesAmountChart.Legends.Add(legend2);
            this.SalesAmountChart.Location = new System.Drawing.Point(0, 0);
            this.SalesAmountChart.Margin = new System.Windows.Forms.Padding(0);
            this.SalesAmountChart.Name = "SalesAmountChart";
            this.SalesAmountChart.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series4.ChartType = "Point";
            series4.CustomAttributes = "LabelStyle=Top";
            series4.FontColor = System.Drawing.Color.Gray;
            series4.MarkerSize = 9;
            series4.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
            series4.Name = "Total";
            series4.PaletteCustomColors = new System.Drawing.Color[0];
            series4.ShadowOffset = 2;
            series4.ShowLabelAsValue = true;
            series5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series5.BorderWidth = 2;
            series5.ChartType = "Line";
            series5.Color = System.Drawing.Color.DarkGreen;
            series5.MarkerSize = 8;
            series5.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            series5.Name = "Daily profit";
            series5.PaletteCustomColors = new System.Drawing.Color[0];
            series5.ShadowOffset = 2;
            series5.ShowLabelAsValue = true;
            series5.SmartLabels.Enabled = true;
            this.SalesAmountChart.Series.Add(series4);
            this.SalesAmountChart.Series.Add(series5);
            this.SalesAmountChart.Size = new System.Drawing.Size(520, 470);
            this.SalesAmountChart.TabIndex = 5;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Title1";
            title2.Text = "Daily sales amount";
            this.SalesAmountChart.Titles.Add(title2);
            this.SalesAmountChart.UI.Toolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.SalesAmountChart.UI.Toolbar.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.SalesAmountChart.UI.Toolbar.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            this.SalesAmountChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SalesAmountChart_MouseMove);
            // 
            // ShowSalesPanel
            // 
            this.ShowSalesPanel.Controls.Add(this.SalesAmount21);
            this.ShowSalesPanel.Controls.Add(SalesAmount7);
            this.ShowSalesPanel.Controls.Add(this.ShowSalesFor);
            this.ShowSalesPanel.Controls.Add(SalesAmount14);
            this.ShowSalesPanel.Controls.Add(SalesAmount30);
            this.ShowSalesPanel.Location = new System.Drawing.Point(8, 14);
            this.ShowSalesPanel.Name = "ShowSalesPanel";
            this.ShowSalesPanel.Size = new System.Drawing.Size(588, 23);
            this.ShowSalesPanel.TabIndex = 11;
            // 
            // SalesAmount21
            // 
            this.SalesAmount21.AutoSize = true;
            this.SalesAmount21.Location = new System.Drawing.Point(156, -2);
            this.SalesAmount21.Name = "SalesAmount21";
            this.SalesAmount21.Size = new System.Drawing.Size(62, 17);
            this.SalesAmount21.TabIndex = 15;
            this.SalesAmount21.TabStop = true;
            this.SalesAmount21.Tag = "21";
            this.SalesAmount21.Text = "21 days";
            this.SalesAmount21.UseVisualStyleBackColor = true;
            this.SalesAmount21.Click += new System.EventHandler(this.ChangeSalesAmountDaysToShow_Click);
            // 
            // ShowSalesFor
            // 
            this.ShowSalesFor.AutoSize = true;
            this.ShowSalesFor.Location = new System.Drawing.Point(3, 0);
            this.ShowSalesFor.Name = "ShowSalesFor";
            this.ShowSalesFor.Size = new System.Drawing.Size(79, 13);
            this.ShowSalesFor.TabIndex = 13;
            this.ShowSalesFor.Text = "Show sales for:";
            this.ShowSalesFor.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.ShowInvestmentLabelsRadioButton);
            this.panel2.Controls.Add(this.ShowDetailedLabelsRadioButton);
            this.panel2.Controls.Add(this.ShowProfitLabelsRadioButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(11, 516);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 24);
            this.panel2.TabIndex = 12;
            // 
            // ShowInvestmentLabelsRadioButton
            // 
            this.ShowInvestmentLabelsRadioButton.AutoSize = true;
            this.ShowInvestmentLabelsRadioButton.Location = new System.Drawing.Point(131, 1);
            this.ShowInvestmentLabelsRadioButton.Name = "ShowInvestmentLabelsRadioButton";
            this.ShowInvestmentLabelsRadioButton.Size = new System.Drawing.Size(77, 17);
            this.ShowInvestmentLabelsRadioButton.TabIndex = 3;
            this.ShowInvestmentLabelsRadioButton.TabStop = true;
            this.ShowInvestmentLabelsRadioButton.Text = "Investment";
            this.ShowInvestmentLabelsRadioButton.UseVisualStyleBackColor = true;
            this.ShowInvestmentLabelsRadioButton.Click += new System.EventHandler(this.ShowInvestmentLabelsRadioButton_Click);
            // 
            // ShowDetailedLabelsRadioButton
            // 
            this.ShowDetailedLabelsRadioButton.AutoSize = true;
            this.ShowDetailedLabelsRadioButton.Location = new System.Drawing.Point(214, 1);
            this.ShowDetailedLabelsRadioButton.Name = "ShowDetailedLabelsRadioButton";
            this.ShowDetailedLabelsRadioButton.Size = new System.Drawing.Size(84, 17);
            this.ShowDetailedLabelsRadioButton.TabIndex = 2;
            this.ShowDetailedLabelsRadioButton.Text = "Sales details";
            this.ShowDetailedLabelsRadioButton.UseVisualStyleBackColor = true;
            this.ShowDetailedLabelsRadioButton.Click += new System.EventHandler(this.ShowDetailedLabelsRadioButton_Click);
            // 
            // ShowProfitLabelsRadioButton
            // 
            this.ShowProfitLabelsRadioButton.AutoSize = true;
            this.ShowProfitLabelsRadioButton.Checked = true;
            this.ShowProfitLabelsRadioButton.Location = new System.Drawing.Point(76, 1);
            this.ShowProfitLabelsRadioButton.Name = "ShowProfitLabelsRadioButton";
            this.ShowProfitLabelsRadioButton.Size = new System.Drawing.Size(49, 17);
            this.ShowProfitLabelsRadioButton.TabIndex = 1;
            this.ShowProfitLabelsRadioButton.TabStop = true;
            this.ShowProfitLabelsRadioButton.Text = "Profit";
            this.ShowProfitLabelsRadioButton.UseVisualStyleBackColor = true;
            this.ShowProfitLabelsRadioButton.Click += new System.EventHandler(this.ShowProfitLabelsRadioButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Show labels:";
            // 
            // DashboardTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ShowSalesPanel);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DashboardTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(887, 551);
            this.Load += new System.EventHandler(this.DashboardTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SalesDetailsChart)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SalesAmountChart)).EndInit();
            this.ShowSalesPanel.ResumeLayout(false);
            this.ShowSalesPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Dundas.Charting.WinControl.Chart SalesDetailsChart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel ShowSalesPanel;
        private System.Windows.Forms.RadioButton SalesAmount21;
        private System.Windows.Forms.Label ShowSalesFor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton ShowDetailedLabelsRadioButton;
        private System.Windows.Forms.RadioButton ShowProfitLabelsRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton ShowInvestmentLabelsRadioButton;
        private Dundas.Charting.WinControl.Chart SalesAmountChart;


    }
}
