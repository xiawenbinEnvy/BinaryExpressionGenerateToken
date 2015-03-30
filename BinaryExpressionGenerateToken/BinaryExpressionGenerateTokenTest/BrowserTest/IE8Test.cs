using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE8Test
    {
        [TestMethod]
        public void Test()
        {
            IE8 ie8 = new IE8();
            string ua1 = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB7.0)";
            string ua2 = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; InfoPath.3)";
            Assert.IsTrue(ie8.UserAgentRegex.IsMatch(ua1));
            Assert.IsTrue(ie8.UserAgentRegex.IsMatch(ua2));
        }
    }
}
