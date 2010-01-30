using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;
using Core.Network;
using Core.Network.EveApi;
using Core.Network.EveApi.Requests;
using Core.ClassExtenders;

namespace Core.Updaters
{
    public class WalletJournalUpdater : ISubEntityUpdater<IWalletJournal>
    {
        private Account iAccount;
        private EveApiResourceFrom iFrom;

        #region ISubEntityUpdater<IWalletJournal> Members

        public bool UpdateSubEntity(IWalletJournal subEntity, Core.Network.Account apiData, EveApiResourceFrom from)
        {
            iAccount = apiData;
            iFrom = from;

            WalletJournalRequest walletJournalRequest = new WalletJournalRequest(apiData, from, subEntity.Key);
            WalletJournalComparer walletJournalComparer = new WalletJournalComparer();

            if (subEntity.NextWalletJournalUpdateTime <= DateTime.Now)
            {
                IEnumerable<WalletJournalRecord> newWalletJournalRecords = walletJournalRequest.Request();

                if (walletJournalRequest.ErrorCode == 0)
                {
                    subEntity.Journal = subEntity.Journal.Union(newWalletJournalRecords, walletJournalComparer).OrderByDescending(p => p.ReferenceId).ToList();
                    subEntity.NextWalletJournalUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }

        #endregion

        public override string ToString()
        {
            return "WalletJournalUpdater[" + iAccount + "," + iFrom.StringValue() + "]";
        }
    }
}
