using System;
using Jurassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.JSPackerCrypto
{
    /// <summary>
    /// js加密混淆的综合测试
    /// 测试方法：
    /// 在循环内不停构造token生成函数，转成js，加密混淆，用js引擎运行，将结果和c#委托结果进行比较
    /// </summary>
    [TestClass]
    public class JSPackerCryptoTest
    {
        /// <summary>
        /// 场景：二元运算js，进行混淆加密
        /// 预期：js运算结果应该和c#运算结果相同
        /// </summary>
        [TestMethod]
        public void JSPackerCrypto_PackerCrypto_JSResultEqualCSharpResult()
        {
            var engine = new ScriptEngine();
            IPuzzle puzzle = null;
            BinaryExpressionRandom token = null;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    token = new BinaryExpressionRandom();
                    var expression = token.Create();
                    puzzle = new BinaryPuzzle(
                        DateTime.Now,
                        expression.Item1,
                        expression.Item2,
                        "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36",
                        false);
                    if (puzzle.GetResult() == "0")
                    {
                        i--;
                        continue;
                    }
                }
                catch
                {
                    i--;
                    continue;
                }
                var csharpResult = puzzle.GetResult();
                var jsResult = engine.Evaluate(puzzle.StringSendToFrantEnd.Replace("<script>", "").Replace("</script>", "") + "getuseridentityresult();").ToString();
                Assert.AreEqual(csharpResult, jsResult);
            }
        }
    }
}
