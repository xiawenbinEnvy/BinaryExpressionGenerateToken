using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 加法
    /// </summary>
    class Addition : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("加法部件参数异常！");
            return Expression.AddChecked(parameter[0], parameter[1]);
        }

        public int Number
        {
            get { return 1; }
        }
    }
}
