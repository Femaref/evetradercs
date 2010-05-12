using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveTrader.Core;
using EveTrader.Core.Model;
namespace TestProject1
{

    //this is by no means a good testing class
    [TestClass]
    public class VariousStuff
    {
        TraderModel t = new TraderModel();

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
    }
}
