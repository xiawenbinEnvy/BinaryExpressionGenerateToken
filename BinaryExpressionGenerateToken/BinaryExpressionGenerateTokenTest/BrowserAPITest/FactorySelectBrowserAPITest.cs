using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserAPITest
{
    /// <summary>
    /// FactorySelectBrowserAPI 测试类
    /// </summary>
    [TestClass]
    public class FactorySelectBrowserAPITest
    {
        FactorySelectBrowserAPI testedClass = null;

        /// <summary>
        /// 初始化
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            testedClass = new FactorySelectBrowserAPI();
        }

        /// <summary>
        /// 预期：被测类中的浏览器实体和浏览器api实体必须存在
        /// </summary>
        [TestMethod]
        public void FactorySelectBrowserAPI_BrowserAndBrowserAPIIsNotNull()
        {
            Assert.IsTrue(FactorySelectBrowserAPI.apis != null && FactorySelectBrowserAPI.apis.Count > 0);
            Assert.IsTrue(FactorySelectBrowserAPI.browsers != null && FactorySelectBrowserAPI.browsers.Count > 0);
        }
    }
}
