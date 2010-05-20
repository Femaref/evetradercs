using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using EveTrader.Core.Model;
using EveTrader.Core.DataConverter.ClassExtenders;
using System.Data.SQLite;

namespace EveTrader.Core.DataConverter
{
    public class XmlToSqlite
    {
        private XDocument iDocument;

        public XmlToSqlite(string path)
            : this(XDocument.Load(path))
        {
        }
        public XmlToSqlite(XDocument doc)
        {
            iDocument = doc;
        }

        public bool Convert()
        {
            var root = iDocument.Root;

            if (root.Element("Version").Value != "1.2.4")
                return false;

            string path = CreateDatabase();

            TraderModel model = new TraderModel("metadata=res://*/Model.TraderModel.csdl|res://*/Model.TraderModel.ssdl|res://*/Model.TraderModel.msl;provider=System.Data.SQLite;provider connection string='data source=" + path + "'");

            if (model.Accounts.Count(e => e.ID == 0) == 0)
            {
                model.Accounts.AddObject(Accounts.CreateAccounts(0, ""));
                model.SaveChanges();
            }

            Accounts currentAccount;
            foreach (XElement characters in root.Element("Characters").Elements())
            {
                long id = characters.Element("ApiData").Element("UserID").Value.ToInt64();
                if (id != 0 && model.Accounts.Count(a => a.ID == id) == 0)
                {
                    var newAccount = Accounts.CreateAccounts(characters.Element("ApiData").Element("UserID").Value.ToInt64(), characters.Element("ApiData").Element("ApiKey").Value);
                    model.Accounts.AddObject(newAccount);
                    model.SaveChanges();
                }
                currentAccount = model.Accounts.First(a => a.ID == id);

                var dbChar = GetCharacter(characters);

                if (model.Entity.Count(e => e.ID == dbChar.ID) != 0)
                    continue;

                long corpID = characters.Element("Corporation").Element("ID").Value.ToInt64();

                
                if (model.Entity.Count(e => e.ID == corpID) == 0)
                {
                    var corp = GetCorporation(characters.Element("Corporation"));
                    corp.Account = model.Accounts.First(a => a.ID == id);
                    model.Entity.AddObject(corp);
                    model.SaveChanges();
                }
                Corporations dbCorp = model.Entity.OfType<Corporations>().Where(e => e.ID == corpID).First();

                dbChar.Account = currentAccount;
                dbChar.Corporation = dbCorp;


                model.Entity.AddObject(dbChar);
                model.SaveChanges();
            }
            return true;
        }

        private Corporations GetCorporation(XElement corporations)
        {
            Corporations corporation = new Corporations()
            {
                ID = corporations.Element("ID").Value.ToInt64(),
                Name = corporations.Element("Name").Value,
                Ticker = corporations.Element("Ticker").Value,
                //TODO better check
                Npc = corporations.Element("ID").Value.ToInt64() <= 1000182,
                ApiCharacterID = corporations.Element("ApiData").Element("CharacterID").Value.ToInt64()
            };
            if (!corporation.Npc)
            {
                foreach (XElement marketOrders in corporations.Element("MarketOrders").Elements())
                {
                    corporation.MarketOrders.Add(GetMarketOrder(marketOrders));
                }
                foreach (XElement wallets in corporations.Element("Wallets").Elements())
                {
                    Wallets w = GetWallet(wallets);
                    w.Transactions.ToList().ForEach(t => t.TransactionFor = (long)TransactionFor.Corporation);
                    corporation.Wallets.Add(w);
                }
            }
            
            return corporation;
        }

        private static Characters GetCharacter(XElement characters)
        {
            Characters character = new Characters()
            {
                ID = characters.Element("ID").Value.ToInt64(),
                Balance = characters.Element("Balance").Value.ToDecimal(),
                Bloodline = characters.Element("BloodLine").Value,
                Gender = characters.Element("Gender").Value,
                Name = characters.Element("Name").Value,
                Race = characters.Element("Race").Value
            };

            foreach (XElement marketOrders in characters.Element("MarketOrders").Elements())
            {
                character.MarketOrders.Add(GetMarketOrder(marketOrders));
            }
            XElement wallet = characters.Element("Wallets").Elements().First();

            Wallets w = GetWallet(wallet);
            //remove all Transactions that reference a corporation transaction, those aren't needed with the character
            w.Transactions.ToList().RemoveAll(t => t.TransactionFor != (long)TransactionFor.Personal);

            foreach (XElement wh in characters.Element("BalanceHistory").Elements())
            {
                w.WalletHistory.Add(GetWalletHistory(wh));
            }
            character.Wallets.Add(w);

            return character;

        }
        private static WalletHistories GetWalletHistory(XElement wh)
        {
            return WalletHistories.CreateWalletHistories(0, wh.Element("Value").Value.ToDecimal(), wh.Element("Key").Value.ToDateTime());
        }

