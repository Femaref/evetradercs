using EveTrader.Updater;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

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
    }
}
