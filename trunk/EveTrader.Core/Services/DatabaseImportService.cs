using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EveTrader.Core.Model.Trader;
using ClassExtenders;

namespace EveTrader.Core.Services
{
    public class DatabaseImportService : IDatabaseImportService
    {
        public void Import(System.Xml.Linq.XDocument xd)
        {
            RaiseStarted();

            var root = xd.Root.Element("EveTraderExport");

            foreach (XElement xa in root.Elements("Accounts"))
            {
                Accounts a = new Accounts()
                {
                    ID = xa.Attribute("userid").Value.ToInt32(),
                    ApiKey = xa.Attribute("apikey").Value
                };

                foreach (XElement xe in xa.Elements())
                {
                    if (xe.Name == "Characters")
                        a.Entities.Add(ParseCharacter(xe));
                    else
                        a.Entities.Add(ParseCorporation(xe));
                }
            }



            RaiseCompleted();
        }

        private Entities ParseCorporation(XElement xe)
        {
            throw new NotImplementedException();
        }

        private Entities ParseCharacter(XElement xe)
        {
            throw new NotImplementedException();
        }

        private void RaiseCompleted()
        {
            var handler = Completed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void RaiseStarted()
        {
            var handler = Started;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }


        public event EventHandler Started;

        public event EventHandler Completed;
    }
}