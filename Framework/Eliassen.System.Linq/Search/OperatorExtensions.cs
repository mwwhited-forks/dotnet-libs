using Eliassen.Extensions.Reflection;
using Eliassen.System.ResponseModel;
using System;

namespace Eliassen.System.Linq.Search;

internal static class OperatorExtensions
{
    public static FilterParameter AsFilter(
        this Operators expressionOperator,
        object? value,
#if DEBUG
        ICaptureResultMessage? messages
#else
        ICaptureResultMessage? messages = null
#endif
        ) =>
        new FilterParameter().And(expressionOperator, value, messages);

    public static FilterParameter And(
        this FilterParameter filter,
        Operators expressionOperator,
        object? value,
#if DEBUG
        ICaptureResultMessage? messages
#else
        ICaptureResultMessage? messages = null
#endif
        ) =>
        expressionOperator switch
        {
            Operators.EqualTo => filter with { EqualTo = value },
            Operators.NotEqualTo => filter with { NotEqualTo = value },

            Operators.LessThan => filter with { LessThan = value },
            Operators.LessThanOrEqualTo => filter with { LessThanOrEqualTo = value },
            Operators.GreaterThan => filter with { GreaterThan = value },
            Operators.GreaterThanOrEqualTo => filter with { GreaterThanOrEqualTo = value },

            Operators.InSet => filter with { InSet = (object[]?)typeof(object).MakeSafeArray((Array?)value, messages) },

            _ => throw new NotSupportedException($"{expressionOperator} is not supported"),
        };
}
