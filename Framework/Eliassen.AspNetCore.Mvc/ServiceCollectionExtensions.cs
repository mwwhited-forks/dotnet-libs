using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System.Accessors;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;
using System.Security.Claims;

namespace Eliassen.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreExtensions(this IServiceCollection services)
        {
            services.AddAccessor<CultureInfo>();
            services.AddAccessor<ISearchQuery>();
            services.TryAddSingleton<SearchQueryResultFilter>();
            services.TryAddSingleton(typeof(IQueryBuilder<>), typeof(QueryBuilder<>));
            services.TryAddSingleton(typeof(ISortBuilder<>), typeof(SortBuilder<>));
            services.TryAddSingleton(typeof(IExpressionTreeBuilder<>), typeof(ExpressionTreeBuilder<>));
            services.TryAddTransient<IPostBuildExpressionVisitor, StringIgnoreCaseReplacerExpressionVisitor>();

            services.TryAddSingleton<IConfigureOptions<SwaggerGenOptions>, AdditionalSwaggerGenEndpointsOptions>();
            services.TryAddSingleton<IConfigureOptions<SwaggerUIOptions>, AdditionalSwaggerUIEndpointsOptions>();

            services.AddControllers(opt =>
            {
                opt.Filters.Add(typeof(SearchQueryResultFilter));
                opt.Conventions.Add(new ApiNamespaceControllerModelConvention());
            });

            services.AddSwaggerGen(setup =>
            {
                setup.OperationFilter<SearchQueryOperationFilter>();
                setup.OperationFilter<FormFileOperationFilter>();
            });

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.TryAddTransient(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? ClaimsPrincipal.Current);


            return services;
        }
    }
}