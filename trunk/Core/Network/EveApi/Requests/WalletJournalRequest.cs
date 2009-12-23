using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.DomainModel;
using Core.DomainModel;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests
{
    public class WalletJournalRequest : EveApiCharacterResourceRequest
    {
        protected override EveApiResourceType ResourceType
        {
            get 
            { 
                return EveApiResourceType.WalletJournal;
            }
        }

        public WalletJournalRequest(Character character) : base (character.AccountId, character.ApiKey, character.Id)
        {
            
        }

        public IEnumerable<WalletJournalRecord> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<WalletJournalRecord> Parse(XDocument document)
        {
            return document.Descendants("row")
                             .Select(r => new WalletJournalRecord
                             {
                                 Date = r.Attribute("date").Value.ToDateTime().LocalizeEveTime(),
                                 ReferenceId = r.Attribute("refID").Value.ToInt32(),
                                 ReferenceTypeId = r.Attribute("refTypeID").Value.ToInt32(),
                                 Amount = r.Attribute("amount").Value.ToDouble(),
                                 Balance = r.Attribute("balance").Value.ToDouble()
                             });
        }
    }
}
