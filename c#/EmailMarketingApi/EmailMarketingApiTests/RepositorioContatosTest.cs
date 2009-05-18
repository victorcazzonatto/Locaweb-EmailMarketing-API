using Locaweb.EmailMarketing.Api.Contatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NMock2;
using System;
using System.Net;
using Locaweb.EmailMarketing.Api;

namespace Locaweb.EmailMarketing.Api.Contatos
{
    
    
    /// <summary>
    ///This is a test class for RepositorioContatosTest and is intended
    ///to contain all RepositorioContatosTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositorioContatosTest
    {                
        private RepositorioContatos repContatos;
        private string urlApi;
        private IEmktCore mockEmktCore;
        private Mockery mock;
        public RepositorioContatosTest()
        {            
            this.urlApi = "http://teste.locaweb.com.br/admin/api/gustavo/contacts/validos?chave=oifoidsf089ds7&pagina=1";
            string login = "gustavo";
            string chave = "oifoidsf089ds7";
            string hostname = "teste";

            this.mock = new Mockery();
            this.mockEmktCore = (IEmktCore)mock.NewMock<IEmktCore>();

            this.repContatos = new RepositorioContatos(hostname, login, chave, mockEmktCore);
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
        public void getValidosTestSeUrlOk()
        {

            Expect.Once.On(this.mockEmktCore).Method("GET").With(urlApi).Will(Return.Value("[{\"email\":\"xconta4@testecarganl.tecnologia.ws\",\"nome\":\"nomeTeste\"},{\"email\":\"xconta5@testecarganl.tecnologia.ws\",\"nome\":\"nomeTeste2\"}]"));
            List<Contato> contatos = this.repContatos.obterValidos(1);
            Assert.AreEqual(contatos[0].email, "xconta4@testecarganl.tecnologia.ws");
            Assert.AreEqual(contatos[0].nome, "nomeTeste");
            Assert.AreEqual(contatos[1].email, "xconta5@testecarganl.tecnologia.ws");
            Assert.AreEqual(contatos[1].nome, "nomeTeste2");
            this.mock.VerifyAllExpectationsHaveBeenMet();         
        }

        /// <summary>
        /// Este teste só valida se a url do WS é gerada corretamente para o caso de passar uma página negativa como parâmetro
        /// </summary>
        [TestMethod()]
        public void getValidosTestSePaginaInvalida()
        {
            string url =  "http://teste.locaweb.com.br/admin/api/gustavo/contacts/validos?chave=oifoidsf089ds7&pagina=1";
            Expect.Once.On(this.mockEmktCore).Method("GET").With(url).Will(Return.Value(""));
            this.repContatos.obterValidos(-1);
            this.mock.VerifyAllExpectationsHaveBeenMet();            
        }

        [TestMethod()]
        public void getValidosTestSeRetornaVazio()
        {            
            Expect.Once.On(this.mockEmktCore).Method("GET").With(urlApi).Will(Return.Value(""));
            
            List<Contato> contatos = this.repContatos.obterValidos(1);
            Assert.IsNull(contatos);

            this.mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
