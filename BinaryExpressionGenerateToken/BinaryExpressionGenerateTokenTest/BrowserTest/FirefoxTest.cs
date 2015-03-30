using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class FirefoxTest
    {
        [TestMethod]
        public void Test()
        {
            Firefox Firefox = new Firefox();
            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:36.0) Gecko/20100101 Firefox/36.0";
            Assert.IsTrue(Firefox.UserAgentRegex.IsMatch(ua));
        }
    }
}
