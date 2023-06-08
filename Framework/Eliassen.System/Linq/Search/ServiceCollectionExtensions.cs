using Eliassen.System.Linq.Expressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.System.Linq.Search
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection TryAddSearchQueryExtensions(this IServiceCollection services)
        {
            services.TryAddSingleton(typeof(IQueryBuilder<>), typeof(QueryBuilder<>));
            services.TryAddSingleton(typeof(ISortBuilder<>), typeof(SortBuilder<>));
            services.TryAddSingleton(typeof(IExpressionTreeBuilder<>), typeof(ExpressionTreeBuilder<>));
            services.TryAddTransient<IPostBuildExpressionVisitor, StringComparisonReplacementExpressionVisitor>();
            return services;
        }
    }
}
