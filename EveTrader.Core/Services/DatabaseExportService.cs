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
            XDocument xd = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));

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
            xe.Add("Wallet",
                new object[]
                {
                    new XAttribute("accountKey", w.AccountKey),
                    new XAttribute("balance", w.Balance),
                    new XAttribute("id", w.ID),
                    new XAttribute("name", w.Name),
                    ExportJournal(w.Journal),
                    ExportTransactions(w.Transactions),
                    ExportWalletHistory(w.WalletHistory)
                });
            }

            return xe;
        }

        private object ExportWalletHistory(IEnumerable<WalletHistories> walletHistories)
        {
            throw new NotImplementedException();
        }

        private object ExportTransactions(IEnumerable<Transactions> transactions)
        {
            throw new NotImplementedException();
        }

        private object ExportJournal(IEnumerable<Journal> journal)
        {
            throw new NotImplementedException();
        }

        private XElement ExportMarketOrders(IEnumerable<MarketOrders> marketOrders)
        {
            XElement xe = new XElement("MarketOrders");

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
