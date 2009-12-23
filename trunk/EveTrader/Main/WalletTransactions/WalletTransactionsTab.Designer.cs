namespace EveTrader.Main.WalletTransactions
{
    partial class WalletTransactionsTab
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
            this.components = new System.ComponentModel.Container();
            this.FilterByTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WalletTransactionsListView = new System.Windows.Forms.ListView();
            this.when = new System.Windows.Forms.ColumnHeader();
            this.itemName = new System.Windows.Forms.ColumnHeader();
            this.price = new System.Windows.Forms.ColumnHeader();
            this.quantity = new System.Windows.Forms.ColumnHeader();
            this.credit = new System.Windows.Forms.ColumnHeader();
            this.station = new System.Windows.Forms.ColumnHeader();
            this.client = new System.Windows.Forms.ColumnHeader();
            this.ListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterByProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBySolarSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterByStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterByClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.reportByStationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportByProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ignoreTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CharactersComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowForLastTwoDays = new System.Windows.Forms.RadioButton();
            this.ShowForLastWeek = new System.Windows.Forms.RadioButton();
            this.ShowForLast2Month = new System.Windows.Forms.RadioButton();
            this.ShowAll = new System.Windows.Forms.RadioButton();
            this.ListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterByTextBox
            // 
            this.FilterByTextBox.Location = new System.Drawing.Point(60, 11);
            this.FilterByTextBox.Name = "FilterByTextBox";
            this.FilterByTextBox.Size = new System.Drawing.Size(209, 20);
            this.FilterByTextBox.TabIndex = 5;
            this.FilterByTextBox.TextChanged += new System.EventHandler(this.FilterByTextBox_TextChanged);
            this.FilterByTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterByTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter by";
            // 
            // WalletTransactionsListView
            // 
            this.WalletTransactionsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WalletTransactionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.when,
            this.itemName,
            this.price,
            this.quantity,
            this.credit,
            this.station,
            this.client});
            this.WalletTransactionsListView.ContextMenuStrip = this.ListContextMenu;
            this.WalletTransactionsListView.FullRowSelect = true;
            this.WalletTransactionsListView.Location = new System.Drawing.Point(0, 40);
            this.WalletTransactionsListView.Name = "WalletTransactionsListView";
            this.WalletTransactionsListView.Size = new System.Drawing.Size(948, 359);
            this.WalletTransactionsListView.TabIndex = 3;
            this.WalletTransactionsListView.UseCompatibleStateImageBehavior = false;
            this.WalletTransactionsListView.View = System.Windows.Forms.View.Details;
            this.WalletTransactionsListView.SelectedIndexChanged += new System.EventHandler(this.WalletTransactionsListView_SelectedIndexChanged);
            // 
            // when
            // 
            this.when.Text = "When";
            // 
            // itemName
            // 
            this.itemName.Text = "Product";
            this.itemName.Width = 210;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.price.Width = 120;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // credit
            // 
            this.credit.Text = "Credit";
            this.credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.credit.Width = 120;
            // 
            // station
            // 
            this.station.Text = "Station";
            this.station.Width = 260;
            // 
            // client
            // 
            this.client.Text = "Client";
            this.client.Width = 100;
            // 
            // ListContextMenu
            // 
            this.ListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByProductToolStripMenuItem,
            this.filterBySolarSystemToolStripMenuItem,
            this.filterByStationToolStripMenuItem,
            this.filterByClientToolStripMenuItem,
            this.toolStripMenuItem2,
            this.reportByStationsToolStripMenuItem,
            this.reportByProductToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ignoreTransactionToolStripMenuItem});
            this.ListContextMenu.Name = "ListContextMenu";
            this.ListContextMenu.Size = new System.Drawing.Size(188, 192);
            // 
            // filterByProductToolStripMenuItem
            // 
            this.filterByProductToolStripMenuItem.Name = "filterByProductToolStripMenuItem";
            this.filterByProductToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.filterByProductToolStripMenuItem.Text = "Filter by product";
            this.filterByProductToolStripMenuItem.Click += new System.EventHandler(this.filterByProductToolStripMenuItem_Click);
            // 
            // filterBySolarSystemToolStripMenuItem
            // 
            this.filterBySolarSystemToolStripMenuItem.Name = "filterBySolarSystemToolStripMenuItem";
            this.filterBySolarSystemToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.filterBySolarSystemToolStripMenuItem.Text = "Filter by solar system";
            this.filterBySolarSystemToolStripMenuItem.Click += new System.EventHandler(this.filterBySolarSystemToolStripMenuItem_Click);
            // 
            // filterByStationToolStripMenuItem
            // 
            this.filterByStationToolStripMenuItem.Name = "filterByStationToolStripMenuItem";
            this.filterByStationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.filterByStationToolStripMenuItem.Text = "Filter by station";
            this.filterByStationToolStripMenuItem.Click += new System.EventHandler(this.filterByStationToolStripMenuItem_Click);
            // 
            // filterByClientToolStripMenuItem
            // 
            this.filterByClientToolStripMenuItem.Name = "filterByClientToolStripMenuItem";
            this.filterByClientToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.filterByClientToolStripMenuItem.Text = "Filter by client";
            this.filterByClientToolStripMenuItem.Click += new System.EventHandler(this.filterByClientToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // reportByStationsToolStripMenuItem
            // 
            this.reportByStationsToolStripMenuItem.Enabled = false;
            this.reportByStationsToolStripMenuItem.Name = "reportByStationsToolStripMenuItem";
            this.reportByStationsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reportByStationsToolStripMenuItem.Text = "Report by station";
            this.reportByStationsToolStripMenuItem.Click += new System.EventHandler(this.reportByStationToolStripMenuItem_Click);
            // 
            // reportByProductToolStripMenuItem
            // 
            this.reportByProductToolStripMenuItem.Enabled = false;
            this.reportByProductToolStripMenuItem.Name = "reportByProductToolStripMenuItem";
            this.reportByProductToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reportByProductToolStripMenuItem.Text = "Report by product";
            this.reportByProductToolStripMenuItem.Click += new System.EventHandler(this.reportByProductToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // ignoreTransactionToolStripMenuItem
            // 
            this.ignoreTransactionToolStripMenuItem.Name = "ignoreTransactionToolStripMenuItem";
            this.ignoreTransactionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ignoreTransactionToolStripMenuItem.Text = "Ignore";
            this.ignoreTransactionToolStripMenuItem.Click += new System.EventHandler(this.ignoreTransactionToolStripMenuItem_Click);
            // 
            // CharactersComboBox
            // 
            this.CharactersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CharactersComboBox.DisplayMember = "Name";
            this.CharactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharactersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CharactersComboBox.FormattingEnabled = true;
            this.CharactersComboBox.Location = new System.Drawing.Point(735, 11);
            this.CharactersComboBox.Name = "CharactersComboBox";
            this.CharactersComboBox.Size = new System.Drawing.Size(202, 21);
            this.CharactersComboBox.TabIndex = 7;
            this.CharactersComboBox.ValueMember = "Name";
            this.CharactersComboBox.SelectedIndexChanged += new System.EventHandler(this.CharactersComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Show for:";
            // 
            // ShowForLastTwoDays
            // 
            this.ShowForLastTwoDays.AutoSize = true;
            this.ShowForLastTwoDays.Location = new System.Drawing.Point(343, 12);
            this.ShowForLastTwoDays.Name = "ShowForLastTwoDays";
            this.ShowForLastTwoDays.Size = new System.Drawing.Size(56, 17);
            this.ShowForLastTwoDays.TabIndex = 9;
            this.ShowForLastTwoDays.Text = "2 days";
            this.ShowForLastTwoDays.UseVisualStyleBackColor = true;
            this.ShowForLastTwoDays.Click += new System.EventHandler(this.ShowForLastTwoDays_Click);
            // 
            // ShowForLastWeek
            // 
            this.ShowForLastWeek.AutoSize = true;
            this.ShowForLastWeek.Checked = true;
            this.ShowForLastWeek.Location = new System.Drawing.Point(405, 12);
            this.ShowForLastWeek.Name = "ShowForLastWeek";
            this.ShowForLastWeek.Size = new System.Drawing.Size(56, 17);
            this.ShowForLastWeek.TabIndex = 10;
            this.ShowForLastWeek.TabStop = true;
            this.ShowForLastWeek.Text = "7 days";
            this.ShowForLastWeek.UseVisualStyleBackColor = true;
            this.ShowForLastWeek.Click += new System.EventHandler(this.ShowForLastWeek_Click);
            // 
            // ShowForLast2Month
            // 
            this.ShowForLast2Month.AutoSize = true;
            this.ShowForLast2Month.Location = new System.Drawing.Point(467, 12);
            this.ShowForLast2Month.Name = "ShowForLast2Month";
            this.ShowForLast2Month.Size = new System.Drawing.Size(68, 17);
            this.ShowForLast2Month.TabIndex = 11;
            this.ShowForLast2Month.Text = "2 months";
            this.ShowForLast2Month.UseVisualStyleBackColor = true;
            this.ShowForLast2Month.Click += new System.EventHandler(this.ShowForLast2Month_Click);
            // 
            // ShowAll
            // 
            this.ShowAll.AutoSize = true;
            this.ShowAll.Location = new System.Drawing.Point(541, 12);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(58, 17);
            this.ShowAll.TabIndex = 12;
            this.ShowAll.Text = "All time";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // WalletTransactionsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShowForLastWeek);
            this.Controls.Add(this.ShowForLast2Month);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.FilterByTextBox);
            this.Controls.Add(this.ShowForLastTwoDays);
            this.Controls.Add(this.WalletTransactionsListView);
            this.Controls.Add(this.CharactersComboBox);
            this.Name = "WalletTransactionsTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(948, 399);
            this.ListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilterByTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView WalletTransactionsListView;
        private System.Windows.Forms.ColumnHeader when;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader credit;
        private System.Windows.Forms.ColumnHeader station;
        private System.Windows.Forms.ColumnHeader client;
        private System.Windows.Forms.ContextMenuStrip ListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem reportByStationsToolStripMenuItem;
        private System.Windows.Forms.ComboBox CharactersComboBox;
        private System.Windows.Forms.ToolStripMenuItem reportByProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterBySolarSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterByClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem filterByProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterByStationToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton ShowForLastTwoDays;
        private System.Windows.Forms.RadioButton ShowForLastWeek;
        private System.Windows.Forms.RadioButton ShowForLast2Month;
        private System.Windows.Forms.RadioButton ShowAll;
        private System.Windows.Forms.ToolStripMenuItem ignoreTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}
