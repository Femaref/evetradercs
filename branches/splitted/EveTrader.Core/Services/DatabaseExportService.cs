using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using EveTrader.Core.Model.Trader;
using System.Xml.Linq;

namespace EveTrader.Core.Services
{
    [Export(typeof(IDatabaseExportService))]
    public class DatabaseExportService : IDatabaseExportService
    {
        private readonly TraderModel iModel;


        [ImportingConstructor]
        public DatabaseExportService(TraderModel tm)
        {
            iModel = tm;
        }


        public System.Xml.Linq.XDocument Export(Model.Trader.Accounts a)
        {
            XDocument xd = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),new XElement("EveTraderExport"));

            foreach (Entities e in a.Entities)
            {
                xd.Root.Add(ExportEntity(e));
            }

            return xd;
        }

        private XElement ExportEntity(Entities e)
        {
            if (e is Characters)
            {
                return ExportCharacters(e as Characters);
            }
            else if (e is Corporations)
            {
                return ExportCorporations(e as Corporations);
            }
            else
            {
                throw new ArgumentException("Unknown Entities in e");
            }
        }

        private XElement ExportCorporations(Corporations corporations)
        {
            XElement xe = new XElement("Corporations");

            xe.Add(
                new object[]
                {   
                    new XAttribute("id", corporations.ID),
                    new XAttribute("name", corporations.Name)
                });

            xe.Add(
                new object[] 
                {
                    new XElement("npc", corporations.Npc),
                    new XElement("ticker", corporations.Ticker),
                    ExportMarketOrders(corporations.MarketOrders),
                    ExportWallets(corporations.Wallets),
                    ExportCharacterReferences(corporations.Characters)
                });
            return xe;

        }

        private XElement ExportCharacterReferences(IEnumerable<Characters> characters)
        {
            XElement xe = new XElement("ReferencedCharacters");

            foreach (Characters c in characters)
            {
                xe.Add(new XElement("ReferencedCharacter", c.ID));
            }

            return xe;
        }

        private XElement ExportWallets(IEnumerable<Wallets> wallets)
        {
            XElement xe = new XElement("Wallets");
            foreach(Wallets w in wallets)
            {
            xe.Add(new XElement("Wallet",
                new object[]
                {
                    new XAttribute("accountKey", w.AccountKey),
                    new XAttribute("balance", w.Balance),
                    new XAttribute("name", w.Name),
                    ExportJournal(w.Journal),
                    ExportTransactions(w.Transactions),
                    ExportWalletHistory(w.WalletHistory)
                }));
            }

            return xe;
        }

        private XElement ExportWalletHistory(IEnumerable<WalletHistories> walletHistories)
        {
            return new XElement("WalletHistories", walletHistories.Select(wh => new XElement("WalletHistory",
                new object[]
                {
                    new XAttribute("date", wh.Date),
                    new XAttribute("balance", wh.Balance),
                })));
        }

        private XElement ExportTransactions(IEnumerable<Transactions> transactions)
        {
            XElement xt = new XElement("ApiTransactions");
            XElement xcustom = new XElement("CustomTransactions");

            foreach (Transactions t in transactions)
            {
                XElement xc = new XElement((t is ApiTransactions) ? "ApiTransaction" : "CustomTransaction");
                xc.Add(
                new object[]
                {
                    new XAttribute("clientID", t.ClientID),
                    new XAttribute("clientName", t.ClientName),
                    new XAttribute("dateTime", t.DateTime),
                    new XAttribute("ignored", t.Ignored),
                    new XAttribute("price", t.Price),
                    new XAttribute("quantity", t.Quantity),
                    new XAttribute("stationID", t.StationID),
                    new XAttribute("stationName", t.StationName),
                    new XAttribute("transactionFor", t.TransactionFor),
                    new XAttribute("transactionType", t.TransactionType),
                    new XAttribute("typeID", t.TypeID),
                    new XAttribute("typeName", t.TypeName)
                });

                if (t is ApiTransactions)
                {
                    xc.Add(new XAttribute("externalID", (t as ApiTransactions).ExternalID));
                    xt.Add(xc);
                }
                if (t is CustomTransactions)
                {
                    xc.Add(
                        new object[] 
                        {
                            new XAttribute("created", (t as CustomTransactions).Created),
                            new XAttribute("description", (t as CustomTransactions).Description)
                        });
                    xcustom.Add(xc);
                }
            }

            return new XElement("Transactions",
                new object[]
                {
                    xt,
                    xcustom
                });
        }

        private XElement ExportJournal(IEnumerable<Journal> journal)
        {

            XElement xa = new XElement("ApiJournal");
            XElement xc = new XElement("CustomJournal");

            foreach (var j in journal)
            {
                XElement xcurrent = new XElement(j is ApiJournal ? "ApiJournal" : "CustomJournal");

                xcurrent.Add(new object[]
                {
                    new XAttribute("amount", j.Amount),
                    new XAttribute("argID1", j.ArgID1),
                    new XAttribute("argName1", j.ArgName1),
                    new XAttribute("balance", j.Balance),
                    new XAttribute("datetime", j.DateTime),
                    new XAttribute("ownerID1", j.OwnerID1),
                    new XAttribute("ownerID2", j.OwnerID2),
                    new XAttribute("ownerName1", j.OwnerName1),
                    new XAttribute("ownerName2", j.OwnerName2),
                    new XAttribute("reason", j.Reason),
                    new XAttribute("refTypeID", j.RefTypeID),
                    new XAttribute("taxAmount", j.TaxAmount),
                    new XAttribute("taxReceiverID", j.TaxReceiverID)
                });
                if (j is ApiJournal)
                {
                    xcurrent.Add(new XAttribute("externalID", (j as ApiJournal).ExternalID));
                    xa.Add(xcurrent);
                }
                if (j is CustomJournal)
                {
                    xcurrent.Add(new object[]
                    {
                        new XAttribute("created", (j as CustomJournal).Created),
                        new XAttribute("description", (j as CustomJournal).Description)
                    });
                    xc.Add(xcurrent);
                }


            }


            XElement xe = new XElement("Journal", new object[]
                {
                    xa,
                    xc
                });

            return xe;
        }

        private XElement ExportMarketOrders(IEnumerable<MarketOrders> marketOrders)
        {
            XElement xe = new XElement("MarketOrders");

            foreach (var mo in marketOrders)
            {
                xe.Add(new XElement("MarketOrder", new object[]
                {
                    new XAttribute("accountKey", mo.AccountKey),
                    new XAttribute("bid", mo.Bid),
                    new XAttribute("duration", mo.Duration),
                    new XAttribute("escrow", mo.Escrow),
                    new XAttribute("externalID", mo.ExternalID),
                    new XAttribute("issued", mo.Issued),
                    new XAttribute("minimumValue", mo.MinimumVolume),
                    new XAttribute("orderState", mo.OrderState),
                    new XAttribute("price", mo.Price),
                    new XAttribute("range", mo.Range),
                    new XAttribute("stationID", mo.StationID),
                    new XAttribute("typeID", mo.TypeID),
                    new XAttribute("volumeEntered", mo.VolumeEntered),
                    new XAttribute("volumeRemaining", mo.VolumeRemaining)
                }));
            }

            return xe;
        }

        private XElement ExportCharacters(Characters characters)
        {
            XElement xe = new XElement("Characters");

            xe.Add(
            new object[]
                {   
                    new XAttribute("id", characters.ID),
                    new XAttribute("name", characters.Name)
                });

            xe.Add(
                new object[]
                {
                    new XElement("Balance", characters.Balance),
                    new XElement("Bloodline", characters.Bloodline),
                    new XElement("Gender", characters.Gender),
                    new XElement("Race", characters.Race),
                    ExportWallets(characters.Wallets),
                    ExportMarketOrders(characters.MarketOrders),
                    new XElement("ReferencedCorporation", characters.ID)
                });

            return xe;
        }
    }
}