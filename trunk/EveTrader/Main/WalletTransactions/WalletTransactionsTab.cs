using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Updaters;

namespace EveTrader.Main.WalletTransactions
{
    public partial class WalletTransactionsTab : UserControl
    {
        private DateTime showForDate = DateTime.Now.Date.AddDays(-6);

        private List<IWallet> iWallets = new List<IWallet>();


        private Wallet SelectedWallet
        {
            get
            {
                var character = (from iw in iWallets
                                 where iw.Name == this.CharactersComboBox.Text
                                 select iw.Wallets.Single());
                if (character.Count() == 1)
                    return character.Single();

                var corporation = (from iw in iWallets
                                   where this.CharactersComboBox.Text.Contains(iw.Name + " ")
                                   select (from w in iw.Wallets
                                           where this.CharactersComboBox.Text.Contains(" " + w.Name)
                                           select w).Single());
                if (corporation.Count() == 1)
                    return corporation.Single();

                return new Wallet();

            }
        }
        public WalletTransactionsTab()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            CharactersComboBox.Items.Clear();
            iWallets.Clear();
            foreach (Character character in Settings.Instance.Characters)
            {
                if (character.Wallets != null && character.Wallets.Count() == 1)
                {
                    iWallets.Add(character);
                    CharactersComboBox.Items.Add(character.Name);
                }

                if (character.Corporation.Wallets != null)
                {
                    iWallets.Add(character.Corporation);
                    foreach (Wallet w in character.Corporation.Wallets)
                    {
                        CharactersComboBox.Items.Add(character.Corporation.Name + " " + w.Name);
                    }
                }
            }

            if (CharactersComboBox.Items.Count > 0)
            {
                CharactersComboBox.SelectedIndex = 0;
                this.RenderWalletTransactions();
            }
        }

        private void CharactersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RenderWalletTransactions();
        }
        private void FilterByTextBox_TextChanged(object sender, EventArgs e)
        {
            this.RenderWalletTransactions();
        }

        private void RenderWalletTransactions()
        {
            this.WalletTransactionsListView.Items.Clear();

            DateTime previousDate = DateTime.Now.Date.AddDays(2);
            ListViewGroup activeGroup = null;

            IEnumerable<WalletTransaction> filteredWalletTransactions = this.FilterWalletTransactions(this.SelectedWallet.Transactions);

            foreach (WalletTransaction walletTransaction in filteredWalletTransactions)
            {
                if (walletTransaction.TransactionDateTime.Date < previousDate)
                {
                    if (walletTransaction.TransactionDateTime.Date == DateTime.Now.Date)
                    {
                        activeGroup = new ListViewGroup("Today");
                    }
                    else if (walletTransaction.TransactionDateTime.Date == DateTime.Now.Date.AddDays(-1))
                    {
                        activeGroup = new ListViewGroup("Yesterday");
                    }
                    else
                    {
                        activeGroup = new ListViewGroup(walletTransaction.TransactionDateTime.ToString("d MMM"));
                    }

                    this.WalletTransactionsListView.Groups.Add(activeGroup);
                    previousDate = walletTransaction.TransactionDateTime.Date;
                }

                WalletTransactionListViewItem item = WalletTransactionListViewItem.Create(walletTransaction, activeGroup);
                
                Font itemFont = new Font(item.Font, item.WalletTransaction.Ignore ? FontStyle.Strikeout : FontStyle.Regular);

                item.UseItemStyleForSubItems = false;
                item.Font = itemFont;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    subItem.Font = itemFont;
                }
                
                item.SubItems[2].ForeColor =
                item.SubItems[4].ForeColor = walletTransaction.TransactionType == WalletTransactionType.Sell ? Color.ForestGreen : Color.IndianRed;

                this.WalletTransactionsListView.Items.Add(item);
            }
        }
        private IEnumerable<WalletTransaction> FilterWalletTransactions(IEnumerable<WalletTransaction> walletTransactions)
        {
            string searchString = this.FilterByTextBox.Text.ToLower();

            return walletTransactions.Where(
                t => t.TransactionDateTime >= this.showForDate && 
                    (
                         t.ClientName.ToLower().Contains(searchString) ||
                         t.StationName.ToLower().Contains(searchString) ||
                         t.TypeName.ToLower().Contains(searchString)
                     ));
        }

        private void reportByStationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void filterByProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count != 1)
            {
                return;
            }

            this.FilterByTextBox.Text = this.WalletTransactionsListView.SelectedItems[0].SubItems[1].Text;
            this.RenderWalletTransactions();
        }

        private void filterByStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count != 1)
            {
                return;
            }

            this.FilterByTextBox.Text = this.WalletTransactionsListView.SelectedItems[0].SubItems[5].Text;
            this.RenderWalletTransactions();

        }

        private void filterByClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count != 1)
            {
                return;
            }

            this.FilterByTextBox.Text = this.WalletTransactionsListView.SelectedItems[0].SubItems[6].Text;
            this.RenderWalletTransactions();
        }

        private void filterBySolarSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count != 1)
            {
                return;
            }

            string text = this.WalletTransactionsListView.SelectedItems[0].SubItems[5].Text;
            this.FilterByTextBox.Text = text.Substring(0, text.IndexOf(" "));
            this.RenderWalletTransactions();
        }

        private void FilterByTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 1)
            {
                this.FilterByTextBox.SelectionStart = 0;
                this.FilterByTextBox.SelectionLength = this.FilterByTextBox.Text.Length;
            }
        }

        private void ShowForLast2Month_Click(object sender, EventArgs e)
        {
            this.showForDate = DateTime.Now.Date.AddMonths(-2);
            this.RenderWalletTransactions();
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            this.showForDate = DateTime.MinValue;
            this.RenderWalletTransactions();
        }

        private void ShowForLastTwoDays_Click(object sender, EventArgs e)
        {
            this.showForDate = DateTime.Now.Date.AddDays(-1);
            this.RenderWalletTransactions();
        }

        private void ShowForLastWeek_Click(object sender, EventArgs e)
        {
            this.showForDate = DateTime.Now.Date.AddDays(-6);
            this.RenderWalletTransactions();
        }

        private void ignoreTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (WalletTransactionListViewItem item in this.WalletTransactionsListView.SelectedItems)
            {
                item.WalletTransaction.Ignore = !item.WalletTransaction.Ignore;

                //TODO: FIX for character.Wallets == null
                foreach (WalletJournalRecord record in item.WalletTransaction.MatchWalletJournalRecords(this.SelectedWallet.Journal))
                {
                    record.Ignore = item.WalletTransaction.Ignore;
                }
            }

            this.RenderWalletTransactions();
            
            MainWindow.ReInitializeDashboardTab = true;
            MainWindow.ReInitializeReportsTab = true;
        }

        private void WalletTransactionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count == 0)
            {
                return;
            }

            WalletTransactionListViewItem item = (WalletTransactionListViewItem) this.WalletTransactionsListView.SelectedItems[0];

            this.ignoreTransactionToolStripMenuItem.Checked = item.WalletTransaction.Ignore;
        }

        private void setCustomPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WalletTransactionsListView.SelectedItems.Count != 1)
            {
                return;
            }

            //WalletTransactionListViewItem item = (WalletTransactionListViewItem) this.WalletTransactionsListView.SelectedItems[0];

            //CustomPriceWindow customPriceWindow = new CustomPriceWindow(this.selectedCharacter, item.WalletTransaction.TypeID);
            //customPriceWindow.ShowDialog(this);
        }

    }
}
