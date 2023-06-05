using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;
using System;

namespace Eliassen.System.Linq
{
    public static class OperatorExtensions
    {
        public static FilterParameter AsFilter(this Operators expressionOperator, object? value) =>
            new FilterParameter().And(expressionOperator, value);

        public static FilterParameter And(this FilterParameter filter, Operators expressionOperator, object? value) =>
            expressionOperator switch
            {
                Operators.EqualTo => filter with { EqualTo = value },
                Operators.NotEqualTo => filter with { NotEqualTo = value },

                Operators.LessThan => filter with { LessThan = value },
                Operators.LessThanOrEqualTo => filter with { LessThanOrEqualTo = value },
                Operators.GreaterThan => filter with { GreaterThan = value },
                Operators.GreaterThanOrEqualTo => filter with { GreaterThanOrEqualTo = value },

                Operators.InSet => filter with { InSet = (object[])typeof(object).MakeSafeArray((Array)value) },

                _ => throw new NotSupportedException($"{expressionOperator} is not supported"),
            };
    }
}
