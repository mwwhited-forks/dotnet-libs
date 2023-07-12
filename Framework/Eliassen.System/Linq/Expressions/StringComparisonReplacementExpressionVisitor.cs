using Eliassen.System.ComponentModel.Search;
using Eliassen.System.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions;

/// <summary>
/// Expression visitor to replace string functions with the matching 
/// functions that end with a StringComparison parameter
/// </summary>
public class StringComparisonReplacementExpressionVisitor : ExpressionVisitor, IPostBuildExpressionVisitor
{
    private readonly StringComparison _stringComparison;
    private readonly ILogger _logger;

    /// <inheritdoc/>
    public StringComparisonReplacementExpressionVisitor(
        ILogger<StringComparisonReplacementExpressionVisitor>? logger = null,
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
        )
    {
        _logger = logger ?? new ConsoleLogger<StringComparisonReplacementExpressionVisitor>();
        _stringComparison = stringComparison;
    }

    /// <summary>
    /// Replace `string == string` with `string.Equals(string, StringComparison)`
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitBinary(BinaryExpression node)
    {
        var declaringType = node.Method?.DeclaringType;
        if (declaringType != typeof(string))
            goto done;

        if (!(node.Method?.IsSpecialName ?? false) || node.Method?.Name != "op_Equality")
            goto done;

        var typeArgs = new[]
        {
            typeof(string),
            typeof(StringComparison),
        };

        var method = declaringType.GetMethod(nameof(String.Equals), typeArgs);
        if (method == null)
            goto done;

        var replacement = Expression.Call(node.Left, method, node.Right, Expression.Constant(_stringComparison));

        return replacement;

    done:
        return base.VisitBinary(node);
    }

    /// <summary>
    /// Replace `string.Xyz(string)` with `string.Xyz(string, StringComparison)`
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    protected override Expression VisitMethodCall(MethodCallExpression input)
    {
        var declaringType = input.Method.DeclaringType;
        if (declaringType != typeof(string))
            goto done;

        var parameters = input.Method.GetParameters();
        if (parameters.LastOrDefault()?.ParameterType == typeof(StringComparison))
            goto done;

        var typeArgs = new Type[parameters.Length + 1];
        for (var idx = 0; idx < parameters.Length; idx++)
            typeArgs[idx] = parameters[idx].ParameterType;
        typeArgs[parameters.Length] = typeof(StringComparison);

        var method = declaringType.GetMethod(input.Method.Name, typeArgs);
        if (method == null)
            goto done;

        if (input.Object?.GetAttributes().OfType<IgnoreStringComparisonReplacementAttribute>().Any() ?? false) goto done;

        var args = input.Arguments.Concat(new[] { Expression.Constant(_stringComparison) });
        var replacement = Expression.Call(input.Object, method, args);

        _logger.LogDebug($"Replace: {{{nameof(input)}}} with {{{nameof(replacement)}}}", input, replacement);

        return replacement;

    done:
        return base.VisitMethodCall(input);
    }
}
