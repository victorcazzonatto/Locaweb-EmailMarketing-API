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

namespace Locaweb.EmailMarketing.Api
{
    public interface IEmktCore
    {
        string GET(string url);        
    }

    public class EmktCore : IEmktCore
    {

        public string GET(string url)
        {
            try
            {
                System.Net.HttpWebRequest oWebReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                oWebReq.CookieContainer = new System.Net.CookieContainer();

                System.Net.HttpWebResponse oResp = (System.Net.HttpWebResponse)oWebReq.GetResponse();

                StreamReader sr = new StreamReader(oResp.GetResponseStream());
                string sResp = sr.ReadToEnd();
                sr.Close();

                return sResp;
            }
            catch (WebException e)
            {
                #region tratamento da exceção
                if (e.Response == null)
                {
                    throw e;                    
                }
                                
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    StreamReader sr = new StreamReader(httpResponse.GetResponseStream());
                    string message = sr.ReadToEnd();
                    sr.Close();

                    throw new EmktApiException(string.Format("Chama HTTP retornou código: {0}, mensagem: {1}: ",
                            Convert.ToInt32(httpResponse.StatusCode),
                            message));
                }
                #endregion
            }
            
        }

        public static List<T> converteJsonParaObjeto<T>(string strJson)
        {
            List<T> lcontatos = new List<T>();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 10485760; //10MB caracteres          
            Console.WriteLine(strJson.Length);
            lcontatos = serializer.Deserialize<List<T>>(strJson);

            return lcontatos;
           
        }

    }
}
