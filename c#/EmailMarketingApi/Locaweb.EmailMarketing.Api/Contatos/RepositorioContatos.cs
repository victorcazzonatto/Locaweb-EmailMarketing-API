/*
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Está é uma API exemplo que facilita a utilização dos web services do Email Marketing.
 *
 * versao 0.1
 * mais detalhes em http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */
using System;
using System.Collections.Generic;
using System.Net;

namespace Locaweb.EmailMarketing.Api.Contatos
{
    public class RepositorioContatos
    {
        /// <summary>
        /// Nome do servidor
        /// </summary>
        private string hostname;
        /// <summary>
        /// Login usado no Email Marketing
        /// </summary>
        private string login;
        /// <summary>
        /// Chave gerada para uso dessa API
        /// </summary>
        private string chave;

        private string hostnameSufix;
                
        private IEmktCore emktCore;

        public RepositorioContatos(string hostname, string login, string chave, string hostnameSufix)
        {
            this.hostname = hostname;
            this.login = login;
            this.chave = chave;
            this.hostnameSufix = hostnameSufix;
            this.emktCore = new EmktCore();
        }

        public RepositorioContatos(string hostname, string login, string chave, string hostnameSufix, IEmktCore emktCore)
        {
            this.hostname = hostname;
            this.login = login;
            this.chave = chave;
            this.hostnameSufix = hostnameSufix;
            this.emktCore = emktCore;
        }

        #region metodos publicos

        #region metodos de listagem de contatos
        
        public List<Contato> obterValidos(int pagina)
        {
            return this.obterPorStatus(pagina, "validos");
        }

        public List<Contato> obterInvalidos(int pagina)
        {
            return this.obterPorStatus(pagina, "invalidos");
        }

        public List<Contato> obterNaoConfirmados(int pagina)
        {
            return this.obterPorStatus(pagina, "nao_confirmados");
        }

        public List<Contato> obterDescadastrados(int pagina)
        {
            return this.obterPorStatus(pagina, "descadastrados");
        }
        #endregion

        #endregion

        #region metodos privados

        /// <summary>
        /// Retorna todos os contatos.         
        /// </summary>
        /// <param name="pagina">Número da página</param>
        /// <returns></returns>
        private List<Contato> obterPorStatus(int pagina, string status)
        {
            //nao deixa pagina negativa
            pagina = (pagina <= 0) ? 1 : pagina;

            string urlApi = string.Format("http://{0}.{1}/admin/api/{2}/contacts/{3}?chave={4}&pagina={5}",
                                       this.hostname,
                                       this.hostnameSufix,
                                       this.login,
                                       status,
                                       this.chave,
                                       pagina);


            string json = this.emktCore.GET(urlApi);
            return EmktCore.converteJsonParaObjeto<Contato>(json);

        }

        #endregion
    }
}
