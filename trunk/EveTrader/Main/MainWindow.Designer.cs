using AssetsTab=EveTrader.Main.Assets.AssetsTab;
using CrossRegionalMarketTab=EveTrader.Main.CrossRegionalMarket.CrossRegionalMarketTab;
using DashboardTab=EveTrader.Main.Dashboard.DashboardTab;
using MarketOrdersTab=EveTrader.Main.MarketOrders.MarketOrdersTab;
using ReportsTab=EveTrader.Main.Reports.ReportsTab;
using StarMapTab=EveTrader.Main.StarMap.StarMapTab;
using WalletTransactionsTab=EveTrader.Main.WalletTransactions.WalletTransactionsTab;

namespace EveTrader.Main
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.StatusToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AsyncOperationToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppVersionToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.DashboardTab = new EveTrader.Main.Dashboard.DashboardTab();
            this.tabWallets = new System.Windows.Forms.TabPage();
            this.CharactersTab = new EveTrader.Main.Characters.CharactersTab();
            this.tabWalletTransactions = new System.Windows.Forms.TabPage();
            this.WalletTransactionsTab = new EveTrader.Main.WalletTransactions.WalletTransactionsTab();
            this.tabCustomTransaction = new System.Windows.Forms.TabPage();
            this.tabMarketOrders = new System.Windows.Forms.TabPage();
            this.MarketOrdersTab = new EveTrader.Main.MarketOrders.MarketOrdersTab();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.ReportsTab = new EveTrader.Main.Reports.ReportsTab();
            this.tabStarMap = new System.Windows.Forms.TabPage();
            this.starMapTab = new EveTrader.Main.StarMap.StarMapTab();
            this.tabUserData = new System.Windows.Forms.TabPage();
            this.InfoReloadingTimer = new System.Timers.Timer();
            this.AuraTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RestoreFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BackupFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.tabWallets.SuspendLayout();
            this.tabWalletTransactions.SuspendLayout();
            this.tabMarketOrders.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabStarMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoReloadingTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusToolStripLabel,
            this.toolStripStatusLabel2,
            this.AsyncOperationToolStripLabel,
            this.AppVersionToolStripLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 664);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(971, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusStrip1";
            // 
            // StatusToolStripLabel
            // 
            this.StatusToolStripLabel.Name = "StatusToolStripLabel";
            this.StatusToolStripLabel.Size = new System.Drawing.Size(38, 17);
            this.StatusToolStripLabel.Text = "Status";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(860, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // AsyncOperationToolStripLabel
            // 
            this.AsyncOperationToolStripLabel.Name = "AsyncOperationToolStripLabel";
            this.AsyncOperationToolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // AppVersionToolStripLabel
            // 
            this.AppVersionToolStripLabel.Name = "AppVersionToolStripLabel";
            this.AppVersionToolStripLabel.Size = new System.Drawing.Size(58, 17);
            this.AppVersionToolStripLabel.Text = "<version>";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageCharactersToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageCharactersToolStripMenuItem
            // 
            this.manageCharactersToolStripMenuItem.Name = "manageCharactersToolStripMenuItem";
            this.manageCharactersToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.manageCharactersToolStripMenuItem.Text = "Manage characters";
            this.manageCharactersToolStripMenuItem.Click += new System.EventHandler(this.manageCharactersToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceUpdateToolStripMenuItem,
            this.toolStripMenuItem1,
            this.backupToolStripMenuItem,
            this.restoreToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // forceUpdateToolStripMenuItem
            // 
            this.forceUpdateToolStripMenuItem.Name = "forceUpdateToolStripMenuItem";
            this.forceUpdateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.forceUpdateToolStripMenuItem.Text = "Force update";
            this.forceUpdateToolStripMenuItem.Click += new System.EventHandler(this.forceUpdateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.backupToolStripMenuItem.Text = "Backup...";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.restoreToolStripMenuItem.Text = "Restore...";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.releaseNotesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.releaseNotesToolStripMenuItem.Text = "Release notes";
            this.releaseNotesToolStripMenuItem.Click += new System.EventHandler(this.releaseNotesToolStripMenuItem_Click);
            // 
            // tabsMain
            // 
            this.tabsMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsMain.Controls.Add(this.tabDashboard);
            this.tabsMain.Controls.Add(this.tabWallets);
            this.tabsMain.Controls.Add(this.tabWalletTransactions);
            this.tabsMain.Controls.Add(this.tabCustomTransaction);
            this.tabsMain.Controls.Add(this.tabMarketOrders);
            this.tabsMain.Controls.Add(this.tabReports);
            this.tabsMain.Controls.Add(this.tabStarMap);
            this.tabsMain.Controls.Add(this.tabUserData);
            this.tabsMain.Location = new System.Drawing.Point(0, 27);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(971, 634);
            this.tabsMain.TabIndex = 0;
            this.tabsMain.SelectedIndexChanged += new System.EventHandler(this.tabsMain_SelectedIndexChanged);
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.DashboardTab);
            this.tabDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(963, 608);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            this.tabDashboard.Click += new System.EventHandler(this.tabDashboard_Click);
            // 
            // DashboardTab
            // 
            this.DashboardTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DashboardTab.AutoScroll = true;
            this.DashboardTab.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.DashboardTab.Location = new System.Drawing.Point(0, 0);
            this.DashboardTab.Name = "DashboardTab";
            this.DashboardTab.Padding = new System.Windows.Forms.Padding(8);
            this.DashboardTab.ReInitialize = false;
            this.DashboardTab.Size = new System.Drawing.Size(967, 612);
            this.DashboardTab.TabIndex = 0;
            this.DashboardTab.Load += new System.EventHandler(this.DashboardTab_Load);
            // 
            // tabWallets
            // 
            this.tabWallets.Controls.Add(this.CharactersTab);
            this.tabWallets.Location = new System.Drawing.Point(4, 22);
            this.tabWallets.Name = "tabWallets";
            this.tabWallets.Padding = new System.Windows.Forms.Padding(3);
            this.tabWallets.Size = new System.Drawing.Size(963, 608);
            this.tabWallets.TabIndex = 4;
            this.tabWallets.Text = "Wallets";
            this.tabWallets.UseVisualStyleBackColor = true;
            // 
            // CharactersTab
            // 
            this.CharactersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CharactersTab.Location = new System.Drawing.Point(0, 0);
            this.CharactersTab.Name = "CharactersTab";
            this.CharactersTab.Padding = new System.Windows.Forms.Padding(8);
            this.CharactersTab.Size = new System.Drawing.Size(963, 608);
            this.CharactersTab.TabIndex = 0;
            // 
            // tabWalletTransactions
            // 
            this.tabWalletTransactions.Controls.Add(this.WalletTransactionsTab);
            this.tabWalletTransactions.Location = new System.Drawing.Point(4, 22);
            this.tabWalletTransactions.Name = "tabWalletTransactions";
            this.tabWalletTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.tabWalletTransactions.Size = new System.Drawing.Size(963, 608);
            this.tabWalletTransactions.TabIndex = 2;
            this.tabWalletTransactions.Text = "Wallet transactions";
            this.tabWalletTransactions.UseVisualStyleBackColor = true;
            // 
            // WalletTransactionsTab
            // 
            this.WalletTransactionsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WalletTransactionsTab.Location = new System.Drawing.Point(0, 0);
            this.WalletTransactionsTab.Name = "WalletTransactionsTab";
            this.WalletTransactionsTab.Padding = new System.Windows.Forms.Padding(8);
            this.WalletTransactionsTab.Size = new System.Drawing.Size(963, 608);
            this.WalletTransactionsTab.TabIndex = 0;
            // 
            // tabCustomTransaction
            // 
            this.tabCustomTransaction.Location = new System.Drawing.Point(4, 22);
            this.tabCustomTransaction.Name = "tabCustomTransaction";
            this.tabCustomTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomTransaction.Size = new System.Drawing.Size(963, 608);
            this.tabCustomTransaction.TabIndex = 11;
            this.tabCustomTransaction.Text = "Custom Transaction";
            this.tabCustomTransaction.UseVisualStyleBackColor = true;
            // 
            // tabMarketOrders
            // 
            this.tabMarketOrders.Controls.Add(this.MarketOrdersTab);
            this.tabMarketOrders.Location = new System.Drawing.Point(4, 22);
            this.tabMarketOrders.Name = "tabMarketOrders";
            this.tabMarketOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarketOrders.Size = new System.Drawing.Size(963, 608);
            this.tabMarketOrders.TabIndex = 7;
            this.tabMarketOrders.Text = "Market orders";
            this.tabMarketOrders.UseVisualStyleBackColor = true;
            // 
            // MarketOrdersTab
            // 
            this.MarketOrdersTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MarketOrdersTab.Location = new System.Drawing.Point(0, 0);
            this.MarketOrdersTab.Name = "MarketOrdersTab";
            this.MarketOrdersTab.Padding = new System.Windows.Forms.Padding(8);
            this.MarketOrdersTab.Size = new System.Drawing.Size(963, 608);
            this.MarketOrdersTab.TabIndex = 0;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.ReportsTab);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabReports.Size = new System.Drawing.Size(963, 608);
            this.tabReports.TabIndex = 9;
            this.tabReports.Text = "Reports";
            this.tabReports.UseVisualStyleBackColor = true;
            this.tabReports.Click += new System.EventHandler(this.tabReports_Click);
            // 
            // ReportsTab
            // 
            this.ReportsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportsTab.AutoScroll = true;
            this.ReportsTab.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportsTab.Location = new System.Drawing.Point(0, 0);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.ReportsTab.ReInitialize = false;
            this.ReportsTab.Size = new System.Drawing.Size(963, 608);
            this.ReportsTab.TabIndex = 0;
            // 
            // tabStarMap
            // 
            this.tabStarMap.Controls.Add(this.starMapTab);
            this.tabStarMap.Location = new System.Drawing.Point(4, 22);
            this.tabStarMap.Name = "tabStarMap";
            this.tabStarMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabStarMap.Size = new System.Drawing.Size(963, 608);
            this.tabStarMap.TabIndex = 3;
            this.tabStarMap.Text = "Star map";
            this.tabStarMap.UseVisualStyleBackColor = true;
            // 
            // starMapTab
            // 
            this.starMapTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.starMapTab.Location = new System.Drawing.Point(0, 0);
            this.starMapTab.Name = "starMapTab";
            this.starMapTab.Size = new System.Drawing.Size(967, 612);
            this.starMapTab.TabIndex = 0;
            // 
            // tabUserData
            // 
            this.tabUserData.Location = new System.Drawing.Point(4, 22);
            this.tabUserData.Name = "tabUserData";
            this.tabUserData.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserData.Size = new System.Drawing.Size(963, 608);
            this.tabUserData.TabIndex = 10;
            this.tabUserData.Text = "User data";
            this.tabUserData.UseVisualStyleBackColor = true;
            // 
            // InfoReloadingTimer
            // 
            this.InfoReloadingTimer.Enabled = true;
            this.InfoReloadingTimer.Interval = 600000;
            this.InfoReloadingTimer.SynchronizingObject = this;
            this.InfoReloadingTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.InfoReloadingTimer_Elapsed);
            // 
            // AuraTrayIcon
            // 
            this.AuraTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AuraTrayIcon.Icon")));
            this.AuraTrayIcon.Text = "Aura";
            // 
            // RestoreFileDialog
            // 
            this.RestoreFileDialog.Filter = "Eve Trader storage|*.xml";
            this.RestoreFileDialog.Title = "Restore Eve Trader data";
            // 
            // BackupFileDialog
            // 
            this.BackupFileDialog.Filter = "Eve Trader storage|*.xml";
            this.BackupFileDialog.Title = "Backup Eve trader data";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 686);
            this.Controls.Add(this.tabsMain);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(860, 400);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eve Trader";
            this.Load += new System.EventHandler(this.FromMain_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromMain_FormClosing);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabsMain.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabWallets.ResumeLayout(false);
            this.tabWalletTransactions.ResumeLayout(false);
            this.tabMarketOrders.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.tabStarMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoReloadingTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabWalletTransactions;
        private System.Windows.Forms.ToolStripStatusLabel StatusToolStripLabel;
        private System.Windows.Forms.TabPage tabStarMap;
        private WalletTransactionsTab WalletTransactionsTab;
        private System.Windows.Forms.TabPage tabWallets;
        private EveTrader.Main.Characters.CharactersTab CharactersTab;
        private System.Windows.Forms.ToolStripMenuItem manageCharactersToolStripMenuItem;
        private System.Windows.Forms.TabPage tabMarketOrders;
        private DashboardTab DashboardTab;
        private System.Timers.Timer InfoReloadingTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel AsyncOperationToolStripLabel;
        private System.Windows.Forms.TabPage tabReports;
        private ReportsTab ReportsTab;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel AppVersionToolStripLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
        private StarMapTab starMapTab;
        private System.Windows.Forms.NotifyIcon AuraTrayIcon;
        private MarketOrdersTab MarketOrdersTab;
        private System.Windows.Forms.TabPage tabUserData;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog RestoreFileDialog;
        private System.Windows.Forms.SaveFileDialog BackupFileDialog;
        private System.Windows.Forms.TabPage tabCustomTransaction;
    }
}