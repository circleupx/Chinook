using Superpower;

namespace Chinook.Core
{
    public class ValueNode : IAbstractSyntaxTreeNode
    {
        public string Value { get; }

        public ValueNode(string value)
        {
            // Given a node can be of string, bool, int and so on.
            // This could should have the parsers for booleans and integers, I purposely left them out for brevity.

            var parser = ODataParser.ODataString;
            Value = parser.Parse(value);
        }

        public void Accept(IAbstractSyntaxTreeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}