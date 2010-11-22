using EveTrader.Core.DataConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;
using System.IO;

namespace EveTrader.Core.DataConverter.Test
{


    /// <summary>
    ///This is a test class for XmlToSqliteTest and is intended
    ///to contain all XmlToSqliteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlToSqliteTest
    {


        private TestContext testContextInstance;

        private XmlToSqlite converter = new XmlToSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "settings.xml"));

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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void ConvertTest()
        {
            Assert.IsTrue(converter.Convert());
        }


        /// <summary>
        ///A test for CreateDatabase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EveTrader.Core.DataConverter.dll")]
        public void CreateDatabaseTest()
        {
            PrivateObject param0 = new PrivateObject(converter); // TODO: Initialize to an appropriate value
            XmlToSqlite_Accessor target = new XmlToSqlite_Accessor(param0); // TODO: Initialize to an appropriate value
            string path = ""; // TODO: Initialize to an appropriate value
            string expected = Path.Combine("", "EveTrader.db"); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CreateDatabase(path);
            Assert.AreEqual(expected, actual);
        }
    }
}
