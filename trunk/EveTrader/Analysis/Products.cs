using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class Products
    {
        public static double GetProductAverageBuyPrice(IEnumerable<WalletTransaction> walletTransactions, int productTypeID)
        {
            return GetProductAverageBuyPrice(walletTransactions, productTypeID, DateTime.MinValue);
        }
        public static double GetProductAverageBuyPrice(IEnumerable<WalletTransaction> walletTransactions, int productTypeID, DateTime afterDate)
        {
            IEnumerable<WalletTransaction> filteredWalletTransactions = (from wt in walletTransactions
                                                                         where
                                                                             wt.TransactionType == WalletTransactionType.Buy
                                                                             && wt.TransactionDateTime >= afterDate
                                                                             && wt.TypeID == productTypeID
                                                                         orderby wt.TransactionDateTime descending
                                                                         select wt).Take(10);
            if (filteredWalletTransactions.Count() > 0)
            {
                return filteredWalletTransactions.Average(wt => wt.Price);
            }

            return 0;
        }


    }
}
