using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Nucleus.Core.Busines.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Nucleus.Api.Auth;

public class ApplicationPermissionsApiFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var allowAnonymous =
            context.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>()
            .Concat(
            context.MethodInfo.DeclaringType.GetCustomAttributes<AllowAnonymousAttribute>()
            ).Any();

        var applicationRights =
            context.MethodInfo.GetCustomAttributes<ApplicationRightAttribute>()
            .Concat(
            context.MethodInfo.DeclaringType.GetCustomAttributes<ApplicationRightAttribute>()
            ).SelectMany(a => a.Rights);

        operation.Extensions.Add("x-permissions", new ApiPermissionsExtension(allowAnonymous, applicationRights));
    }
}
