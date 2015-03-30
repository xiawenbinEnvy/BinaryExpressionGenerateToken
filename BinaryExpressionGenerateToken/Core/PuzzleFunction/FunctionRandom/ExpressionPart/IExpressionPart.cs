using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 运算部件接口
    /// </summary>
    interface IExpressionPart
    {
        /// <summary>
        /// 部件编号
        /// </summary>
        int Number { get; }
        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="parameter">参数表达式</param>
        /// <returns>表达式树</returns>
        Expression Process(params Expression[] parameter);
    }
}
