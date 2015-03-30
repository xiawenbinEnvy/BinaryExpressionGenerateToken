using System.Text.RegularExpressions;

namespace Core
{
    class IE9 : IBrowser
    {
        //Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident/5.0; .NET CLR 2.0.50727; SLCC2; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.3; .NET4.0C; Tablet PC 2.0; .NET4.0E)
        private static Regex regex = new Regex("msie ([9.]+)", RegexOptions.IgnoreCase);

        public Regex UserAgentRegex
        {
            get { return regex; }
        }
    }
}
