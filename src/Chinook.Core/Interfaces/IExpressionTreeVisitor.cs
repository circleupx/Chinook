namespace Chinook.Core
{
    public interface IAbstractSyntaxTreeVisitor
    {
        void Visit(ValueNode node);
        void Visit(FieldNode node);
        void Visit(OperatorNode node);
    }
}