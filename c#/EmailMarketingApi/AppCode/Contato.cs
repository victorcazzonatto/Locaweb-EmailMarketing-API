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

namespace Locaweb.EmailMarketingApi
{
    [Serializable]
    public class Contato
    {
        //esses são exemplos de atributos que são retornandos pelo webservice de contatos
        //para adicionar mais atributos, chamar a URL da API no browser e pegar o nome dos atributos
        public string email;
        public string nome;
        public string dataDeNascimento;
        public string estado;
    }
}
