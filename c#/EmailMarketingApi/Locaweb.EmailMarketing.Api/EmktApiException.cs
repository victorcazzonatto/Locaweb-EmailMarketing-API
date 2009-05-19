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
using System.Linq;
using System.Text;

namespace Locaweb.EmailMarketing.Api
{
    public class EmktApiException: Exception
    {
        public EmktApiException() : base() { }
        public EmktApiException(string message) : base(message) { }
    }
}
