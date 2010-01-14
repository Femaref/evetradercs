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
            return walletTransactions.SingleOrDefault(wt => wt.TransactionDateTime == walletJournalRecord.Date);
        }
    }
}
