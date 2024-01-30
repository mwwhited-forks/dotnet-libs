using Eliassen.Common.AspNetCore;
using Microsoft.AspNetCore.Builder;

namespace Eliassen.Common;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseAllCommonMiddleware(this IApplicationBuilder builder) =>
        builder.UseCommonAspNetCoreMiddleware();
}
