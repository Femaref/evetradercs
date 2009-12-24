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
            var root = document.Element("eveapi").Element("result");

            var standingsToCharacter =
                (from d in root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "characters").Descendants()
                 select new Standing()
                            {
                                CharacterID = this.CharacterId,
                                Target = StandingTarget.Character,
                                TargetID = int.Parse(d.Attribute("toID").Value),
                                Type = StandingType.To,
                                Value = double.Parse(d.Attribute("standing").Value, System.Globalization.CultureInfo.InvariantCulture)
                            });
            var standingsToCorporation =
                (from d in root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "corporations").Descendants()
                 select new Standing()
                            {
                                CharacterID = this.CharacterId,
                                Target = StandingTarget.Corporation,
                                TargetID = int.Parse(d.Attribute("toID").Value),
                                Type = StandingType.To,
                                Value = double.Parse(d.Attribute("standing").Value)
                            });
            var standingsFromAgent =
                (from d in root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "agents").Descendants()
                 select new Standing()
                            {
                                CharacterID = this.CharacterId,
                                Target = StandingTarget.Agent,
                                TargetID = int.Parse(d.Attribute("fromID").Value),
                                Type = StandingType.From,
                                Value = double.Parse(d.Attribute("standing").Value, System.Globalization.CultureInfo.InvariantCulture)
                            });
            var standingsFromNPC =
                (from d in
                     root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "NPCCorporations").Descendants()
                 select new Standing()
                            {
                                CharacterID = this.CharacterId,
                                Target = StandingTarget.NpcCorporation,
                                TargetID = int.Parse(d.Attribute("fromID").Value),
                                Type = StandingType.From,
                                Value = double.Parse(d.Attribute("standing").Value, System.Globalization.CultureInfo.InvariantCulture)
                            });
            var standingsFromFaction =
                (from d in root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "factions").Descendants()
                 select new Standing()
                            {
                                CharacterID = this.CharacterId,
                                Target = StandingTarget.Faction,
                                TargetID = int.Parse(d.Attribute("fromID").Value),
                                Type = StandingType.From,
                                Value = double.Parse(d.Attribute("standing").Value, System.Globalization.CultureInfo.InvariantCulture)
                            });

            return
                standingsFromAgent.Union(standingsFromFaction).Union(standingsFromNPC).Union(standingsToCharacter).Union
                    (standingsToCorporation);
        }
    }
}