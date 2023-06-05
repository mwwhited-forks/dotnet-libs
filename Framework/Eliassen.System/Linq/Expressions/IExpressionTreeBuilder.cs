using Eliassen.System.Linq.Search;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eliassen.System.Linq.Expressions
{
    public interface IExpressionTreeBuilder
    {
        public abstract IReadOnlyCollection<string> GetSearchablePropertyNames();
        public abstract IReadOnlyCollection<string> GetSortablePropertyNames();
        public abstract IReadOnlyCollection<string> GetFilterablePropertyNames();
        public abstract IReadOnlyCollection<(string column, OrderDirections direction)> DefaultSortOrder();
    }

    public interface IExpressionTreeBuilder<TModel> : IExpressionTreeBuilder
    {
        Expression<Func<TModel, bool>>? GetPredicateExpression(string name, FilterParameter value, StringComparison stringComparison);
        Expression<Func<TModel, bool>>? BuildExpression(object? queryParameter, StringComparison stringComparison);
        IReadOnlyDictionary<string, Expression<Func<TModel, object>>> PropertyExpressions();
    }
}
