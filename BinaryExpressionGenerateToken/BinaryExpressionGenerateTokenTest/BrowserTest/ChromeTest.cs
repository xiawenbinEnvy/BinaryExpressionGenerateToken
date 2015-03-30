using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class ChromeTest
    {
        [TestMethod]
        public void Test()
        {
            Chrome Chrome = new Chrome();
            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
            Assert.IsTrue(Chrome.UserAgentRegex.IsMatch(ua));
        }
    }
}
