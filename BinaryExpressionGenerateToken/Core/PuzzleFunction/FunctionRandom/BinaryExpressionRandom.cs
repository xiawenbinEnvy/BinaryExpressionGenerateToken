using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core
{
    /// <summary>
    /// 随机创建二元运算符的表达式树，一定是一颗满二叉树
    /// </summary>
    public class BinaryExpressionRandom : IFunctionRandom<Tuple<Expression, List<ParameterExpression>>>
    {
        /// <summary>
        /// 树的最大层数
        /// </summary>
        private int maxLayer = 5;

        private static List<IExpressionPart> parts;
        /// <summary>
        /// 在静态构造函数中，通过反射，获取目前所有继承了IExpressionPart接口的类型
        /// </summary>
        static BinaryExpressionRandom()
        {
            parts = new List<IExpressionPart>();
            List<Type> partsType = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            partsType.AddRange(assembly.GetTypes().Where(t => typeof(IExpressionPart).IsAssignableFrom(t) && t.IsClass));
            parts.AddRange(partsType.Select(pt => Activator.CreateInstance(pt) as IExpressionPart));
        }

        /// <summary>
        /// 确定树的层数
        /// 满二叉树的节点数：公式：（2的layer次方）-1；
        /// 为单元测试而作，常规代码请勿override
        /// </summary>
        /// <returns></returns>
        internal virtual int GetTreeLayerCount(Random random)
        {
            return random.Next(2, maxLayer + 1);//先确定层数，在2-5范围内
        }

        /// <summary>
        /// 确定部件编号
        /// 为单元测试而作，常规代码请勿override
        /// </summary>
        internal virtual int GetExpressionPartNumber(Random random)
        {
            return random.Next(1, parts.Count + 1); 
        }

        /// <summary>
        /// 随机创建表达式树
        /// </summary>
        public Tuple<Expression, List<ParameterExpression>> Create()
        {
            //参数名
            Queue<string> parameterName =
                new Queue<string>(new string[] 
                { "a1","a2", 
                    "b1","b2", 
                    "c1","c2", 
                    "d1","d2", 
                    "e1", "e2",
                    "f1","f2", 
                    "g1", "g2",
                    "h1","h2",
                    "i1", "i2",
                    "j1", "j2",
                    "k1", "k2",
                    "l1", "l2",
                    "m1","m2", 
                    "n1", "n2",
                    "o1", "o2",
                    "p1","p2"
                });

            Random random = new Random();
            int layer = GetTreeLayerCount(random);

            //每层使用的队列
            Queue<Expression>[] queue = new Queue<Expression>[layer];
            for (int i = 0; i < layer; i++) queue[i] = new Queue<Expression>();

            List<ParameterExpression> parameterList = new List<ParameterExpression>();

            for (int l = layer; l >= 1; l--)//自低向上每一层
            {
                int layerCount = (int)Math.Pow(2, l - 1);//本层的节点数
                for (int i = 0; i < layerCount; i++)//每个节点
                {
                    int number = GetExpressionPartNumber(random);
                    IExpressionPart part = parts.Where(t => t.Number == number).FirstOrDefault();//随机生成一个部件

                    Expression[] parameter;
                    Expression expression;
                    if (layer == l)//最底下一层，直接操作常量的二元运算符
                    {
                        string s = parameterName.Dequeue();
                        var p1 = Expression.Parameter(typeof(int), s);
                        parameterList.Add(p1);
                        s = parameterName.Dequeue();
                        var p2 = Expression.Parameter(typeof(int), s);
                        parameterList.Add(p2);

                        parameter = new Expression[] { p1, p2 };
                        expression = (Activator.CreateInstance(part.GetType()) as IExpressionPart).Process(parameter);
                    }
                    else//操作下面一层的二元运算符的结果的表达式
                    {
                        parameter = new Expression[] { queue[layer - l - 1].Dequeue(), queue[layer - l - 1].Dequeue() };//从下一层取出两个表达式
                        expression = (Activator.CreateInstance(part.GetType()) as IExpressionPart).Process(parameter);
                    }
                    queue[layer - l].Enqueue(expression);
                }
            }

            return Tuple.Create(queue[layer - 1].Dequeue(), parameterList);
        }
    }
}
