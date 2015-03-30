using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class SafariTest
    {
        [TestMethod]
        public void Test()
        {
            Safari Safari = new Safari();
            string ua1 = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50";
            Assert.IsTrue(Safari.UserAgentRegex.IsMatch(ua1));
            string ua2 = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
            Assert.IsFalse(Safari.UserAgentRegex.IsMatch(ua2));
        }
    }
}
