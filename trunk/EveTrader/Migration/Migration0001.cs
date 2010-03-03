using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Core.Network.EveApi;
using Core.Network.EveApi.Requests;
using Core.Migration;
using Core.Network;
using Core.ClassExtenders;

namespace EveTrader.Migration
{
    [TargetVersion(1, 2, 3, 1, 2, 4)]
    [TargetFile("settings.xml")]
    public class Migrate0001 : IXmlMigrationTarget
    {
        #region Implementation of IXmlMigrationTarget

        public bool Upgrade(XDocument input)
        {
            return UpgradeWallet(input) && UpgradeMarketOrders(input);
        }
        public bool Downgrade(XDocument input)
        {
            return DowngradeWallet(input) && DowngradeMarketOrders(input);
        }


        private bool UpgradeWallet(XDocument input)
        {
            var characters = (from xE in input.Element("EveTrader").Element("Characters").Elements()
                              where xE.Elements().Count(x => x.Name == "Wallets") == 0 ||
                                    (xE.Elements().Count(x => x.Name == "WalletTransactions" || x.Name == "WalletJournal") > 0 && xE.Elements().Count(x => x.Name == "Wallets") == 1)

                              select xE);
            try
            {
                foreach (XElement ch in characters)
                {
                    Account account = new Account
                                          {
                                              UserID = ch.Element("ApiData").Element("UserID").Value.ToInt32(),
                                              ApiKey = ch.Element("ApiData").Element("ApiKey").Value,
                                              CharacterID = ch.Element("ApiData").Element("CharacterID").Value.ToInt32()
                                          };
                    XElement wallets = null;
                    if (ch.Elements().Count(x => x.Name == "Wallets") == 0)
                    {
                        AccountBalanceRequest abr = new AccountBalanceRequest(account, EveApiResourceFrom.Character);
                        var walletAccount = abr.Request().Single();
                        if (abr.ErrorCode != 0)
                            return false;
                        wallets = new XElement("Wallets",
                                               new XElement("Wallet",
                                                            new XElement("ID", walletAccount.ID),
                                                            new XElement("Key", 1000),
                                                            new XElement("Name", "Noname"),
                                                            new XElement("Balance", walletAccount.Balance),
                                                            new XElement("NextAccountBalanceUpdate",
                                                                         walletAccount.NextAccountBalanceUpdate)
                                                   )
                            );
                        ch.Add(wallets);
                    }
                    else
                    {
                        wallets = ch.Element("Wallets");
                    }

                    XElement trans = ch.Elements().Where(x => x.Name == "WalletTransactions").Single();
                    XElement journal = ch.Elements().Where(x => x.Name == "WalletJournal").Single();

                    if (wallets.Element("Wallet").Elements().Count(x => x.Name == "Transactions") == 0)
                    {
                        wallets.Element("Wallet").Add(new XElement("Transactions", trans.Elements()));
                    }
                    else
                    {
                        wallets.Element("Wallet").Element("Transactions").Add(trans.Elements());
                    }
                    if (wallets.Element("Wallet").Elements().Count(x => x.Name == "Journal") == 0)
                    {
                        wallets.Element("Wallet").Add(new XElement("Journal", journal.Elements()));
                    }
                    else
                    {
                        wallets.Element("Wallet").Element("Journal").Add(journal.Elements());
                    }

                    trans.Remove();
                    journal.Remove();

                }
            }
            catch
            {
                return false;
            }


            return true;
        }
        private bool UpgradeMarketOrders(XDocument input)
        {
            //TODO: Test
            try
            {
                var market = input.Descendants("MarketOrders").Elements();
                foreach (XElement xe in market)
                {
                    xe.Element("StationId").Name = "StationID";
                    xe.Element("TypeId").Name = "TypeID";
                    xe.Element("Id").Name = "ID";
                    xe.Element("CharacterId").Name = "EntityID";
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private bool DowngradeWallet(XDocument input)
        {
            var characters = (from xE in input.Element("EveTrader").Element("Characters").Elements()
                              select xE);
            try
            {
                foreach (XElement ch in characters)
                {

                    XElement trans = ch.Element("Wallets").Elements().Single().Element("Wallet").Element("Transactions");
                    XElement journal = ch.Element("Wallets").Elements().Single().Element("Wallet").Element("Journal");

                    ch.Add("WalletTransactions", trans.Elements());
                    ch.Add("WalletJournal", journal.Elements());

                    ch.Element("Wallets").Remove();

                }
            }
            catch
            {
                return false;
            }


            return true;
        }
        private bool DowngradeMarketOrders(XDocument input)
        {
            //TODO: Test
            try
            {
                var market = input.Descendants("MarketOrders").Elements();
                foreach (XElement xe in market)
                {
                    xe.Element("StationID").Name = "StationId";
                    xe.Element("TypeID").Name = "TypeId";
                    xe.Element("ID").Name = "Id";
                    xe.Element("EntityID").Name = "CharacterId";
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
