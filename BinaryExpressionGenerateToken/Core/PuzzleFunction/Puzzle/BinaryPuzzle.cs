using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// 二元运算迷惑函数实体
    /// </summary>
    public class BinaryPuzzle : IPuzzle
    {
        #region 浏览器api相关
        /// <summary>
        /// user agent
        /// </summary>
        public string RawUserAgent { get; private set; }
        public IBrowser browser { get; private set; }
        #endregion

        /// <summary>
        /// C#表达式树
        /// </summary>
        private Expression expression;
        /// <summary>
        /// 表达式树编译出的委托
        /// </summary>
        private Delegate lambda;
        /// <summary>
        /// 运算参数
        /// </summary>
        private object[] parameterValue;

        /// <summary>
        /// 获取随机数
        /// 为单元测试而作，常规代码请勿override
        /// </summary>
        internal virtual int GetRandomNumber(Random random)
        {
            return random.Next(1, 30);
        }

        public override string GetResult()
        {
            lastUseTime = DateTime.Now;
            return Convert.ToString(this.lambda.DynamicInvoke(parameterValue));        
        }

        public BinaryPuzzle(DateTime createTime, Expression expression, List<ParameterExpression> parameterName, string useragent, bool enableBrowserApi = true)
            : base(createTime)
        {
            int count = parameterName.Count;
            Random ran = new Random();
            parameterValue = new object[count];
            for (int i = 0; i < count; i++)//随机创建表达式执行参数
                parameterValue[i] = GetRandomNumber(ran);

            this.expression = expression;
            this.lambda = Expression.Lambda(expression, parameterName).Compile();

            this.RawUserAgent = useragent;
            var tuple = new FactorySelectBrowserAPI().SelectBrowserAPI(RawUserAgent);
            this.browser = tuple.Item1;
            var apis = tuple.Item2;
            this.StringSendToFrantEnd = new BinaryExpressionToJSTransfer(apis, enableBrowserApi).
                Translate(expression, parameterValue);

            //进行混淆加密
            this.StringSendToFrantEnd = FactoryJSPackerCrypto.Process(StringSendToFrantEnd);
        }

        /// <summary>
        /// 为单元测试而做，常规代码请勿调用
        /// </summary>
        public BinaryPuzzle() : base() { }
    }
}
