using System.Text.RegularExpressions;

namespace Core
{
    class Opera : IBrowser
    {
        //Opera/9.80 (Windows NT 6.1; U; zh-cn) Presto/2.9.168 Version/11.50
        private static Regex regex = new Regex(@"opera.([\d.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
