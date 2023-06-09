﻿using Eliassen.AspNetCore.Mvc.OpenApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace Eliassen.AspNetCore.Mvc.Filters;

public class ApplicationPermissionsApiFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var allowAnonymous =
            context.MethodInfo.GetCustomAttributes<AllowAnonymousAttribute>()
            .Concat(
            context.MethodInfo.DeclaringType?.GetCustomAttributes<AllowAnonymousAttribute>() ??
                Enumerable.Empty<AllowAnonymousAttribute>()
            ).Any();

        var applicationRights =
            context.MethodInfo.GetCustomAttributes<ApplicationRightAttribute>()
            .Concat(
            context.MethodInfo.DeclaringType.GetCustomAttributes<ApplicationRightAttribute>()
            ).SelectMany(a => a.Rights);

        //operation.Security.Add(new OpenApiSecurityRequirement()
        //{
        //    { new OpenApiSecurityScheme()  { Name="Application Rights" }, applicationRights.ToList() }
        //});

        operation.Extensions.Add("x-permissions", new ApiPermissionsExtension(allowAnonymous, applicationRights));
    }
}