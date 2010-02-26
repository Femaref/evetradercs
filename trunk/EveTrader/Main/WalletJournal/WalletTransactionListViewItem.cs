using System.Windows.Forms;
using Core.ClassExtenders;
using Core.DomainModel;

namespace EveTrader.Main.WalletTransactions
{
    public class WalletJournalRecordListViewItem : ListViewItem
    {
        public WalletJournalRecord WalletJournal  { get; set; }

        public static WalletJournalRecordListViewItem Create(WalletJournalRecord walletJournal, ListViewGroup group)
        {
            WalletJournalRecordListViewItem item = new WalletJournalRecordListViewItem
                                                     {
                                                         WalletJournal = walletJournal,
                                                         Text = walletJournal.Date.ToString("HH:mm"),
                                                         Group = group
                                                     };
            //item.SubItems.AddRange(
            //    new[]
            //        {
            //            walletTransaction.TypeName,
            //            walletTransaction.Price.FormatCurrency(),
            //            walletTransaction.Quantity.ToString(),
            //            (walletTransaction.Price*walletTransaction.Quantity).FormatCurrency(),
            //            walletTransaction.StationName,
            //            walletTransaction.ClientName
            //        });

            return item;
        }
    }
}