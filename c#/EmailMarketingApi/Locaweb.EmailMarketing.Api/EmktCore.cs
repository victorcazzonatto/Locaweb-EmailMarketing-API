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
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using Locaweb.EmailMarketing.Api.Contatos;


namespace Locaweb.EmailMarketing.Api
{
    public class EmktCore
    {

        public static string GET(string url)
        {
            System.Net.HttpWebRequest oWebReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            oWebReq.CookieContainer = new System.Net.CookieContainer();

            System.Net.HttpWebResponse oResp = (System.Net.HttpWebResponse)oWebReq.GetResponse();

            StreamReader sr = new StreamReader(oResp.GetResponseStream());
            string sResp = sr.ReadToEnd();
            sr.Close();

            return sResp;
        }

        public static List<Contato> convertJsonToObject(string strJson)
        {
            List<Contato> lcontatos = new List<Contato>();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            lcontatos = serializer.Deserialize<List<Contato>>(strJson);

            return lcontatos;
           
        }

    }
}
