
namespace Core
{
    /// <summary>
    /// 浏览器api接口
    /// </summary>
    public interface IBrowserAPI
    {
        /// <summary>
        /// JS代码
        /// </summary>
        /// <returns></returns>
        string GetAPIJSCode();

        /// <summary>
        /// 浏览器是否可用
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        bool IsThisBrowserEnableThisBrowserAPI(IBrowser browser);

        /// <summary>
        /// 错误代码
        /// </summary>
        string errorCode { get; }
    }
}
