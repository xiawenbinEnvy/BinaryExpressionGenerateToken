using System;
using System.Text;

namespace Core
{
    /// <summary>
    /// 将js代码加密
    /// </summary>
    class ElementCryptoFactory
    {
        public static string Crypto(string rawJS)
        {
            if (string.IsNullOrEmpty(rawJS)) return "";

            Random ran = new Random();
            StringBuilder sb = new StringBuilder();
            foreach (var c in rawJS)
            {
                switch (c.ToString())
                {
                    case "a": sb.Append(new Alpha_a().Get(ran)); break;
                    case "b": sb.Append(new Alpha_b().Get(ran)); break;
                    case "c": sb.Append(new Alpha_c().Get(ran)); break;
                    case "d": sb.Append(new Alpha_d().Get(ran)); break;
                    case "e": sb.Append(new Alpha_e().Get(ran)); break;
                    case "f": sb.Append(new Alpha_f().Get(ran)); break;
                    case "i": sb.Append(new Alpha_i().Get(ran)); break;
                    case "j": sb.Append(new Alpha_j().Get(ran)); break;
                    case "l": sb.Append(new Alpha_l().Get(ran)); break;
                    case "n": sb.Append(new Alpha_n().Get(ran)); break;
                    case "o": sb.Append(new Alpha_o().Get(ran)); break;
                    case "r": sb.Append(new Alpha_r().Get(ran)); break;
                    case "s": sb.Append(new Alpha_s().Get(ran)); break;
                    case "t": sb.Append(new Alpha_t().Get(ran)); break;
                    case "u": sb.Append(new Alpha_u().Get(ran)); break;
                    case " ": sb.Append(new Space().Get(ran)); break;
                    case "0": sb.Append(new Number().Get(0, ran)); break;
                    case "1": sb.Append(new Number().Get(1, ran)); break;
                    case "2": sb.Append(new Number().Get(2, ran)); break;
                    case "3": sb.Append(new Number().Get(3, ran)); break;
                    case "4": sb.Append(new Number().Get(4, ran)); break;
                    case "5": sb.Append(new Number().Get(5, ran)); break;
                    case "6": sb.Append(new Number().Get(6, ran)); break;
                    case "7": sb.Append(new Number().Get(7, ran)); break;
                    case "8": sb.Append(new Number().Get(8, ran)); break;
                    case "9": sb.Append(new Number().Get(9, ran)); break;
                    default: sb.Append("'").Append(c.ToString()).Append("'"); break;
                }
                sb.Append("+");
            }

            return sb.ToString().TrimEnd('+');
        }
    }
}
