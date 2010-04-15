using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Network.EveApi.Entities;

namespace Core.Network.EveApi.Requests
{
    public class CharactersListRequest : EveApiEntityRequest<IEnumerable<IEntity>>
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.CharactersList;
            }
        }

        public CharactersListRequest(int accountId, string apiKey)
            : base(accountId, apiKey)
        {
            iFrom = EveApiResourceFrom.Account;
        }



        private IEnumerable<IEntity> Parse(XDocument document)
        {
            return document.Descendants("row").Select(r => new Character
                             {
                                 ID = r.Attribute("characterID").Value.ToInt32(),
                                 Name = r.Attribute("name").Value,
                                 ApiData = new Account() { UserID = this.iAccountId, ApiKey = this.iApiKey, CharacterID = r.Attribute("characterID").Value.ToInt32() }
                             }).Cast<IEntity>();
        }

        public override IEnumerable<IEntity> Request()
        {
            return this.Parse(base.GetResponseXml());
        }
    }
}
