using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Core.DomainModel;
using Core.Migration;
using EveTrader.Helpers;

namespace EveTrader
{
    [XmlRoot("EveTrader")]
    public class Settings : XmlSettingsFile<Settings>
    {
        public string Version { get; set; }


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
            XmlMigrator migrator = new XmlMigrator(this.GetType().Assembly, this.filePath);
            if(!migrator.MigrateUp())
            {
                File.Copy(this.filePath, Path.Combine(this.folder, "backup.xml"));
                throw new Exception("Migration failed for class" +this.GetType().Name); 
            }
            return;
        }

        protected override void AfterLoad()
        {
            foreach (Character c in Instance.Characters)
            {
                if (c.Wallets != null && c.Wallets.Count() > 0)
                {
                    foreach (WalletTransaction wt in c.Wallets.Single().Transactions)
                    {
                        if (wt.SalesTax > 0)
                            continue;

                        wt.CalculateSalesTax(c.AccountingLevel);
                    }
                }
            }
        }
    }
}