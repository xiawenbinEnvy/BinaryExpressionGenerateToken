using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core
{
    /// <summary>
    /// 选择一个可用的浏览器api
    /// </summary>
    class FactorySelectBrowserAPI
    {
        internal static List<IBrowser> browsers;
        internal static List<IBrowserAPI> apis;

        /// <summary>
        /// 在静态构造函数中，通过反射，获取目前所有继承了IBrowser和IBrowserAPI接口的类型
        /// </summary>
        static FactorySelectBrowserAPI()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            browsers = new List<IBrowser>();
            List<Type> types = new List<Type>();
            types.AddRange(assembly.GetTypes().Where(t => typeof(IBrowser).IsAssignableFrom(t) && t.IsClass));
            browsers.AddRange(types.Select(pt => Activator.CreateInstance(pt) as IBrowser));

            apis = new List<IBrowserAPI>();
            types = new List<Type>();
            types.AddRange(assembly.GetTypes().Where(t => typeof(IBrowserAPI).IsAssignableFrom(t) && t.IsClass));
            apis.AddRange(types.Select(pt => Activator.CreateInstance(pt) as IBrowserAPI));
        }

        public Tuple<IBrowser, List<IBrowserAPI>> SelectBrowserAPI(string rawUserAgent)
        {
            if (string.IsNullOrEmpty(rawUserAgent)) return null;

            //根据传过来的UA，确定用户是哪个浏览器 
            IBrowser userBrowser = browsers.Find(b => b.UserAgentRegex.IsMatch(rawUserAgent));

            if (userBrowser == null)
            {
                return null;
            }

            List<IBrowserAPI> enableApis =
                apis.FindAll(a => a.IsThisBrowserEnableThisBrowserAPI(userBrowser));
            if (enableApis == null || enableApis.Count == 0) return null;

            return Tuple.Create(userBrowser, enableApis);
        }

        /// <summary>
        /// 从客户端回传的错误代码，得到api名字，以便记录log
        /// </summary>
        public string GetApiNameFromErrorCode(string errorCode)
        {
            var api = apis.Find(a => a.errorCode == errorCode);
            if (api == null) return "";
            return api.GetType().Name;
        }
    }
}
