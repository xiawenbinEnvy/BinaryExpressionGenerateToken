using System;
using System.Text;

namespace Core
{
    /// <summary>
    /// 获取数字混淆
    /// </summary>
    class Number
    {
        public string Get(int number, Random ran)
        {
            if (number < 0 || number > 9) throw new Exception("请使用0-9的基本字符");

            var numbers = RawMetadata.metadataNumber.GetValues(number.ToString());
            var s = numbers[ran.Next(0, numbers.Length)];

            return new StringBuilder().Append("(").Append(s).Append("+'')").ToString();
        }
    }
}
