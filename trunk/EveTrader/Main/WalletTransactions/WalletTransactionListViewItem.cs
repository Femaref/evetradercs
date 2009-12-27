using System.Windows.Forms;
using Core.ClassExtenders;
using Core.DomainModel;

namespace EveTrader.Main.WalletTransactions
{
    public class WalletTransactionListViewItem : ListViewItem
    {
        public WalletTransaction WalletTransaction  { get; set; }
        
        public static WalletTransactionListViewItem Create(WalletTransaction walletTransaction, ListViewGroup group)
        {
            WalletTransactionListViewItem item = new WalletTransactionListViewItem
                                                     {
                                                         WalletTransaction = walletTransaction,
                                                         Text = walletTransaction.TransactionDateTime.ToString("HH:mm"),
                                                         Group = group
                                                     };
            item.SubItems.AddRange(
                new[]
                    {
                        walletTransaction.TypeName,
                        walletTransaction.Price.FormatCurrency(),
                        walletTransaction.Quantity.ToString(),
                        (walletTransaction.Price*walletTransaction.Quantity).FormatCurrency(),
                        walletTransaction.StationName,
                        walletTransaction.ClientName
                    });

            return item;
        }
    }
}