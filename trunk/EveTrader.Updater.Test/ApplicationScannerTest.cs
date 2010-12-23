using EveTrader.Updater;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EveTrader.Updater.Test
{
    
    
    /// <summary>
    ///This is a test class for ApplicationScannerTest and is intended
    ///to contain all ApplicationScannerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ApplicationScannerTest
    {


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


        /// <summary>
        ///A test for DetermineArchitecture
        ///</summary>
        [TestMethod()]
        [DeploymentItem("EveTrader.Updater.dll")]
        public void DetermineArchitectureTest()
        {
            PortableExecutableKinds pek = new PortableExecutableKinds(); // TODO: Initialize to an appropriate value
            Architecture expected = new Architecture(); // TODO: Initialize to an appropriate value
            Architecture actual;
            actual = ApplicationScanner_Accessor.DetermineArchitecture(pek);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateServerInfo
        ///</summary>
        [TestMethod()]
        public void CreateServerInfoTest()
        {
            IEnumerable<UpdateFile> files = ApplicationScanner.Scan(@"Q:\Projects\evetradercs\EveTrader.Wpf\bin\EveTraderBeta125x64\", true, new Dictionary<string, string>
                {
                    {"EveTrader.Wpf.exe.config", "1.2.5"},
                    {"static.db", "1.0"}
                }, "dll", "exe", "config", "db"); // TODO: Initialize to an appropriate value
            XDocument expected = null; // TODO: Initialize to an appropriate value
            XDocument actual;
            actual = ApplicationScanner.CreateServerInfo(files);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateVersionInfo
        ///</summary>
        [TestMethod()]
        public void CreateVersionInfoTest()
        {
            IEnumerable<UpdateFile> files = ApplicationScanner.Scan(@"Q:\Projects\evetradercs\EveTrader.Wpf\bin\EveTraderBeta125x32\", true, new Dictionary<string, string>
                {
                    {"EveTrader.Wpf.exe.config", "1.2.5"},
                    {"static.db", "1.0"}
                }, "dll", "exe", "exe.config", "db"); // TODO: Initialize to an appropriate value
            XDocument expected = null; // TODO: Initialize to an appropriate value
            XDocument actual;
            actual = ApplicationScanner.CreateVersionInfo(files);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Scan
        ///</summary>
        [TestMethod()]
        public void ScanTest()
        {
            string path = @"Q:\Projects\evetradercs\EveTrader.Wpf\bin\EveTraderBeta125x64\"; // TODO: Initialize to an appropriate value
            bool compress = true; // TODO: Initialize to an appropriate value
            Dictionary<string, string> customVersion = new Dictionary<string, string>
                {
                    {"EveTrader.Wpf.exe.config", "1.2.5"},
                    {"static.db", "1.0"}
                }; // TODO: Initialize to an appropriate value
            IEnumerable<UpdateFile> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<UpdateFile> actual;
            actual = ApplicationScanner.Scan(path, compress, customVersion, "dll", "exe", "exe.config", "db");
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
