using System;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 按位与
    /// </summary>
    class And : IExpressionPart
    {
        public Expression Process(params Expression[] parameter)
        {
            if (parameter == null || parameter.Length < 2) throw new ArgumentException("按位与部件参数异常！");
            return Expression.And(parameter[0], parameter[1]);
        }
        public int Number
        {
            get { return 4; }
        }
    }
}
