using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class Products
    {
        public static double GetProductAverageBuyPrice(IEnumerable<WalletTransaction> walletTransactions, int productTypeId)
        {
            IEnumerable<WalletTransaction> filteredWalletTransactions = walletTransactions.Where(
                wt => 
                    wt.TransactionType == WalletTransactionType.Buy && 
                    wt.TypeID == productTypeId).OrderByDescending(wt => wt.TransactionDateTime).Take(10);

            if (filteredWalletTransactions.Count() > 0)
            {
                return filteredWalletTransactions.Average(wt => wt.Price);
            }
            
            return 0;
        }


    }
}
