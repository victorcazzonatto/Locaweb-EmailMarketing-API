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
            //para saber quais valores utilizar, consulte a página de configurações do Email Marketing
            //mais informações em http://wiki.locaweb.com.br/pt-br/APIs_do_Email_Marketing

            const string HOSTNAME       = "";
            const string LOGIN          = "";
            const string CHAVE_API      = "";
            const string HOSTNAME_SUFIX = "locaweb.com.br";            

            RepositorioContatos contatoApi = new RepositorioContatos(HOSTNAME, LOGIN, CHAVE_API, HOSTNAME_SUFIX);

            try
            {
                List<Contato> contatos;

                for (int pagina = 1; (contatos = contatoApi.obterValidos(pagina)) != null ; pagina++)
                {
                    Console.WriteLine("pagina " + pagina);
                    
                    foreach (Contato c in contatos)
                    {
                        Console.WriteLine(string.Format("nome:{0}, email:{1}, dataNasc:{2}, estado:{3}",
                            c.nome, c.email, c.dataDeNascimento, c.estado));
                    }
                }
                Console.WriteLine(System.GC.GetTotalMemory(true).ToString());

            }
            catch (EmktApiException e)
            {
                Console.WriteLine("Erro na chamada da API: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro inesperado: " + e.Message);
            }
        }
    }
}

