using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using EveTrader.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericObjectDispatcherTest
{
    /// <summary>
    /// Summary description for DispatcherList
    /// </summary>
    [TestClass]
    public class DispatcherListTest
    {
        private IGenericObjectDispatcher dispatcher;
        private DispatcherList<WalletJournalRecord> list;

        public DispatcherListTest()
        {
            dispatcher = new XmlGenericObjectDispatcher();
            list = new DispatcherList<WalletJournalRecord>(dispatcher, w => (w.Parent is Character) && (w.Parent as Character).Name == "Femaref");
            dispatcher.Add(new Character() {Name = "Femaref"});
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
        public void AddToList()
        {
            WalletJournalRecord r = new WalletJournalRecord()
                                        {Parent = dispatcher.GetByType<Character>(x => x.Name == "Femaref").Single()};
            list.Add(r);

            Assert.IsTrue(list.Count == 1 && dispatcher.GetByType<WalletJournalRecord>().Count() == 1);
        }
        [TestMethod]
        public void Clear()
        {
            AddToList();
            list.Clear();

            Assert.IsTrue(list.Count == 0);
        }
    }
}
