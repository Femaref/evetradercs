using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace EveTrader.Analysis
{
    public static class Data
    {
        public static IEnumerable<WalletTransaction> GetUnitedWalletTransactions()
        {
            WalletTransactionComparer walletTransactionComparer = new WalletTransactionComparer();
            IEnumerable<WalletTransaction> result = new List<WalletTransaction>();

            foreach (Character character in Settings.Instance.Characters)
            {
                result = result.Union(character.WalletTransactions, walletTransactionComparer);
            }

            return result;
        }
        public static IEnumerable<WalletJournalRecord> GetUnitedWalletJournalRecords()
        {
            WalletJournalComparer walletJournalComparer = new WalletJournalComparer();
            IEnumerable<WalletJournalRecord> result = new List<WalletJournalRecord>();

            foreach (Character character in Settings.Instance.Characters)
            {
                result = result.Union(character.WalletJournal, walletJournalComparer);
            }

            return result;
        }
    }
}