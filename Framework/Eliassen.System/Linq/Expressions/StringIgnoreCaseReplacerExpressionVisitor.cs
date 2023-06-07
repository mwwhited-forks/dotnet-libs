using Eliassen.System.ComponentModel.Search;
using Eliassen.System.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    /// <summary>
    /// Expression visitor to replace string functions with the matching 
    /// functions that end with a StringComparison parameter
    /// </summary>
    public class StringIgnoreCaseReplacerExpressionVisitor : ExpressionVisitor, IPostBuildExpressionVisitor
    {
        private readonly StringComparison _stringComparison;
        private readonly ILogger _logger;

        /// <inheritdoc/>
        public StringIgnoreCaseReplacerExpressionVisitor(
            ILogger<StringIgnoreCaseReplacerExpressionVisitor>? logger = null,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase
            )
        {
            _logger = logger ?? new ConsoleLogger<StringIgnoreCaseReplacerExpressionVisitor>();
            _stringComparison = stringComparison;
        }

        /// <inheritdoc/>
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

            if (input.Object?.GetAttributes().OfType<ExcludeCaseReplacerAttribute>().Any() ?? false) goto finish;

            var args = input.Arguments.Concat(new[] { Expression.Constant(_stringComparison) });
            var replacement = Expression.Call(input.Object, method, args);

            _logger.LogDebug($"Replace: {{{nameof(input)}}} with {{{nameof(replacement)}}}", input, replacement);

            return replacement;

        done:
            return base.VisitMethodCall(input);
        }
    }
}