        private static Wallets GetWallet(XElement wallet)
        {
            Wallets w = Wallets.CreateWallets(wallet.Element("ID").Value.ToInt64(),
                wallet.Element("Name").Value,
                wallet.Element("Balance").Value.ToDecimal(),
                wallet.Element("Key").Value.ToInt64());
            foreach (XElement transaction in wallet.Element("Transactions").Elements())
            {
                w.Transactions.Add(GetTransaction(transaction));
            }
            foreach (XElement journal in wallet.Element("Journal").Elements())
            {
                if(journal.Element("ReferenceID").Value.ToInt64() != 0)
                    w.Journal.Add(GetJournal(journal));
            }
            return w;
        }

        private static ApiJournal GetJournal(XElement journal)
        {
            return ApiJournal.CreateApiJournal(0,
                journal.Element("ReferenceTypeID").Value.ToInt64(),
                journal.Element("OwnerName1").Value,
                journal.Element("OwnerID1").Value.ToInt64(),
                journal.Element("OwnerName2").Value,
                journal.Element("OwnerID2").Value.ToInt64(),
                journal.Element("ArgName1").Value,
                journal.Element("ArgID1").Value.ToInt64(),
                journal.Element("Amount").Value.ToDecimal(),
                journal.Element("Balance").Value.ToDecimal(),
                journal.Element("Reason").Value,
                journal.Element("TaxReceiverID").Value.ToInt64(),
                journal.Element("TaxAmount").Value.ToDecimal(),
                journal.Element("Date").Value.ToDateTime(),
                journal.Element("ReferenceID").Value.ToInt64());


        }

        private static ApiTransactions GetTransaction(XElement transaction)
        {
            return ApiTransactions.CreateApiTransactions(0,
                                transaction.Element("Quantity").Value.ToInt64(),
                                transaction.Element("TypeName").Value,
                                transaction.Element("TypeID").Value.ToInt64(),
                                transaction.Element("Price").Value.ToDecimal(),
                                transaction.Element("ClientID").Value.ToInt64(),
                                transaction.Element("ClientName").Value,
                                transaction.Element("StationID").Value.ToInt64(),
                                transaction.Element("StationName").Value,
                                (long)Enum.Parse(typeof(TransactionType), transaction.Element("TransactionType").Value),
                                (long)Enum.Parse(typeof(TransactionFor), transaction.Element("TransactionFor").Value),
                                transaction.Element("TransactionDateTime").Value.ToDateTime(),
                                transaction.Element("Ignore").Value.ToBool(),
                                transaction.Element("TransactionID").Value.ToInt64());
        }

        private static MarketOrders GetMarketOrder(XElement marketOrders)
        {
            return MarketOrders.CreateMarketOrders(marketOrders.Element("ID").Value.ToInt64(),
                                        marketOrders.Element("StationID").Value.ToInt64(),
                                        marketOrders.Element("VolumeEntered").Value.ToInt64(),
                                        marketOrders.Element("VolumeRemaining").Value.ToInt64(),
                                        marketOrders.Element("VolumeMinimum").Value.ToInt64(),
                                        (long)Enum.Parse(typeof(MarketOrderState), marketOrders.Element("OrderState").Value),
                                        marketOrders.Element("TypeID").Value.ToInt64(),
                                        marketOrders.Element("Range").Value.ToInt64(),
                                        marketOrders.Element("AccountKey").Value.ToInt64(),
                                        marketOrders.Element("Duration").Value.ToInt64(),
                                        marketOrders.Element("Escrow").Value.ToInt64(),
                                        marketOrders.Element("Price").Value.ToInt64(),
                                        marketOrders.Element("Type").Value.ToLower() == "buy",
                                        marketOrders.Element("Issued").Value.ToDateTime());
        }
        private string CreateDatabase()
        {
            return CreateDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader"));
        }
        private string CreateDatabase(string path)
        {
            string pathToFile = Path.Combine(path, "EveTrader.db");
            if (File.Exists(pathToFile))
                return pathToFile;
            string connection = string.Format("Data Source={0};Version=3;", pathToFile);
            string db_schema = Properties.Resources.tables;

            using (SQLiteConnection cn = new SQLiteConnection(connection))
            {
                using (SQLiteCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = db_schema;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return pathToFile;
        }
    }
}
