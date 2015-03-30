using Jurassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserAPITest
{
    /// <summary>
    /// 浏览器历史记录api 测试
    /// </summary>
    [TestClass]
    public class HistoryAPITest
    {
        /// <summary>
        /// 场景：浏览器历史记录api在js引擎中使用
        /// 预期：不可使用，和js中设置值不同
        /// </summary>
        [TestMethod]
        public void CannotUseInJSEnginee()
        {
            string jsFormat = "var f = function() {var i = 30; #replace# var j = 10; return i + j;}; f();";
            var engine = new ScriptEngine();
            IBrowserAPI api = new HistoryAPI();
            var result = engine.Evaluate<int>(jsFormat.Replace("#replace#", api.GetAPIJSCode()));

            Assert.AreNotEqual(result, 40);
        }

        /// <summary>
        /// 场景：测试浏览器可用性
        /// 预期：所有浏览器都可用
        /// </summary>
        [TestMethod]
        public void BrowserEnable()
        {
            IBrowserAPI api = new HistoryAPI();
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE6()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE7()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE8()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE9()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE10()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new IE11()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Chrome()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Firefox()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Opera()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Safari()));
        }
    }
}
