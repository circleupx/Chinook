using System;

namespace Chinook.Core
{
    public class FieldNode : IAbstractSyntaxTreeNode
    {
        public Type ObjectType {get;}

        public string Value { get; }

        public FieldNode(string value, Type type)
        {
            Value = value;
            ObjectType = type;
        }

        public void Accept(IAbstractSyntaxTreeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}