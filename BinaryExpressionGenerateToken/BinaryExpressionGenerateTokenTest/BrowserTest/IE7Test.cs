using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE7Test
    {
        [TestMethod]
        public void Test()
        {
            IE7 ie7 = new IE7();
            string ua = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            Assert.IsTrue(ie7.UserAgentRegex.IsMatch(ua));
        }
    }
}
