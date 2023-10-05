namespace Chinook.Core
{
    public interface IAbstractSyntaxTreeNode
    {
        void Accept(IAbstractSyntaxTreeVisitor visitor);
    }
}