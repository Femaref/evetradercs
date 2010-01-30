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
                IEnumerable<WalletTransaction> newWalletTransactions = walletTransactionsRequest.Request();

                if (walletTransactionsRequest.ErrorCode == 0)
                {
                    //foreach (WalletTransaction wt in newWalletTransactions)
                    //    wt.CalculateSalesTax(character.AccountingLevel);

                    subEntity.Transactions = subEntity.Transactions.Union(newWalletTransactions, walletTransactionComparer).OrderByDescending(p => p.TransactionID).ToList();
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
                iAccount + "," + iFrom.StringValue() + "]";
        }
    }
}
