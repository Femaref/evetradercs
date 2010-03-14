using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using EveTrader;
using EveTrader.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericObjectDispatcherTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class XmlGenericObjectDispatcherTest
    {
        private XmlGenericObjectDispatcher dispatcher;

        public XmlGenericObjectDispatcherTest()
        {
            dispatcher = new XmlGenericObjectDispatcher();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddObject()
        {
            bool test = dispatcher.Add(new Character() { Name = "Selena Karen" });
            Assert.IsTrue(test && dispatcher.Count == 1);
        }
        [TestMethod]
        public void AddRangeObject()
        {
            bool test = dispatcher.AddRange(new List<IGenericObject>() { new Character() { Name = "Selena Karen" }, new Character() { Name = "Femaref" } });
            Assert.IsTrue(test && dispatcher.Count == 2);
        }

        [TestMethod]
        public void GetObjectByType()
        {
            AddObject();
            Character c = dispatcher.GetByType<Character>().Single();
            Assert.IsTrue(c.Name == "Selena Karen");
        }
        [TestMethod]
        public void GetObjectByTypeFiltered()
        {
            AddRangeObject();
            Character c = dispatcher.GetByType<Character>(x => x.Name == "Femaref").Single();
            Assert.IsTrue(c.Name == "Femaref");
        }
        [TestMethod]
        public void RemoveObject()
        {
            AddRangeObject();
            Character c = dispatcher.GetByType<Character>(x => x.Name == "Femaref").Single();
            bool test = dispatcher.Remove(c);

            Assert.IsTrue(test && dispatcher.Count == 1);
        }
        [TestMethod]
        public void RemoveAllObject()
        {
            AddRangeObject();
            int test = dispatcher.RemoveAll(x => ((Character)x).Name == "Femaref");

            Assert.IsTrue(test == 1 && dispatcher.Count == 1);
        }
        [TestMethod]
        public void RemoveAllPredicate()
        {
            AddRangeObject();
            int test = dispatcher.RemoveAll<Character>();

            Assert.IsTrue(test == 2 && dispatcher.Count == 0);
            AddRangeObject();
        }

        [TestMethod]
        public void AddDifferentObjects()
        {
            AddRangeObject();

            WalletJournalRecord[] input = new WalletJournalRecord[10];

            for (int x = 0; x < 10;x++ )
            {
                input[x] = new WalletJournalRecord() {ReferenceID = x};
                (input[x] as IGenericObject).Parent = dispatcher.GetByType<Character>(s => s.Name == "Femaref").Single();
            }

            bool test = dispatcher.AddRange(input.Cast<IGenericObject>());

            Assert.IsTrue(dispatcher.Count > 2 && test);
        }
        [TestMethod]
        public void GetObjectDifferent()
        {
            AddDifferentObjects();
            var c = dispatcher.GetByType<Character>();
            Assert.IsTrue(c.Count() == 2);
        }
    }
}
