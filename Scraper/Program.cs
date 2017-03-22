using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Timers;

namespace Scraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 45000;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 30);

            Thread.Sleep(randomNumber);

            Console.WriteLine(DateTime.Now);

            //ScrapeWS01();
        }

        public async static void ScrapeWS01()
        {
            var url = "https://watchguy.co.uk/cgi-bin/book";
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

            string tmp;

            var response = httpClient.GetAsync(new Uri(url)).Result;
            //response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(decompressedStream))
            {
                tmp = streamReader.ReadToEnd();
            }

            Console.ReadLine();
        }

        public async static void ScrapeWS()
        {
            //var request = WebRequest.Create("https://watchguy.co.uk/cgi-bin/book");
            //// Set the Method property of the request to POST.
            //request.Method = "POST";
            //var response = request.GetResponse();




            var url = "https://watchguy.co.uk/cgi-bin/book";
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

            string tmp;

            var response = httpClient.GetAsync(new Uri(url)).Result;
            //response.EnsureSuccessStatusCode();
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(decompressedStream))
            {
                tmp = streamReader.ReadToEnd();
            }

            //HttpClient httpClient = new HttpClient();

            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");


            //var response = await httpClient.GetAsync("https://watchguy.co.uk/cgi-bin/book");
            //response.EnsureSuccessStatusCode();

            //using (var responseStream = await response.Content.ReadAsStreamAsync())
            //using (var streamReader = new StreamReader(responseStream))
            //{
            //    Console.WriteLine(streamReader.ReadToEnd());
            //}

            //var cont = resp.Content;

            //var resp = httpClient.get


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
