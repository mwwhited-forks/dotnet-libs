using Eliassen.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

namespace Eliassen.Common.AspNetCore;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCommonAspNetCoreMiddleware(this IApplicationBuilder builder) =>
        builder.UseAspNetCoreExtensionMiddleware();
}
