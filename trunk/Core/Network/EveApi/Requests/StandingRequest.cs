using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Entities;

namespace Core.Network.EveApi.Requests
{
    public class StandingRequest : EveApiEntityRequest<IEnumerable<Standing>>
    {
        private int iEntityID;

        public StandingRequest(IEntity a) : base(a)
        {
            iEntityID = a.ID;
        }
        private IEnumerable<Standing> Parse(XDocument document)
        {
            if (this.ErrorCode != 0)
                return null;

            var root = document.Element("eveapi").Element("result");

            List<IEnumerable<Standing>> standingList = new List<IEnumerable<Standing>>();

            if (root.Element("standingsTo").HasElements)
            {
                var standingsToCharacter =
                    (from d in
                         root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "characters").
                         Descendants()
                     select new Standing()
                                {
                                    EntityID = this.iEntityID,
                                    Target = StandingTarget.Character,
                                    TargetID = int.Parse(d.Attribute("toID").Value),
                                    Type = StandingType.To,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });

                standingList.Add(standingsToCharacter);

                var standingsToCorporation =
                    (from d in
                         root.Element("standingsTo").Elements().Where(r => r.Attribute("name").Value == "corporations").
                         Descendants()
                     select new Standing()
                                {
                                    EntityID = this.iEntityID,
                                    Target = StandingTarget.Corporation,
                                    TargetID = int.Parse(d.Attribute("toID").Value),
                                    Type = StandingType.To,
                                    Value = double.Parse(d.Attribute("standing").Value)
                                });

                standingList.Add(standingsToCorporation);
            }
            if (root.Element("standingsFrom").HasElements)
            {
                var standingsFromAgent =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "agents").
                         Descendants()
                     select new Standing()
                                {
                                    EntityID = this.iEntityID,
                                    Target = StandingTarget.Agent,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingList.Add(standingsFromAgent);

                var standingsFromNPC =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(
                         r => r.Attribute("name").Value == "NPCCorporations").Descendants()
                     select new Standing()
                                {
                                    EntityID = this.iEntityID,
                                    Target = StandingTarget.NpcCorporation,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingList.Add(standingsFromNPC);

                var standingsFromFaction =
                    (from d in
                         root.Element("standingsFrom").Elements().Where(r => r.Attribute("name").Value == "factions").
                         Descendants()
                     select new Standing()
                                {
                                    EntityID = this.iEntityID,
                                    Target = StandingTarget.Faction,
                                    TargetID = int.Parse(d.Attribute("fromID").Value),
                                    Type = StandingType.From,
                                    Value =
                                        double.Parse(d.Attribute("standing").Value,
                                                     System.Globalization.CultureInfo.InvariantCulture)
                                });
                standingList.Add(standingsFromFaction);
            }

            List<Standing> output = new List<Standing>();

            standingList.ForEach(en => output.AddRange(en));

            return output;
        }
        public override IEnumerable<Standing> Request()
        {
            return this.Parse(this.GetResponseXml());
        }

        protected override EveApiResourceType ResourceType
        {
            get { return EveApiResourceType.Standings; }
        }
    }
}