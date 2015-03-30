using System.Text.RegularExpressions;

namespace Core
{
    class Safari : IBrowser
    {
        //Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50
        private static Regex regex = new Regex(@"^(?!.*?chrome).*safari\/([\d.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
