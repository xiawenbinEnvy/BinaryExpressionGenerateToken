using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    /// <summary>
    /// 随机创建二元运算符的表达式树 测试类
    /// </summary>
    [TestClass]
    public class BinaryExpressionRandomTest
    {
        /// <summary>
        /// 测试类，override和随机性相关的部分，以便测试
        /// </summary>
        class BinaryExpressionRandomForTest : BinaryExpressionRandom
        {
            internal override int GetTreeLayerCount(Random random)
            {
                return 5;
            }
            internal override int GetExpressionPartNumber(Random random)
            {
                return 1;
            }
        }

        /// <summary>
        /// 验证以程序生成的表达式树，是否和手工创建的相同
        /// </summary>
        [TestMethod]
        public void Test_ProgramCreateEqualsHandCreate()
        {
            BinaryExpressionRandomForTest testedClass = new BinaryExpressionRandomForTest();
            var programResult = testedClass.Create().Item1;

            //===========以手工方式创建表达式树，5层二元运算=========================
            //-------left-----------------------------------------------------
            Expression parametera1 = Expression.Parameter(typeof(int), "a1");
            Expression parametera2 = Expression.Parameter(typeof(int), "a2");
            Expression add1 = Expression.Add(parametera1, parametera2);

            Expression parameterb1 = Expression.Parameter(typeof(int), "b1");
            Expression parameterb2 = Expression.Parameter(typeof(int), "b2");
            Expression add2 = Expression.Add(parameterb1, parameterb2);

            Expression parameterc1 = Expression.Parameter(typeof(int), "c1");
            Expression parameterc2 = Expression.Parameter(typeof(int), "c2");
            Expression add3 = Expression.Add(parameterc1, parameterc2);

            Expression parameterd1 = Expression.Parameter(typeof(int), "d1");
            Expression parameterd2 = Expression.Parameter(typeof(int), "d2");
            Expression add4 = Expression.Add(parameterd1, parameterd2);

            Expression parametere1 = Expression.Parameter(typeof(int), "e1");
            Expression parametere2 = Expression.Parameter(typeof(int), "e2");
            Expression add5 = Expression.Add(parametere1, parametere2);

            Expression parameterf1 = Expression.Parameter(typeof(int), "f1");
            Expression parameterf2 = Expression.Parameter(typeof(int), "f2");
            Expression add6 = Expression.Add(parameterf1, parameterf2);

            Expression parameterg1 = Expression.Parameter(typeof(int), "g1");
            Expression parameterg2 = Expression.Parameter(typeof(int), "g2");
            Expression add7 = Expression.Add(parameterg1, parameterg2);

            Expression parameterh1 = Expression.Parameter(typeof(int), "h1");
            Expression parameterh2 = Expression.Parameter(typeof(int), "h2");
            Expression add8 = Expression.Add(parameterh1, parameterh2);

            Expression add9 = Expression.Add(add1, add2);
            Expression add10 = Expression.Add(add3, add4);
            Expression add11 = Expression.Add(add5, add6);
            Expression add12 = Expression.Add(add7, add8);

            Expression add13 = Expression.Add(add9, add10);
            Expression add14 = Expression.Add(add11, add12);

            Expression add15 = Expression.Add(add13, add14);
            //------------right------------------------------------------------
            Expression parameteri1 = Expression.Parameter(typeof(int), "i1");
            Expression parameteri2 = Expression.Parameter(typeof(int), "i2");
            Expression add16 = Expression.Add(parameteri1, parameteri2);

            Expression parameterj1 = Expression.Parameter(typeof(int), "j1");
            Expression parameterj2 = Expression.Parameter(typeof(int), "j2");
            Expression add17 = Expression.Add(parameterj1, parameterj2);

            Expression parameterk1 = Expression.Parameter(typeof(int), "k1");
            Expression parameterk2 = Expression.Parameter(typeof(int), "k2");
            Expression add18 = Expression.Add(parameterk1, parameterk2);

            Expression parameterl1 = Expression.Parameter(typeof(int), "l1");
            Expression parameterl2 = Expression.Parameter(typeof(int), "l2");
            Expression add19 = Expression.Add(parameterl1, parameterl2);

            Expression parameterm1 = Expression.Parameter(typeof(int), "m1");
            Expression parameterm2 = Expression.Parameter(typeof(int), "m2");
            Expression add20 = Expression.Add(parameterm1, parameterm2);

            Expression parametern1 = Expression.Parameter(typeof(int), "n1");
            Expression parametern2 = Expression.Parameter(typeof(int), "n2");
            Expression add21 = Expression.Add(parametern1, parametern2);

            Expression parametero1 = Expression.Parameter(typeof(int), "o1");
            Expression parametero2 = Expression.Parameter(typeof(int), "o2");
            Expression add22 = Expression.Add(parametero1, parametero2);

            Expression parameterp1 = Expression.Parameter(typeof(int), "p1");
            Expression parameterp2 = Expression.Parameter(typeof(int), "p2");
            Expression add23 = Expression.Add(parameterp1, parameterp2);

            Expression add24 = Expression.Add(add16, add17);
            Expression add25 = Expression.Add(add18, add19);
            Expression add26 = Expression.Add(add20, add21);
            Expression add27 = Expression.Add(add22, add23);

            Expression add28 = Expression.Add(add24, add25);
            Expression add29 = Expression.Add(add26, add27);

            Expression add30 = Expression.Add(add28, add29);

            var handResult = Expression.Add(add15, add30);
            //====================================================================

            Assert.AreEqual(programResult.ToString(), handResult.ToString());
        }
    }
}
