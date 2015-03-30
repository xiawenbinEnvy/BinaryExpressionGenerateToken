
namespace Core
{
    /// <summary>
    /// 迷惑函数转换为将发送到客户端的形式 接口
    /// </summary>
    public interface ITransfer<T>
    {
        /// <summary>
        /// 迷惑函数转换为将发送到客户端的形式
        /// </summary>
        string Translate(T t, object[] parameterValue);
    }
}
