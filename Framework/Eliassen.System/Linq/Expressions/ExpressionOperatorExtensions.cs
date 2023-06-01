using Eliassen.System.Linq.Search;
using System;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    public static class ExpressionOperatorExtensions
    {

        public static BinaryExpression BuildBinaryExpression(this Operators expressionOperator, object left, object right) =>
            expressionOperator.BuildBinaryExpression(Expression.Constant(left), right);
        public static BinaryExpression BuildBinaryExpression(this Operators expressionOperator, Expression left, object right) =>
            expressionOperator.BuildBinaryExpression(left, Expression.Constant(right));
        public static BinaryExpression BuildBinaryExpression(this Operators expressionOperator, object left, Expression right) =>
            expressionOperator.BuildBinaryExpression(Expression.Constant(left), right);
        public static BinaryExpression BuildBinaryExpression(this Operators expressionOperator, Expression left, Expression right) =>
            expressionOperator switch
            {
                Operators.EqualTo => Expression.Equal(left, right),
                Operators.NotEqualTo => Expression.NotEqual(left, right),

                Operators.LessThan => Expression.LessThan(left, right),
                Operators.LessThanOrEqualTo => Expression.LessThanOrEqual(left, right),
                Operators.GreaterThan => Expression.GreaterThan(left, right),
                Operators.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(left, right),

                _ => throw new NotSupportedException($"{expressionOperator} is not supported"),
            };
    }
}
