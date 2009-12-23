namespace Core.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

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
