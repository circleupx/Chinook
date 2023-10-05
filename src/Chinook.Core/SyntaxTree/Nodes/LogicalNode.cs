using System.Linq.Expressions;
using Superpower;

namespace Chinook.Core
{
    public class OperatorNode : IAbstractSyntaxTreeNode
    {
        public ExpressionType Value { get; }

        public OperatorNode(string value)
        {
            var parser = ODataParser.ODataLogicalAnd
            .Or(ODataParser.ODataLogicalAnd)
            .Or(ODataParser.ODataEqualOperator)
            .Or(ODataParser.ODataNotEqualOperator)
            .Or(ODataParser.ODataGreaterThanOperator)
            .Or(ODataParser.ODataGreaterThanOrEqualOperator)
            .Or(ODataParser.ODataLessThanOperator)
            .Or(ODataParser.ODataLessThanOrEqualOperator);

            Value = parser.Parse(value);
        }

        public void Accept(IAbstractSyntaxTreeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}