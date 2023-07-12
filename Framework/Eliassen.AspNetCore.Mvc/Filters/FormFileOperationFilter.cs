using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters;

/// <inheritdoc/>
public class FormFileOperationFilter : IOperationFilter
{
    // https://dejanstojanovic.net/aspnet/2021/april/handling-file-upload-in-aspnet-core-5-with-swagger-ui/?theme=light
    /// <inheritdoc/>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMime = "multipart/form-data";
        if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
            return;

        var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
        operation.RequestBody.Content[fileUploadMime].Schema.Properties =
            fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
            {
                Type = "string",
                Format = "binary"
            });
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
    }
}
