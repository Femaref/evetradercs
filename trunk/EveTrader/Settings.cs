using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Core.DomainModel;
using EveTrader.Helpers;

namespace EveTrader
{
    [XmlRoot("EveTrader")]
    public class Settings : XmlSettingsFile<Settings>
    {
        protected override string fileName
        {
            get
            {
                return "settings.xml";
            }
        }

        public List<Character> Characters { get; set; }
        public UserData UserData { get; set; }
        
        public Settings()
        {
            this.Characters = new List<Character>();
            this.UserData = new UserData();
        }

        protected override void BeforeSave()
        {
            return;
        }

        protected override void AfterSave()
        {
            return;
        }

        protected override void BeforeLoad()
        {
            return;
        }

        protected override void AfterLoad()
        {
            foreach (Character c in Instance.Characters)
            {
                foreach (WalletTransaction wt in c.WalletTransactions)
                {
                    if(wt.SalesTax > 0)
                        continue;

                    wt.CalculateSalesTax(c.AccountingLevel);
                }
            }
        }
    }
}