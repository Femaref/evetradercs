using System.Collections.Generic;
using System.Linq;
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
                //TODO: FIX for character.Wallets == null
                result = result.Union(character.Wallets.Single().Transactions, walletTransactionComparer);
            }

            return result;
        }
        public static IEnumerable<WalletJournalRecord> GetUnitedWalletJournalRecords()
        {
            WalletJournalComparer walletJournalComparer = new WalletJournalComparer();
            IEnumerable<WalletJournalRecord> result = new List<WalletJournalRecord>();

            foreach (Character character in Settings.Instance.Characters)
            {
                result = result.Union(character.Wallets.Single().Journal, walletJournalComparer);
            }

            return result;
        }
    }
}