using System.Text.RegularExpressions;

namespace Core
{
    class IE6 : IBrowser
    {
        //Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)
        private static Regex regex = new Regex("msie ([6.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
