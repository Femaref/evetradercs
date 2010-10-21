using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveTrader.Core;
using EveTrader.Core.Model.Static;
using EveTrader.Core.Model.Trader;
using EveTrader.Core.ViewModel;
using EveTrader.Core.Network.Requests.CCP;
using EveTrader.Core.Updater.CCP;
using System.IO;
using EveTrader.Core.ViewModel.Display;
namespace TestProject1
{

    //this is by no means a good testing class
    [TestClass]
    public class VariousStuff
    {
        TraderModel t = new TraderModel();
        StaticModel s = new StaticModel();

        [TestMethod]
        public void test()
        {
            var x = (from i in t.Entity
                     where i is Characters
                     select i).OfType<Characters>();

            Assert.IsTrue(x is IQueryable<Characters> && x.Count() == 2);
        }


        [TestMethod]
        public void test2()
        {

            CustomTransactions ct = new CustomTransactions()
            {
                ClientID = 1,
                ClientName = "Test",
                Created = DateTime.UtcNow,
                Date = DateTime.UtcNow,
                Description = "A Test Custom Transaction",
                Ignored = false,
                Price = 1.0m,
                Quantity = 1,
                StationID = 1334,
                StationName = "Test StatioN",
                TransactionFor = (long)TransactionFor.Corporation,
                TransactionType = (long)TransactionType.Buy,
                TypeID = 34,
                TypeName = "Tritatium",
                Wallet = t.Wallets.Where(w => w.Entity.Name == "Femaref" && w.AccountKey == 1000).First()
            };


            t.AddToTransactions(ct);
            t.SaveChanges();

            Assert.IsTrue(t.Transactions.OfType<CustomTransactions>().Count(c => c.ID == ct.ID) == 1);
            Assert.IsTrue(t.Wallets.Where(w => w.Entity.Name == "Femaref" && w.AccountKey == 1000).First().Transactions.Count(c => c.ID == ct.ID) == 1);
        }

        [TestMethod]
        public void test3()
        {
            ApiTransactions at = new ApiTransactions()
             {
                 ClientID = 1,
                 ClientName = "Test",
                 ExternalID = 1,
                 Date = DateTime.UtcNow,
                 Ignored = false,
                 Price = 1.0m,
                 Quantity = 1,
                 StationID = 1334,
                 StationName = "Test StatioN",
                 TransactionFor = (long)TransactionFor.Corporation,
                 TransactionType = (long)TransactionType.Buy,
                 TypeID = 34,
                 TypeName = "Tritatium",
                 Wallet = t.Wallets.Where(w => w.Entity.Name == "Femaref" && w.AccountKey == 1000).First()
             };

            t.AddToTransactions(at);
            t.SaveChanges();

            Assert.IsTrue(t.Transactions.OfType<ApiTransactions>().Count(c => c.ID == at.ID) == 1);
            Assert.IsTrue(t.Wallets.Where(w => w.Entity.Name == "Femaref" && w.AccountKey == 1000).First().Transactions.Count(c => c.ID == at.ID) == 1);
        }

        [TestMethod]
        public void WriteToLogTest()
        {
            Assert.IsTrue(!string.IsNullOrEmpty(t.WriteToLog("test", "VariousStuff.WriteToLogTest")));
        }

        [TestMethod]
        public void IterationTest()
        {
            List<DisplayWallets> EntityWallets = new List<DisplayWallets>();
            foreach (Entities e in t.Entity)
            {
                if (e is Characters)
                    EntityWallets.Add(new DisplayWallets() { Name = e.Name, Balance = e.Wallets.First().Balance });
                if (e is Corporations)
                {
                    foreach (Wallets w in e.Wallets)
                    {
                        EntityWallets.Add(new DisplayWallets() { Name = string.Format("{0}: {1}", e.Name, w.Name), Balance = w.Balance });
                    }
                }
            }
        }

        [TestMethod]
        public void CharacterListRequestTest()
        {
            CharacterListRequest clr = new CharacterListRequest(t.Accounts.First(a => a.ID == 334887), t.StillCached, t.SaveCache, t.LoadCache);
            var x = clr.Request();
            Assert.IsTrue(x.Count() == 3);
        }

        [TestMethod]
        public void CharacterUpdaterTest()
        {
            //CharacterUpdater cu = new CharacterUpdater(t, new EntityFactory(t), new CharacterSheetUpdater(t, new CorporationUpdater(t, new EntityFactory(t), new CorporationSheetUpdater(t))));
            //Assert.IsTrue(cu.Update(1807434339));
        }

        [TestMethod]
        public void CreateNewCharacterTest()
        {
            //CharacterUpdater cu = new CharacterUpdater(t, new EntityFactory(t), new CharacterSheetUpdater(t, new CorporationUpdater(t, new EntityFactory(t), new CorporationSheetUpdater(t))));
            //Assert.IsTrue(cu.Update(489322128, t.Accounts.First(f => f.ID == 620637)));
        }
        public void CreateNewCorporationTest()
        {
           // CorporationUpdater cu = new CorporationUpdater(t, new EntityFactory(t), new CorporationSheetUpdater(t));
            //Assert.IsTrue(cu.Update(489322128, t.Accounts.First(f => f.ID == 620637)));
        }
        [TestMethod]
        public void AccountBalanceTest()
        {
            AccountBalanceUpdater abu = new AccountBalanceUpdater(t);

            Assert.IsTrue(abu.Update(t.Entity.First(e => e.Name == "Femaref")));
        }

        [TestMethod]
        public void MarketOrdersUpdateTest()
        {
            MarketOrdersUpdater mou = new MarketOrdersUpdater(t);

            Assert.IsTrue(mou.Update(t.Entity.First(e => e.Name =="Selena Karen")));
        }

        [TestMethod]
        public void JournalUpdateTest()
        {
            JournalUpdater ju = new JournalUpdater(t);

            Assert.IsTrue(ju.Update(t.Entity.First(e => e.Name == "Femaref")));
        }

        [TestMethod]
        public void TransactionsUpdateTest()
        {
          //  TransactionsUpdater ju = new TransactionsUpdater(t);

         //   Assert.IsTrue(ju.Update(t.Entity.First(e => e.Name == "Femaref")));
        }

        [TestMethod]
        public void StaticDbTest()
        {
            Assert.IsTrue(s.invTypes.Where(i => i.typeID == 34).First().typeName == "Tritanium");
        }

        [TestMethod]
        public void ImportCacheFile()
        {
            EveCacheCLI.ManagedMarket mm = new EveCacheCLI.ManagedMarket(Path.Combine(@"F:\EVE\cache\MachoNet\87.237.38.200\244\CachedMethodCalls", "4c53.cache"));
            EveCacheCLI.MarketOrderList mo = mm.GetOrders();

            Assert.IsTrue(mo.Orders.Count() > 0);
        }
    }
}
