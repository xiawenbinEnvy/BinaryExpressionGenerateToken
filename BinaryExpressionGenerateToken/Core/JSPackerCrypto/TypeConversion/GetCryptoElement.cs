using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    /// <summary>
    /// 获取加密后的字母、空格和数字
    /// </summary>
    class GetCryptoElement
    {
        public static string Get(IEnumerable<string> raws, IEnumerable<string> positions, Random ran)
        {
            if (raws == null || raws.Count() == 0) throw new Exception("获取加密后的字母、空格和数字异常");
            if (positions == null || positions.Count() == 0) throw new Exception("获取加密后的字母、空格和数字异常");

            //提取字母——>加括号——>加''——>加括号——>选取下标——>将下标扩进中括号——>和字母连接
            StringBuilder sb = new StringBuilder();
            sb.Append("(").Append("(").
               Append(raws.ElementAt(ran.Next(0, raws.Count()))).
               Append("+''").Append(")");
            sb.Append("[").Append(positions.ElementAt(ran.Next(0, positions.Count()))).Append("]").Append(")");

            return sb.ToString();
        }
    }
}
