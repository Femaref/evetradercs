using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveTrader.Core.Model;
using EveTrader.Core.ClassExtenders;
using System.Xml.Linq;

namespace EveTrader.Core.Network.Requests.CCP
{
    public class CharacterSheetRequest : ApiEntityRequestBase<Characters>
    {
        public CharacterSheetRequest(Accounts a, long characterID)
            : base(a, characterID, ApiRequestTarget.Character)
        {
        }

        public override ApiRequestPage Page
        {
            get
            {
                return ApiRequestPage.CharacterSheet;
            }
        }

        protected override Characters Parse(System.Xml.Linq.XDocument document)
        {
            XElement characterInfo = document.Descendants("result").First();

            Characters character = new Characters();

            character.Name = characterInfo.Element("name").Value;
            character.Race = characterInfo.Element("race").Value;
            character.Bloodline = characterInfo.Element("bloodLine").Value;
            character.Gender = characterInfo.Element("gender").Value;
            character.Corporation = new Corporations() { ID = characterInfo.Element("corporationID").Value.ToInt32(), Name = characterInfo.Element("corporationName").Value };
            character.Balance = characterInfo.Element("balance").Value.ToDecimal();

            return character;
        }
    }
}
