using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    [Obsolete("Use WalletJournalUpdater:IEntityUpdater<T> instead")]
    public class CharacterWalletJournalUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character) 
        {
            //WalletJournalRequest walletJournalRequest = new WalletJournalRequest(character);
            //WalletJournalComparer walletJournalComparer = new WalletJournalComparer();

            //if (character.NextWalletJournalUpdateTime <= DateTime.Now)
            //{
            //    IEnumerable<WalletJournalRecord> newWalletJournalRecords = walletJournalRequest.Request();
            
            //    if (walletJournalRequest.ErrorCode == 0)
            //    {
            //        character.WalletJournal = character.WalletJournal.Union(newWalletJournalRecords, walletJournalComparer).OrderByDescending(p => p.ReferenceID).ToList();
            //        character.NextWalletJournalUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
            //        return true;
            //    }
            //}

            return false;
        }
    }
}
