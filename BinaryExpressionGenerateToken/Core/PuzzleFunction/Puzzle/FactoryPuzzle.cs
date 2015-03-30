using System;

namespace Core
{
    /// <summary>
    /// 迷惑函数工厂
    /// </summary>
    public class FactoryPuzzle
    {
        /// <summary>
        /// 构造一次迷惑函数
        /// </summary>
        public static IPuzzle CreatePuzzle(string useragent)
        {
            while (true)
            {
                try
                {
                    DateTime now = DateTime.Now;

                    BinaryExpressionRandom token1 = new BinaryExpressionRandom();
                    var expression = token1.Create();
                    IPuzzle puzzle = new BinaryPuzzle(now, expression.Item1, expression.Item2, useragent);
                    if (puzzle.GetResult() == "0") continue;

                    return puzzle;
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
