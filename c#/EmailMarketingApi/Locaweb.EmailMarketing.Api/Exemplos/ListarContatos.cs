/*
 *  Copyright (c) 2009, Locaweb LTDA.
 * 	Todos os direitor reservados.
 *
 *  Está é uma API exemplo que facilita a utilização dos web services do Email Marketing.
 *
 * versao 1.0
 * mais detalhes em http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing
 */
using System;
using System.Collections.Generic;
using Locaweb.EmailMarketing.Api.Contatos;
using System.Net;
using System.IO;

namespace Locaweb.EmailMarketing.Api.Exemplos
{
    class ListarContatos
    {
        static void Main(string[] args)
        {
            const string HOSTNAME = "testelmm";
            const string LOGIN = "gustavo";
            const string CHAVE_API = "e538ea19267cfdb98f423209419ff77c";

            RepositorioContatos contatoApi = new RepositorioContatos(HOSTNAME, LOGIN, CHAVE_API);

            try
            {
                List<Contato> contatos;

                for (int pagina = 1; (contatos = contatoApi.getValidos(pagina)) != null ; pagina++)
                {
                    Console.WriteLine("pagina " + pagina);

                    foreach (Contato c in contatos)
                    {
                        Console.WriteLine(string.Format("nome:{0}, email:{1}, dataNasc:{2}, estado:{3}",
                            c.nome, c.email, c.dataDeNascimento, c.estado));
                    }
                }

            }
            catch (WebException e)
            {
                #region tratamento da exceção
                if (e.Response == null)
                {
                    Console.WriteLine("Ocorreu algum problema ao pegar a mensagem de erro");
                }

                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    if (httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        Console.WriteLine("Erro interno na chamada da API: " + e.Message);
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Console.WriteLine("Falha na autenticação na chamada da API: " + e.Message);
                    }
                    else if (httpResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        Console.WriteLine("Parametros inválidos na chamada da API: " + e.Message);
                    }
                    else
                    {
                        Console.WriteLine("Erro nao indentificado na chamada da API: " + e.Message);
                    }
                }
                #endregion
            }
        }
    }
}

