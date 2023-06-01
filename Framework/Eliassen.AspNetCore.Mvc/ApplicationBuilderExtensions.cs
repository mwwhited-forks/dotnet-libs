using Eliassen.AspNetCore.Mvc.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Eliassen.AspNetCore.Mvc
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAspNetCoreExtensionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CultureInfoMiddleware>();
            builder.UseMiddleware<SearchQueryMiddleware>();
            return builder;
        }
    }
}