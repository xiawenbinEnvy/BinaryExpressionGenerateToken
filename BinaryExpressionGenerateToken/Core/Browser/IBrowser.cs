using System.Text.RegularExpressions;

namespace Core
{
    /// <summary>
    /// 浏览器属性 接口
    /// </summary>
    public interface IBrowser
    {
        /// <summary>
        /// UserAgent正则
        /// </summary>
        Regex UserAgentRegex { get; }
    }
}
