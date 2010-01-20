using System.Windows.Forms;

namespace EveTrader.Main.MarketOrders
{
    partial class MarketOrdersTab
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
            System.Windows.Forms.Label label2;
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SellOrdersListView = new System.Windows.Forms.ListView();
            this.orderStatusColumn = new System.Windows.Forms.ColumnHeader();
            this.productColumn = new System.Windows.Forms.ColumnHeader();
            this.priceColumn = new System.Windows.Forms.ColumnHeader();
            this.quantityColumn = new System.Windows.Forms.ColumnHeader();
            this.inEcrowColumn = new System.Windows.Forms.ColumnHeader();
            this.soldOutColumn = new System.Windows.Forms.ColumnHeader();
            this.estimatedColumn = new System.Windows.Forms.ColumnHeader();
            this.locationColumn = new System.Windows.Forms.ColumnHeader();
            this.expiresInColumn = new System.Windows.Forms.ColumnHeader();
            this.ListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterByProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBySolarSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterByStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuyOrdersListView = new System.Windows.Forms.ListView();
            this.CharactersComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalInExcrowLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalIncomeLabel = new System.Windows.Forms.Label();
            this.GroupByProductRadioButton = new System.Windows.Forms.RadioButton();
            this.GroupBySolarSystemRadioButton = new System.Windows.Forms.RadioButton();
            this.DoNotGroupRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.FilterByTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHideExpired = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(275, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 13);
            label2.TabIndex = 14;
            label2.Text = "Group by:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SellOrdersListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BuyOrdersListView);
            this.splitContainer1.Size = new System.Drawing.Size(900, 237);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 0;
            // 
            // SellOrdersListView
            // 
            this.SellOrdersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SellOrdersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderStatusColumn,
            this.productColumn,
            this.priceColumn,
            this.quantityColumn,
            this.inEcrowColumn,
            this.soldOutColumn,
            this.estimatedColumn,
            this.locationColumn,
            this.expiresInColumn});
            this.SellOrdersListView.ContextMenuStrip = this.ListContextMenu;
            this.SellOrdersListView.FullRowSelect = true;
            this.SellOrdersListView.Location = new System.Drawing.Point(0, 0);
            this.SellOrdersListView.Name = "SellOrdersListView";
            this.SellOrdersListView.Size = new System.Drawing.Size(900, 118);
            this.SellOrdersListView.TabIndex = 0;
            this.SellOrdersListView.UseCompatibleStateImageBehavior = false;
            this.SellOrdersListView.View = System.Windows.Forms.View.Details;
            this.SellOrdersListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SellOrdersListView_ColumnClick);
            // 
            // orderStatusColumn
            // 
            this.orderStatusColumn.Text = "Status";
            this.orderStatusColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // productColumn
            // 
            this.productColumn.Text = "Product";
            this.productColumn.Width = 210;
            // 
            // priceColumn
            // 
            this.priceColumn.Text = "Price";
            this.priceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceColumn.Width = 120;
            // 
            // quantityColumn
            // 
            this.quantityColumn.Text = "Quantity";
            this.quantityColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.quantityColumn.Width = 100;
            // 
            // inEcrowColumn
            // 
            this.inEcrowColumn.Text = "Expected";
            this.inEcrowColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inEcrowColumn.Width = 120;
            // 
            // soldOutColumn
            // 
            this.soldOutColumn.Text = "ETCB";
            this.soldOutColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soldOutColumn.Width = 55;
            // 
            // estimatedColumn
            // 
            this.estimatedColumn.Text = "Estimated";
            this.estimatedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.estimatedColumn.Width = 120;
            // 
            // locationColumn
            // 
            this.locationColumn.Text = "Location";
            this.locationColumn.Width = 260;
            // 
            // expiresInColumn
            // 
            this.expiresInColumn.Text = "Expires in";
            this.expiresInColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ListContextMenu
            // 
            this.ListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByProductToolStripMenuItem,
            this.filterBySolarSystemToolStripMenuItem,
            this.filterByStationToolStripMenuItem});
            this.ListContextMenu.Name = "ListContextMenu";
            this.ListContextMenu.Size = new System.Drawing.Size(188, 70);
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
            // BuyOrdersListView
            // 
            this.BuyOrdersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyOrdersListView.ContextMenuStrip = this.ListContextMenu;
            this.BuyOrdersListView.FullRowSelect = true;
            this.BuyOrdersListView.Location = new System.Drawing.Point(0, 0);
            this.BuyOrdersListView.Name = "BuyOrdersListView";
            this.BuyOrdersListView.Size = new System.Drawing.Size(900, 115);
            this.BuyOrdersListView.TabIndex = 0;
            this.BuyOrdersListView.UseCompatibleStateImageBehavior = false;
            this.BuyOrdersListView.View = System.Windows.Forms.View.Details;
            this.BuyOrdersListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.BuyOrdersListView_ColumnClick);
            // 
            // CharactersComboBox
            // 
            this.CharactersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CharactersComboBox.DisplayMember = "Name";
            this.CharactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CharactersComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CharactersComboBox.FormattingEnabled = true;
            this.CharactersComboBox.Location = new System.Drawing.Point(687, 11);
            this.CharactersComboBox.Name = "CharactersComboBox";
            this.CharactersComboBox.Size = new System.Drawing.Size(202, 21);
            this.CharactersComboBox.TabIndex = 8;
            this.CharactersComboBox.ValueMember = "Name";
            this.CharactersComboBox.SelectedIndexChanged += new System.EventHandler(this.CharactersComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total in escrow:";
            // 
            // TotalInExcrowLabel
            // 
            this.TotalInExcrowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalInExcrowLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.TotalInExcrowLabel.Location = new System.Drawing.Point(100, 284);
            this.TotalInExcrowLabel.Name = "TotalInExcrowLabel";
            this.TotalInExcrowLabel.Size = new System.Drawing.Size(156, 13);
            this.TotalInExcrowLabel.TabIndex = 10;
            this.TotalInExcrowLabel.Text = "0,00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Total income:";
            // 
            // TotalIncomeLabel
            // 
            this.TotalIncomeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalIncomeLabel.AutoSize = true;
            this.TotalIncomeLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.TotalIncomeLabel.Location = new System.Drawing.Point(407, 284);
            this.TotalIncomeLabel.Name = "TotalIncomeLabel";
            this.TotalIncomeLabel.Size = new System.Drawing.Size(28, 13);
            this.TotalIncomeLabel.TabIndex = 12;
            this.TotalIncomeLabel.Text = "0,00";
            // 
            // GroupByProductRadioButton
            // 
            this.GroupByProductRadioButton.AutoSize = true;
            this.GroupByProductRadioButton.Location = new System.Drawing.Point(431, 12);
            this.GroupByProductRadioButton.Name = "GroupByProductRadioButton";
            this.GroupByProductRadioButton.Size = new System.Drawing.Size(62, 17);
            this.GroupByProductRadioButton.TabIndex = 13;
            this.GroupByProductRadioButton.Text = "Product";
            this.GroupByProductRadioButton.UseVisualStyleBackColor = true;
            this.GroupByProductRadioButton.Click += new System.EventHandler(this.GroupByProductRadioButton_Click);
            // 
            // GroupBySolarSystemRadioButton
            // 
            this.GroupBySolarSystemRadioButton.AutoSize = true;
            this.GroupBySolarSystemRadioButton.Checked = true;
            this.GroupBySolarSystemRadioButton.Location = new System.Drawing.Point(499, 12);
            this.GroupBySolarSystemRadioButton.Name = "GroupBySolarSystemRadioButton";
            this.GroupBySolarSystemRadioButton.Size = new System.Drawing.Size(84, 17);
            this.GroupBySolarSystemRadioButton.TabIndex = 15;
            this.GroupBySolarSystemRadioButton.TabStop = true;
            this.GroupBySolarSystemRadioButton.Text = "Solar system";
            this.GroupBySolarSystemRadioButton.UseVisualStyleBackColor = true;
            this.GroupBySolarSystemRadioButton.Click += new System.EventHandler(this.GroupBySolarSystemRadioButton_Click);
            // 
            // DoNotGroupRadioButton
            // 
            this.DoNotGroupRadioButton.AutoSize = true;
            this.DoNotGroupRadioButton.Location = new System.Drawing.Point(338, 12);
            this.DoNotGroupRadioButton.Name = "DoNotGroupRadioButton";
            this.DoNotGroupRadioButton.Size = new System.Drawing.Size(87, 17);
            this.DoNotGroupRadioButton.TabIndex = 16;
            this.DoNotGroupRadioButton.TabStop = true;
            this.DoNotGroupRadioButton.Text = "Do not group";
            this.DoNotGroupRadioButton.UseVisualStyleBackColor = true;
            this.DoNotGroupRadioButton.Click += new System.EventHandler(this.DoNotGroupRadioButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Filter by";
            // 
            // FilterByTextBox
            // 
            this.FilterByTextBox.Location = new System.Drawing.Point(60, 11);
            this.FilterByTextBox.Name = "FilterByTextBox";
            this.FilterByTextBox.Size = new System.Drawing.Size(209, 20);
            this.FilterByTextBox.TabIndex = 18;
            this.FilterByTextBox.TextChanged += new System.EventHandler(this.FilterByTextBox_TextChanged);
            this.FilterByTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterByTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "estimated / expected";
            // 
            // cbHideExpired
            // 
            this.cbHideExpired.AutoSize = true;
            this.cbHideExpired.Location = new System.Drawing.Point(589, 13);
            this.cbHideExpired.Name = "cbHideExpired";
            this.cbHideExpired.Size = new System.Drawing.Size(85, 17);
            this.cbHideExpired.TabIndex = 20;
            this.cbHideExpired.Text = "Hide expired";
            this.cbHideExpired.UseVisualStyleBackColor = true;
            this.cbHideExpired.CheckedChanged += new System.EventHandler(this.cbHideExpired_CheckedChanged);
            // 
            // MarketOrdersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbHideExpired);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FilterByTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.DoNotGroupRadioButton);
            this.Controls.Add(this.GroupBySolarSystemRadioButton);
            this.Controls.Add(this.TotalIncomeLabel);
            this.Controls.Add(this.GroupByProductRadioButton);
            this.Controls.Add(this.CharactersComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotalInExcrowLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MarketOrdersTab";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(900, 305);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox CharactersComboBox;
        private System.Windows.Forms.ListView SellOrdersListView;
        private System.Windows.Forms.ColumnHeader productColumn;
        private System.Windows.Forms.ListView BuyOrdersListView;
        private System.Windows.Forms.ColumnHeader priceColumn;
        private System.Windows.Forms.ColumnHeader locationColumn;
        private System.Windows.Forms.ColumnHeader expiresInColumn;
        private ColumnHeader orderStatusColumn;
        private ColumnHeader quantityColumn;
        private ColumnHeader inEcrowColumn;
        private Label label1;
        private Label TotalInExcrowLabel;
        private Label label3;
        private Label TotalIncomeLabel;
        private RadioButton GroupByProductRadioButton;
        private RadioButton GroupBySolarSystemRadioButton;
        private RadioButton DoNotGroupRadioButton;
        private Label label4;
        private TextBox FilterByTextBox;
        private ContextMenuStrip ListContextMenu;
        private ToolStripMenuItem filterByProductToolStripMenuItem;
        private ToolStripMenuItem filterBySolarSystemToolStripMenuItem;
        private ToolStripMenuItem filterByStationToolStripMenuItem;
        private ColumnHeader soldOutColumn;
        private ColumnHeader estimatedColumn;
        private Label label5;
        private CheckBox cbHideExpired;
    }
}
