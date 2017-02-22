using System;
using System.Linq;
using System.Net;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpClient w = new HttpClient();
            var resp = w.GetAsync("https://watchguy.co.uk/cgi-bin/book").Result;




            var cont = resp.Content;


            // 2.
            //foreach (LinkItem i in LinkFinder.Find(resp))
            //{
            //    Debug.WriteLine(i);
            //}


            //var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            //htmlDoc.OptionFixNestedTags = true;

            //string urlToLoad = "https://watchguy.co.uk/cgi-bin/book";//  "http://techcrunch.com/apps/";
            //HttpWebRequest request = HttpWebRequest.Create(urlToLoad) as HttpWebRequest;
            //request.Method = "GET";

            ///* Sart browser signature */
            ////request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            ////request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            ////request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            ///* Sart browser signature */

            //Console.WriteLine(request.RequestUri.AbsoluteUri);
            //WebResponse response = request.GetResponse();

            //htmlDoc.Load(response.GetResponseStream(), true);
            //if (htmlDoc.DocumentNode != null)
            //{
            //    var articleNodes = htmlDoc.DocumentNode.SelectNodes("/html/body/div[@role='main']/div[1]/div/div[1]/div/ul/li");

            //    if (articleNodes != null && articleNodes.Any())
            //    {
            //        foreach (var articleNode in articleNodes)
            //        {
            //            var titleNode = articleNode.SelectSingleNode("div/div/h2/a");
            //            Console.WriteLine(WebUtility.HtmlDecode(titleNode.InnerText.Trim()));
            //            Console.WriteLine("---xxxxxxxxxxxx-----");
            //        }
            //    }
            //}

            Console.ReadLine();

        }
    }
}
