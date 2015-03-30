using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 减法
    /// </summary>
    class Subtraction : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("减法部件参数异常！");

            return Expression.SubtractChecked(parameter[0], parameter[1]);
        }

        public int Number
        {
            get { return 2; }
        }
    }
}
