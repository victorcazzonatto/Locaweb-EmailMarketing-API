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

namespace Locaweb.EmailMarketing.Api.Contatos
{
    [Serializable]
    public class Contato
    {
        //esses são os campos padrões de um contato
        //para adicionar campos extras, chamar a URL da API no browser, pegar o nome dos atributos, e adicionar como atributo desta classe
        public string email;
        public string nome;
        public string htmlemail;
        public string sobrenome;
        public string dataDeNascimento;
        public string sexo;
        public string empresa;
        public string departamento;
        public string cargo;
        public string endereco;
        public string numero;
        public string complemento;
        public string bairro;
        public string cidade;
        public string estado;
        public string cep;
        public string telefoneresidencial;
        public string telefonecomercial;
        public string telefonecelular;
        public string fax;
        public string anotacoes;        
    }
}
