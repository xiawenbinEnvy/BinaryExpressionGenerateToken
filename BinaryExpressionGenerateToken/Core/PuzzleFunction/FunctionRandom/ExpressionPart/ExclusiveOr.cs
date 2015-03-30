using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 按位异或
    /// </summary>
    class ExclusiveOr : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("按位异或部件参数异常！");
            return Expression.ExclusiveOr(parameter[0], parameter[1]);
        }
        public int Number
        {
            get { return 6; }
        }
    }
}
