using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.DomainModel;
using Core.Network.EveApi;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests
{
    public class CharactersListRequest : EveApiAccountResourceRequest
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.CharactersList;
            }
        }

        public CharactersListRequest(int accountId, string apiKey) : base(accountId, apiKey)
        {
            
        }

        public IEnumerable<Character> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<Character> Parse(XDocument document)
        {
            return document.Descendants("row")
                             .Select(r => new Character
                             {
                                 AccountId = this.AccountId,
                                 ApiKey = this.ApiKey,
                                 Id = r.Attribute("characterID").Value.ToInt32(),
                                 Name = r.Attribute("name").Value
                             });
        }
    }
}
