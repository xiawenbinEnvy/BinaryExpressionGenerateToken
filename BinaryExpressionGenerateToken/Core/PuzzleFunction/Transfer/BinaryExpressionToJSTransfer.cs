using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core
{
    /// <summary>
    /// C#表达式树转译成javascript代码
    /// </summary>
    class BinaryExpressionToJSTransfer : ExpressionVisitor, ITransfer<Expression>
    {
        #region 浏览器api相关
        /// <summary>
        /// 是否在二元运算符之间插入浏览器api。
        /// 为单元测试而做，因为单元测试使用的js引擎要模拟浏览器api需要做一番工作，
        /// 所以在单元测试中关闭‘插入浏览器api’
        /// </summary>
        private bool enableInsertBrowserAPI = true;
        internal bool EnableInsertBrowserAPI
        {
            get
            {
                return enableInsertBrowserAPI;
            }
            set
            {
                enableInsertBrowserAPI = value;
            }
        }
        private Random ran = null;
        private IEnumerable<IBrowserAPI> apis = null;
        #endregion

        /// <summary>
        /// 方法编号，以防重名
        /// </summary>
        private int current = 0;
        /// <summary>
        /// 表达式树的二元运算符节点的个数
        /// </summary>
        private int layerCount = 0;

        /// <summary>
        /// 方法名栈
        /// </summary>
        private Stack<string> functionNames = new Stack<string>();
        /// <summary>
        /// javascript结果字符串
        /// </summary>
        private StringBuilder sb = new StringBuilder();

        /// <summary>
        /// 字符串模板
        /// </summary>
        private string format = "var {0}=function()[return _p({1});];";
        private string format2 = "var {0}=function()[return _p({1}(){2}{3}());];";
        private string format3 = "{0}{1}";
        private string format4 = "var _p=parseInt;var g=function({0})[{1}];var getuseridentityresult=g({2});";

        /// <summary>
        /// 参数名队列
        /// </summary>
        private Queue<string> parameterNames = new Queue<string>();

        public BinaryExpressionToJSTransfer(IEnumerable<IBrowserAPI> apis, bool enableBrowserApi)
        {
            this.apis = apis;
            this.enableInsertBrowserAPI = enableBrowserApi;
        }

        /// <summary>
        /// C#表达式树转译成javascript
        /// </summary>
        public string Translate(Expression expression, object[] parameterValue)
        {
            ran = new Random();

            GetExpressionLayerCount(expression);

            this.Visit(expression);
            string result = sb.ToString();
            return string.Format(format4, string.Join(",", parameterNames), result, string.Join(",", parameterValue)).Replace("[", "{").Replace("]", "}");
        }

        /// <summary>
        /// 获取表达式树的二元运算符的个数
        /// </summary>
        private void GetExpressionLayerCount(Expression expression)
        {
            BinaryExpression b = expression as BinaryExpression;
            if (b != null)
            {
                GetExpressionLayerCount(b.Left);
                GetExpressionLayerCount(b.Right);
                layerCount++;
            }
        }

        /// <summary>
        /// 获取二元操作符的javascript形式
        /// </summary>
        private string GetBinaryOperation(ExpressionType nodeType)
        {
            string opr = "";
            switch (nodeType)
            {
                case ExpressionType.AddChecked: opr = "+"; break;
                case ExpressionType.And: opr = "&"; break;
                case ExpressionType.ExclusiveOr: opr = "^"; break;
                case ExpressionType.MultiplyChecked: opr = "*"; break;
                case ExpressionType.Or: opr = "|"; break;
                case ExpressionType.SubtractChecked: opr = "-"; break;
                default: throw new Exception("未定义的操作符！");
            }
            return opr;
        }
        /// <summary>
        /// 获取二元操作符操作名
        /// </summary>
        private string GetBinaryFunctionName(ExpressionType nodeType)
        {
            string fun = "";
            switch (nodeType)
            {
                case ExpressionType.AddChecked: fun = "AC"; break;
                case ExpressionType.And: fun = "A"; break;
                case ExpressionType.ExclusiveOr: fun = "E"; break;
                case ExpressionType.MultiplyChecked: fun = "M"; break;
                case ExpressionType.Or: fun = "O"; break;
                case ExpressionType.SubtractChecked: fun = "S"; break;
                default: throw new Exception("未定义的操作符！");
            }
            return fun;
        }

        /// <summary>
        /// 处理二元运算符
        /// </summary>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) return node;

            this.Visit(node.Left);
            this.Visit(node.Right);

            current++;

            string functionName;
            string result;
            if (typeof(ParameterExpression).IsAssignableFrom(node.Left.GetType()) &&
                typeof(ParameterExpression).IsAssignableFrom(node.Right.GetType()))//是叶子二元运算符了
            {
                functionName = string.Format(format3, GetBinaryFunctionName(node.NodeType), current);
                result = string.Format(format, functionName, node.ToString());
            }
            else//非叶子二元运算符
            {
                functionName = string.Format(format3, GetBinaryFunctionName(node.NodeType), current);
                string rightFunction = functionNames.Pop();
                string leftFunction = functionNames.Pop();
                string opr = GetBinaryOperation(node.NodeType);
                result = string.Format(format2, functionName, leftFunction, opr, rightFunction);
            }

            if(EnableInsertBrowserAPI)
            {
                bool canInsert = ran.Next(0, 2) == 0;
                if (canInsert)
                {
                    string browserApiJSCode = 
                        apis.ElementAt(ran.Next(0, apis.Count())).GetAPIJSCode();
                    result += browserApiJSCode;
                }
            }

            if (current == layerCount) //最后一个方法
                result += string.Format("return {0};", functionName);

            sb.Append(result);
            functionNames.Push(functionName);

            return node;
        }

        /// <summary>
        /// 处理参数
        /// </summary>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == null) return node;
            parameterNames.Enqueue(node.Name);
            return node;
        }
    }
}
