using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.DomainModel;

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

            IEnumerable<Standing> standingsToCharacter = new List<Standing>();
            IEnumerable<Standing> standingsToCorporation = new List<Standing>();
            IEnumerable<Standing> standingsFromAgent = new List<Standing>();
            IEnumerable<Standing> standingsFromNPC = new List<Standing>();
            IEnumerable<Standing> standingsFromFaction = new List<Standing>();

            if (root.Element("standingsTo").HasElements)
            {
                standingsToCharacter =
                    (from d in
                         root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "characters").
                         Descendants()
                     select new Standing()
                                {
                                    CharacterID = this.CharacterId,
                                    Target = StandingTarget.Character,
                                    TargetID = int.Parse(d.Attribute("toID").Value),
                                    Type = StandingType.To,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingsToCorporation =
                    (from d in
                         root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "corporations").
                         Descendants()
                     select new Standing()
                                {
                                    CharacterID = this.CharacterId,
                                    Target = StandingTarget.Corporation,
                                    TargetID = int.Parse(d.Attribute("toID").Value),
                                    Type = StandingType.To,
                                    Value = double.Parse(d.Attribute("standing").Value)
                                });
            }
            if (root.Element("standingsFrom").HasElements)
            {
                standingsFromAgent =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "agents").
                         Descendants()
                     select new Standing()
                                {
                                    CharacterID = this.CharacterId,
                                    Target = StandingTarget.Agent,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingsFromNPC =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(
                         r => r.Attribute("name").Value == "NPCCorporations").Descendants()
                     select new Standing()
                                {
                                    CharacterID = this.CharacterId,
                                    Target = StandingTarget.NpcCorporation,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingsFromFaction =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "factions").
                         Descendants()
                     select new Standing()
                                {
                                    CharacterID = this.CharacterId,
                                    Target = StandingTarget.Faction,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
            }

            return
                standingsFromAgent.Union(standingsFromFaction).Union(standingsFromNPC).Union(standingsToCharacter).Union
                    (standingsToCorporation);
        }
    }
}