using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    public class BaseExpressionVisitor:ExpressionVisitor
    {
        public Expression Modify(Expression exp)
        {
            return Visit(exp);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                var left = this.Visit(node.Left);
                var right = this.Visit(node.Right);                
                return Expression.Subtract(left, right);
            }
            return base.VisitBinary(node);
        }
    }

    public class BaseExpressionVisitorTest
    {
        public static void Test()
        {
            Expression<Func<int, int, int>> expression = (a, b) => a + b * 2;
            Expression newExp = new BaseExpressionVisitor().Modify(expression);

            Console.WriteLine("修改前：");
            Console.WriteLine(expression.ToString());
            Console.WriteLine("修改后：");
            Console.WriteLine(newExp.ToString());
        }
    }
}
