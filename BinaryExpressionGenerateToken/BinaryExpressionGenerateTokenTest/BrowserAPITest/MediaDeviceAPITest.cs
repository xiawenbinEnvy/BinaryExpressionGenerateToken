using Jurassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.BrowserAPITest
{
    /// <summary>
    /// MediaDeviceAPI测试类
    /// </summary>
    [TestClass]
    public class MediaDeviceAPITest
    {
        /// <summary>
        /// 场景：MediaDeviceAPI在js引擎中使用
        /// 预期：不可使用
        /// </summary>
        [TestMethod]
        public void CannotUseInJSEnginee()
        {
            string jsFormat = "var f = function() {var i = 30; #replace# var j = 10; return i + j;}; f();";
            var engine = new ScriptEngine();
            IBrowserAPI api = new MediaDeviceAPI();
            var result = engine.Evaluate<int>(jsFormat.Replace("#replace#", api.GetAPIJSCode()));

            Assert.AreNotEqual(result, 40);
        }

        /// <summary>
        /// 场景：测试浏览器可用性
        /// 预期：见被测试类注释
        /// </summary>
        [TestMethod]
        public void BrowserEnable()
        {
            IBrowserAPI api = new MediaDeviceAPI();
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE6()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE7()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE8()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE9()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE10()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new IE11()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new Chrome()));
            Assert.IsTrue(api.IsThisBrowserEnableThisBrowserAPI(new Firefox()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new Opera()));
            Assert.IsFalse(api.IsThisBrowserEnableThisBrowserAPI(new Safari()));
        }
    }
}
