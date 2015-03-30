using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 按位或
    /// </summary>
    class Or : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("按位或部件参数异常！");
            return Expression.Or(parameter[0], parameter[1]);
        }
        public int Number
        {
            get { return 5; }
        }
    }
}
