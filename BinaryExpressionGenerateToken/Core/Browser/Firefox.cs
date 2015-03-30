using System.Text.RegularExpressions;

namespace Core
{
    class Firefox : IBrowser
    {
        //	Mozilla/5.0 (Windows NT 6.1; WOW64; rv:36.0) Gecko/20100101 Firefox/36.0
        private static Regex regex = new Regex(@"firefox\/([\d.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
