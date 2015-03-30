using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE6Test
    {
        [TestMethod]
        public void Test()
        {
            IE6 ie6 = new IE6();
            string ua = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)";
            Assert.IsTrue(ie6.UserAgentRegex.IsMatch(ua));
        }
    }
}
