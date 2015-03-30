using System.Text.RegularExpressions;

namespace Core
{
    class IE11 : IBrowser
    {
        private static Regex regex = new Regex("rv:([11.]+).*like Gecko", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
