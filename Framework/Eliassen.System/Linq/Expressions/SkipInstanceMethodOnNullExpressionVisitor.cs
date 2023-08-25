using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions;

/// <summary>
/// This visitor will modify expressions to add `x.Property != null` before instance method calls for query rewrite
/// </summary>
public class SkipInstanceMethodOnNullExpressionVisitor : ExpressionVisitor, IPostBuildExpressionVisitor
{
    /// <summary>
    /// If expression is an instance method then modify the expression to ensure a 
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Object == null || node.Method.IsStatic)
            return base.VisitMethodCall(node);

        return Expression.AndAlso(
            Expression.NotEqual(node.Object, Expression.Constant(null, node.Object.Type)),
            node
            );
    }
}
