using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserTest
{
    [TestClass]
    public class OperaTest
    {
        [TestMethod]
        public void Test()
        {
            Opera Opera = new Opera();
            string ua = "Opera/9.80 (Windows NT 6.1; U; zh-cn) Presto/2.9.168 Version/11.50";
            Assert.IsTrue(Opera.UserAgentRegex.IsMatch(ua));
        }
    }
}
