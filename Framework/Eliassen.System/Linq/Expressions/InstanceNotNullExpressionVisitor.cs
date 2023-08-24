using Eliassen.System.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions;

public class InstanceNotNullExpressionVisitor : ExpressionVisitor, IPostBuildExpressionVisitor
{
    //private readonly ILogger _logger;

    ///// <inheritdoc/>
    //public InstanceNotNullExpressionVisitor(
    //    ILogger<InstanceNotNullExpressionVisitor>? logger = null
    //    )
    //{
    //    _logger = logger ?? new ConsoleLogger<InstanceNotNullExpressionVisitor>();
    //}

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node.Object == null)
            goto done;

        var declaringType = node.Method?.DeclaringType;
        if (declaringType != typeof(string))
            goto done;

        //if (!(node.Method?.IsSpecialName ?? false) || node.Method?.Name != "op_Equality")
        //    goto done;

        //var typeArgs = new[]
        //{
        //    typeof(string),
        //    typeof(StringComparison),
        //};

        //var method = declaringType.GetMethod(nameof(String.Equals), typeArgs);
        //if (method == null)
        //    goto done;

        var replacement =
            Expression.AndAlso(
                Expression.NotEqual(node.Object, Expression.Constant(null, node.Object.Type)),
                node
                );

        return replacement;

    done:
        return base.VisitMethodCall(node);
    }

}
