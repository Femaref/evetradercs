using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;

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
                                 AccountId = this.iAccountId,
                                 ApiKey = this.iApiKey,
                                 ID = r.Attribute("characterID").Value.ToInt32(),
                                 Name = r.Attribute("name").Value
                             });
        }
    }
}
