using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE10Test
    {
        [TestMethod]
        public void Test()
        {
            IE10 ie10 = new IE10();
            string ua = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            Assert.IsTrue(ie10.UserAgentRegex.IsMatch(ua));
        }
    }
}
