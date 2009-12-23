namespace EveTrader.Main.CrossRegionalMarket
{
    partial class EveRegionalMarketView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SellOrdersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.BuyOrdersListView = new System.Windows.Forms.ListView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(1002, 416);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 2;
            // 
            // SellOrdersListView
            // 
            this.SellOrdersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4});
            this.SellOrdersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellOrdersListView.Location = new System.Drawing.Point(0, 0);
            this.SellOrdersListView.Name = "SellOrdersListView";
            this.SellOrdersListView.Size = new System.Drawing.Size(1002, 204);
            this.SellOrdersListView.TabIndex = 0;
            this.SellOrdersListView.UseCompatibleStateImageBehavior = false;
            this.SellOrdersListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Region";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Station";
            this.columnHeader5.Width = 260;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Expires";
            this.columnHeader4.Width = 120;
            // 
            // BuyOrdersListView
            // 
            this.BuyOrdersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyOrdersListView.Location = new System.Drawing.Point(0, 0);
            this.BuyOrdersListView.Name = "BuyOrdersListView";
            this.BuyOrdersListView.Size = new System.Drawing.Size(1002, 208);
            this.BuyOrdersListView.TabIndex = 0;
            this.BuyOrdersListView.UseCompatibleStateImageBehavior = false;
            this.BuyOrdersListView.View = System.Windows.Forms.View.Details;
            // 
            // EveRegionalMarketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EveRegionalMarketView";
            this.Size = new System.Drawing.Size(1002, 416);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView SellOrdersListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView BuyOrdersListView;

    }
}
