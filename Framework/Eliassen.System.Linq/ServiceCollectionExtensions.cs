using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Eliassen.System.ResponseModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.System;

/// <summary>
/// Suggested IOC configurations
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add support for shared SearchQuery Extensions
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddSearchQueryExtensions(this IServiceCollection services)
    {
        services.TryAddTransient(typeof(IQueryBuilder<>), typeof(QueryBuilder<>));
        services.TryAddTransient(typeof(ISortBuilder<>), typeof(SortBuilder<>));
        services.TryAddTransient(typeof(IExpressionTreeBuilder<>), typeof(ExpressionTreeBuilder<>));

        services.AddTransient<IPostBuildExpressionVisitor, StringComparisonReplacementExpressionVisitor>();

        //services.AddTransient<IPostBuildExpressionVisitor, SkipInstanceMethodOnNullExpressionVisitor>();

        services.TryAddScoped<ICaptureResultMessage, CaptureResultMessage>();
        return services;
    }
}
