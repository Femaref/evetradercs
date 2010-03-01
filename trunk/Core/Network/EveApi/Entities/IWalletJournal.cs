using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainModel;

namespace Core.Network.EveApi.Entities
{
    public interface IWalletJournal : ISubEntity
    {
        int Key { get; set; }
        List<WalletJournalRecord> Journal { get; set; }
        DateTime NextWalletJournalUpdateTime { get; set; }
    }
}