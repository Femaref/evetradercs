using System.Collections.Generic;

namespace Core.DomainModel
{
    public class WalletTransactionComparer : IEqualityComparer<WalletTransaction>
    {
        public bool Equals(WalletTransaction walletTransaction1, WalletTransaction walletTransaction2)
        {
            return walletTransaction1.TransactionID == walletTransaction2.TransactionID;
        }

        public int GetHashCode(WalletTransaction walletTransaction)
        {
            return walletTransaction.TransactionID;
        }
    }
}
