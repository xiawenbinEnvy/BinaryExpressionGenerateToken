using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE11Test
    {
        [TestMethod]
        public void Test()
        {
            IE11 ie11 = new IE11();
            string ua = "Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko";
            Assert.IsTrue(ie11.UserAgentRegex.IsMatch(ua));
        }
    }
}
