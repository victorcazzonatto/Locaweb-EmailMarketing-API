using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Locaweb.Net;
using System.Net;

namespace Locaweb.EmailMarketingApi
{
    public class EmailMkt
    {
        private string hostname;
        private string login;
        private string chaveApi;
        //private string hostnameSufix = "locaweb.com.br";
        private const string HOSTNAME_SUFIX = "tecnologia.ws";

        public EmailMkt(string hostname, string login, string chaveApi)
        {
            this.hostname = hostname;
            this.login = login;
            this.chaveApi = chaveApi;
        }

        #region metodos publicos

        public List<Contato> retornaContatosValidos(int pagina)
        {
            return this.retornaContatosPorStatus(pagina, "validos");
        }

        public List<Contato> retornaContatosInvalidos(int pagina)
        {
            return this.retornaContatosPorStatus(pagina, "invalidos");
        }

        public List<Contato> retornaContatosNaoConfirmados(int pagina)
        {
            return this.retornaContatosPorStatus(pagina, "nao_confirmados");
        }

        public List<Contato> retornaContatosDescadastrados(int pagina)
        {
            return this.retornaContatosPorStatus(pagina, "descadastrados");
        }

        #endregion

        #region metodos privados

        /// <summary>
        /// Retorna todos os contatos. Se o número de contatos forsuperior a xxxx contatos, os contatos são quebrados em páginas de xxxx elementos.	 
        /// </summary>
        /// <param name="pagina">Número da página</param>
        /// <returns></returns>
        private List<Contato> retornaContatosPorStatus(int pagina, string status)
        {
            List<Contato> lcontatos = new List<Contato>();

            string urlApi = string.Format("http://{0}.{1}/admin/api/{2}/contacts/{3}?chave_api={4}&pagina={5}",
                                       this.hostname,
                                       HOSTNAME_SUFIX,
                                       this.login,
                                       status,
                                       this.chaveApi,
                                       pagina);

            string json = "";
            try
            {
                json = HttpClient.GET(urlApi);
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    Console.WriteLine("Ocorreu algum problema ao pegar a mensagem de erro");
                }

                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        return lcontatos;
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();            
            lcontatos = serializer.Deserialize<List<Contato>>(json);

            return lcontatos;
        }

        #endregion
    }
}
