using System;
using System.Linq;
using System.Xml.Linq;
using Core.ClassExtenders;
using Core.DomainModel;

namespace Core.Network.EveApi.Requests 
{
    public class CharacterSheetRequest : EveApiCharacterResourceRequest<Character>
    {
        private Character character;

        protected override EveApiResourceType ResourceType
        {
            get
            {
                return EveApiResourceType.CharacterSheet;
            }
        }

        public CharacterSheetRequest(int accountId, string apiKey, int characterId)
            : base(accountId, apiKey, characterId)
        {
            this.character = new Character { AccountId = accountId, ApiKey = apiKey, ID = characterId };
        }
        public CharacterSheetRequest(Character character)
            : base(character.AccountId, character.ApiKey, character.ID)
        {
            this.character = character;
        }

        public override Character Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private Character Parse(XDocument document)
        {
            XElement characterInfo = document.Descendants("result").First();

            this.character.Name = characterInfo.Element("name").Value;
            this.character.Race = characterInfo.Element("race").Value;
            this.character.BloodLine = characterInfo.Element("bloodLine").Value;
            this.character.Gender = characterInfo.Element("gender").Value == "Female"
                                        ? CharacterGender.Female
                                        : CharacterGender.Male;
            this.character.Corporation.ID = characterInfo.Element("corporationID").Value.ToInt32();
            this.character.Corporation.Name = characterInfo.Element("corporationName").Value;
            this.character.Balance = characterInfo.Element("balance").Value.ToDouble();
            
            if (!this.character.BalanceHistory.Any(
                     wt => wt.Key == DateTime.Parse(document.Element("eveapi").Element("currentTime").Value)))
            {

                this.character.BalanceHistory.Add(new WalletHistory()
                                                      {
                                                          Key =
                                                              DateTime.Parse(
                                                              document.Element("eveapi").Element("currentTime").Value),
                                                          Value = characterInfo.Element("balance").Value.ToDouble()
                                                      });
            }

            return this.character;
        }
    }
}
