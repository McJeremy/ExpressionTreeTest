using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    public class BaseExpression
    {
        /// <summary>
        /// 基本的表达式树
        /// </summary>
        public static void Test()
        {

            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            BinaryExpression left = Expression.Multiply(a, b);
            ConstantExpression right = Expression.Constant(2, typeof(int));

            BinaryExpression body = Expression.Add(left, right);

            LambdaExpression lambda = Expression.Lambda<Func<int, int, int>>(body, a, b);
            Console.WriteLine(lambda.ToString());
            Func<int, int, int> ttt = lambda.Compile() as Func<int, int, int>;
            Console.WriteLine(lambda.Compile().DynamicInvoke(3, 4));
            Console.WriteLine(ttt(3, 4));

            Expression<Func<int, int, int>> newlambda = Expression.Lambda<Func<int, int, int>>(body, a, b);
            Console.WriteLine(newlambda.ToString());
            Console.WriteLine(newlambda.Compile()(3, 4));

            Func<int, int, int> mylambda = newlambda.Compile();

            Expression<Func<int, int, int>> l2 = (x, y) => x + y + 3 + 4;
            Console.WriteLine(l2.ToString());

            Func<int, int> z1 = z => z + 3; //这是一个表达式，不是表达式树。
        }
    }
}
