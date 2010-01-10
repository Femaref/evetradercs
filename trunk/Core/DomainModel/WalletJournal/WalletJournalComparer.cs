using System.Collections.Generic;

namespace Core.DomainModel
{
    public class WalletJournalComparer : IEqualityComparer<WalletJournalRecord>
    {
        public bool Equals(WalletJournalRecord walletJournalRecord1, WalletJournalRecord walletJournalRecord2)
        {
            return walletJournalRecord1.ReferenceId == walletJournalRecord2.ReferenceId;
        }

        public int GetHashCode(WalletJournalRecord walletJournalRecord)
        {
            return walletJournalRecord.ReferenceId.GetHashCode();
        }
    }
}
