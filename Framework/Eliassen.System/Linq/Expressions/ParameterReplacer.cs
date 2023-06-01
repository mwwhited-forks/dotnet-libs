using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;

        internal ParameterReplacer(ParameterExpression parameter) =>
            _parameter = parameter;

        protected override Expression VisitParameter(ParameterExpression node) => _parameter;
    }
}
