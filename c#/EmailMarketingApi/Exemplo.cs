using System;
using System.Collections.Generic;
using Locaweb.EmailMarketingApi;
using System.Net;
using System.IO;

namespace EmailMarketingApi
{
    class Exemplo
    {
        static void Main(string[] args)
        {
            const string HOSTNAME = "testelmm";
            const string LOGIN = "gustavo";
            const string CHAVE_API = "e538ea19267cfdb98f423209419ff77c";

            EmailMkt emailmkt = new EmailMkt(HOSTNAME, LOGIN, CHAVE_API);

            try
            {                                
                List<Contato> contatos;

                for (int pagina = 1; (contatos = emailmkt.retornaContatosValidos(pagina)).Count > 0; pagina++)
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
