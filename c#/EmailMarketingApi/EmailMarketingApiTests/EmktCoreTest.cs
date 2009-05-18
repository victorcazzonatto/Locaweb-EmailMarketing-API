using Locaweb.EmailMarketing.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Locaweb.EmailMarketing.Api.Contatos;
using System.Collections.Generic;

namespace EmailMarketingApiTests
{
    
    
    /// <summary>
    ///This is a test class for EmktCoreTest and is intended
    ///to contain all EmktCoreTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmktCoreTest
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

                
        [TestMethod()]
        public void converteJsonParaObjetoTestOk()
        {
            string strJson = "[{\"email\":\"xconta4@testecarganl.tecnologia.ws\",\"nome\":\"nomeTeste\"}]";
            List<Contato> expected = new List<Contato>();
            expected.Add(new Contato() { email = "xconta4@testecarganl.tecnologia.ws", nome = "nomeTeste" });
            
            List<Contato> actual;
            actual = EmktCore.converteJsonParaObjeto<Contato>(strJson);
            Assert.AreEqual(expected[0].nome, actual[0].nome);
            Assert.AreEqual(expected[0].email, actual[0].email);            
        }

    }
}
