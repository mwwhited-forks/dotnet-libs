using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System.Accessors;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Eliassen.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreExtensions(this IServiceCollection services)
        {
            services.TryAddScoped<ICultureInfoAccessor, CultureInfoAccessor>();
            services.TryAddScoped(sp => sp.GetRequiredService<ICultureInfoAccessor>().CultureInfo);

            services.TryAddScoped<ISearchQueryAccessor, SearchQueryAccessor>();
            services.TryAddScoped<SearchQueryResultFilter>();
            services.TryAddSingleton(typeof(IQueryBuilder<>), typeof(QueryBuilder<>));
            services.TryAddSingleton(typeof(ISortBuilder<>), typeof(SortBuilder<>));
            services.TryAddSingleton(typeof(IExpressionTreeBuilder<>), typeof(ExpressionTreeBuilder<>));
            services.TryAddTransient<IPostBuildExpressionVisitor, StringIgnoreCaseReplacerExpressionVisitor>();

            services.AddControllers(opt =>
            {
                opt.Filters.Add(typeof(SearchQueryResultFilter));
                opt.Conventions.Add(new ApiNamespaceControllerModelConvention());
            });

            services.TryAddSingleton<IConfigureOptions<SwaggerGenOptions>, AdditionalSwaggerGenEndpointsOptions>();
            services.TryAddSingleton<IConfigureOptions<SwaggerUIOptions>, AdditionalSwaggerUIEndpointsOptions>();
            services.AddSwaggerGen(setup =>
            {
                setup.OperationFilter<FormFileOperationFilter>();
                setup.OperationFilter<SearchQueryOperationFilter>();
            });

            return services;
        }
    }
}