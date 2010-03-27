using System;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;
using Core.Network.EveApi.Entities;

namespace Core.Network.EveApi.Requests 
{
    public class CharacterSheetRequest : EveApiEntityRequest<Character>
    {
        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.CharacterSheet;
            }
        }

        public CharacterSheetRequest(IAccount a) : base(a)
        {
        }
        public CharacterSheetRequest(Account a, EveApiResourceFrom from ) : base(a, from)
        { 
        }

        public override Character Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private Character Parse(XDocument document)
        {
            XElement characterInfo = document.Descendants("result").First();

            Character character = new Character();

            character.Name = characterInfo.Element("name").Value;
            character.Race = characterInfo.Element("race").Value;
            character.BloodLine = characterInfo.Element("bloodLine").Value;
            character.Gender = characterInfo.Element("gender").Value == "Female"
                                        ? CharacterGender.Female
                                        : CharacterGender.Male;
            character.Corporation.ID = characterInfo.Element("corporationID").Value.ToInt32();
            character.Corporation.Name = characterInfo.Element("corporationName").Value;
            character.Balance = characterInfo.Element("balance").Value.ToDouble();
            
            if (!character.BalanceHistory.Any(
                     wt => wt.Key == DateTime.Parse(document.Element("eveapi").Element("currentTime").Value)))
            {

                character.BalanceHistory.Add(new WalletHistory()
                                                      {
                                                          Key =
                                                              DateTime.Parse(
                                                              document.Element("eveapi").Element("currentTime").Value),
                                                          Value = characterInfo.Element("balance").Value.ToDouble()
                                                      });
            }

            return character;
        }
    }
}
