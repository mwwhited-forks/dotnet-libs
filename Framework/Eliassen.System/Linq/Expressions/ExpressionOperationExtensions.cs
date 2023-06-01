using System;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    public static class ExpressionOperationExtensions
    {

        public static BinaryExpression BuildBinaryExpression(this ExpressionOperators expressionOperator, object left, object right) =>
            expressionOperator.BuildBinaryExpression(Expression.Constant(left), right);
        public static BinaryExpression BuildBinaryExpression(this ExpressionOperators expressionOperator, Expression left, object right) =>
            expressionOperator.BuildBinaryExpression(left, Expression.Constant(right));
        public static BinaryExpression BuildBinaryExpression(this ExpressionOperators expressionOperator, object left, Expression right) =>
            expressionOperator.BuildBinaryExpression(Expression.Constant(left), right);
        public static BinaryExpression BuildBinaryExpression(this ExpressionOperators expressionOperator, Expression left, Expression right) =>
            expressionOperator switch
            {
                ExpressionOperators.EqualTo => Expression.Equal(left, right),
                ExpressionOperators.NotEqualTo => Expression.NotEqual(left, right),

                ExpressionOperators.LessThan => Expression.LessThan(left, right),
                ExpressionOperators.LessThanOrEqualTo => Expression.LessThanOrEqual(left, right),
                ExpressionOperators.GreaterThan => Expression.GreaterThan(left, right),
                ExpressionOperators.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(left, right),

                _ => throw new NotSupportedException($"{expressionOperator} is not supported"),
            };
    }
}
