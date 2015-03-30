using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class IE9Test
    {
        [TestMethod]
        public void Test()
        {
            IE9 ie9 = new IE9();
            string ua = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident/5.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; Tablet PC 2.0; .NET4.0E)";
            Assert.IsTrue(ie9.UserAgentRegex.IsMatch(ua));
        }
    }
}
