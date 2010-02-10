using System;
using System.Collections.Generic;
using System.Linq;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Network;
using Core.Network.EveApi;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class WalletTransactionsUpdater : ISubEntityUpdater<IWalletTransactions>
    {
        private Account iAccount;
        private EveApiResourceFrom iFrom;

        #region ISubEntityUpdater<IWalletJournal> Members

        public bool UpdateSubEntity(IWalletTransactions subEntity, Account apiData, EveApiResourceFrom from)
        {
            iAccount = apiData;
            iFrom = from;

            WalletTransactionsRequest walletTransactionsRequest = new WalletTransactionsRequest(apiData, from, subEntity.Key);
            WalletTransactionComparer walletTransactionComparer = new WalletTransactionComparer();

            if (subEntity.NextWalletTransactionsUpdateTime <= DateTime.Now)
            {
                IEnumerable<WalletTransaction> walletTransactions = walletTransactionsRequest.Request();
				//untested
                if(walletTransactions != null && walletTransactions.Count() >= 1000 && walletTransactions.Min(w => w.TransactionDateTime) > (DateTime.UtcNow - new TimeSpan(7,0,0)))
                {
                    bool breakRequest = false;
                    while (!breakRequest)
                    {
                        IEnumerable<WalletTransaction> newWalletTransactions =
                            walletTransactionsRequest.Request(walletTransactions.Min(w => w.TransactionID));
                        walletTransactions = walletTransactions.Union(newWalletTransactions, walletTransactionComparer);

                        //if min() date is earlier than UtcNow-7 Days or returned count is lower than 1000 entries, break
                        if(walletTransactions != null && newWalletTransactions.Count() < 1000 || newWalletTransactions.Min(w => w.TransactionDateTime) < (DateTime.UtcNow - new TimeSpan(7,0,0)))
                            breakRequest = true;
                    }
                }
                if (walletTransactionsRequest.ErrorCode == 0)
                {
                    //foreach (WalletTransaction wt in newWalletTransactions)
                    //    wt.CalculateSalesTax(character.AccountingLevel);

                    subEntity.Transactions = subEntity.Transactions.Union(walletTransactions, walletTransactionComparer).OrderByDescending(p => p.TransactionID).ToList();
                    subEntity.NextWalletTransactionsUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;

            
        }

        #endregion
        public override string ToString()
        {
            return "WalletTransactionsUpdater[" + 
                iAccount + "," + iFrom.StringValue() +"]";
        }
    }
}
