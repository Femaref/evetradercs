using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;

namespace Core.ClassExtenders
{
    public static class WalletJournalRecordExtender
    {
        public static WalletTransaction MatchWalletTransaction(this WalletJournalRecord walletJournalRecord, IEnumerable<WalletTransaction> walletTransactions)
        {
            try
            {
                return walletTransactions.Single(wt => wt.TransactionDateTime == walletJournalRecord.Date);
            }
            catch(InvalidOperationException ex)
            {
                return new WalletTransaction();
            }
        }
    }
}
