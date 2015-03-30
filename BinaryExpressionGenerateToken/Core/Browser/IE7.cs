using System.Text.RegularExpressions;

namespace Core
{
    class IE7 : IBrowser
    {
        //Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)
        private static Regex regex = new Regex("msie ([7.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
