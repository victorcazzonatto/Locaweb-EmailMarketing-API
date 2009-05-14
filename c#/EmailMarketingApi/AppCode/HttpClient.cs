using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.ServiceModel.Web;


namespace Locaweb.Net
{
    public class HttpClient
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

    }
}
