using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    public interface IPostBuildExpressionVisitor
    {
        Expression? Visit(Expression? node);
    }
}
