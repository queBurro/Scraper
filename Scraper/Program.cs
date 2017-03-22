using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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

            Console.ReadLine();
        }

        private static async void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            int iWait = random.Next(0, 30);

            Thread.Sleep(iWait * 1000);

            var val = ScrapeWS01().Result;

            Console.WriteLine(DateTime.Now + " " + val);
        }

        public async static Task<string> ScrapeWS01()
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

            var ret = GetBetween(tmp, "We now have", "watches in the workshop").Trim();

            return ret;
            //Console.ReadLine();
        }

        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        

    }
}
