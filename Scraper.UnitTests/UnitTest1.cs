using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scraper.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScrapeWSTest()
        {
            Scraper.Program.ScrapeWS01();
        }
    }
}
