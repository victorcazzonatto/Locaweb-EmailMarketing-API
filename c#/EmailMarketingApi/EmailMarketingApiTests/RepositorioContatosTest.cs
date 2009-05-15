using Locaweb.EmailMarketing.Api.Contatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EmailMarketingApiTests
{
    
    
    /// <summary>
    ///This is a test class for RepositorioContatosTest and is intended
    ///to contain all RepositorioContatosTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositorioContatosTest
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
        ///A test for getValidos
        ///</summary>
        [TestMethod()]
        public void getValidosTest()
        {
            string hostname = string.Empty; // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            string chave = string.Empty; // TODO: Initialize to an appropriate value
            RepositorioContatos target = new RepositorioContatos(hostname, login, chave); // TODO: Initialize to an appropriate value
            int pagina = 0; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.getValidos(pagina);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
