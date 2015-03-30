using System.Text.RegularExpressions;

namespace Core
{
    class IE10 : IBrowser
    {
        //Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)
        private static Regex regex = new Regex("msie ([10.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
