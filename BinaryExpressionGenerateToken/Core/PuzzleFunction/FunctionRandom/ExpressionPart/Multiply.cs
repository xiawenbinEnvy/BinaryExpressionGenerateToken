using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 乘法
    /// </summary>
    class Multiply : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("乘法部件参数异常！");
            return Expression.MultiplyChecked(parameter[0], parameter[1]);
        }
        public int Number
        {
            get { return 3; }
        }
    }
}
