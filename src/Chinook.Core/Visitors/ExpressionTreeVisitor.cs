using System;
using System.Linq.Expressions;

namespace Chinook.Core
{
    public class ExpressionTreeVisitor<T> : IAbstractSyntaxTreeVisitor
    {
        private Expression<Func<T, bool>> FilterExpression;

        private ValueNode RightNode;
        private FieldNode LeftNode;
        private OperatorNode ParentNode;

        public Expression<Func<T, bool>> GetFilterExpression()
        {
            return FilterExpression;
        }

        public void Visit(ValueNode node)
        {
            RightNode = node;
            var expression = ExpressionFactory.CreateExpression<T>(LeftNode, ParentNode, RightNode);
            FilterExpression = expression;
        }

        public void Visit(OperatorNode node)
        {
            ParentNode = node;
        }

        public void Visit(FieldNode node)
        {
            LeftNode = node;
        }
    }
}