using System.Text.RegularExpressions;

namespace Core
{
    class Chrome : IBrowser
    {
        //Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36
        private static Regex regex = new Regex(@"chrome\/([\d.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
