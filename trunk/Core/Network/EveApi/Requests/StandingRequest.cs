using Core.DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests
{
    public class StandingRequest : EveApiCharacterResourceRequest
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.Standings;
            }
        }

        public StandingRequest(Character character)
            : base(character.AccountId, character.ApiKey, character.Id)
        {

        }

        public IEnumerable<Standing> Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private IEnumerable<Standing> Parse(XDocument document)
        {
            return new List<Standing>();
        }
    }
}


