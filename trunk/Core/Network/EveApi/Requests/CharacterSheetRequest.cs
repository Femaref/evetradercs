using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.DomainModel;
using Core.Network.EveApi;
using Core.DomainModel;
using Core.ClassExtenders;

namespace Core.Network.EveApi.Requests 
{
    public class CharacterSheetRequest : EveApiCharacterResourceRequest
    {
        private Character character;

        protected override EveApiResourceType ResourceType
        {
            get 
            { 
                return EveApiResourceType.CharacterSheet;
            }
        }

        public CharacterSheetRequest(int accountId, string apiKey, int characterId) : base (accountId, apiKey, characterId)
        {
            this.character = new Character{ AccountId = accountId, ApiKey = apiKey, Id = characterId };
        }
        public CharacterSheetRequest(Character character) : base (character.AccountId, character.ApiKey, character.Id)
        {
            this.character = character;
        }

        public Character Request()
        {
            return this.Parse(base.GetResponseXml());
        }

        private Character Parse(XDocument document)
        {
            XElement characterInfo = document.Descendants("result").First();

            this.character.Name = characterInfo.Element("name").Value;
            this.character.Race = characterInfo.Element("race").Value;
            this.character.BloodLine = characterInfo.Element("bloodLine").Value;
            this.character.Gender = characterInfo.Element("gender").Value == "Female" ? CharacterGender.Female : CharacterGender.Male;
            this.character.Corporation.Id = characterInfo.Element("corporationID").Value.ToInt32();
            this.character.Corporation.Name = characterInfo.Element("corporationName").Value;
            this.character.Balance = characterInfo.Element("balance").Value.ToDouble();

            return this.character;
        }
    }
}
