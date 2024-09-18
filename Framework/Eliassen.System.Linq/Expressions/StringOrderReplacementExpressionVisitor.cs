using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions;

public enum StringCasing
{
    Sensitive = 0,
    Upper = 1,
    Lower = 2,
}

public class StringOrderReplacementExpressionVisitor(
    ILogger<StringOrderReplacementExpressionVisitor>? logger = null,
    StringCasing stringCasing = StringCasing.Upper
        ) : ExpressionVisitor, IPostBuildExpressionVisitor
{
    private readonly ILogger _logger = logger ?? new ConsoleLogger<StringOrderReplacementExpressionVisitor>();

}
