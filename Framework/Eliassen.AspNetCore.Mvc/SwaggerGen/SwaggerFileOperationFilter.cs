using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Nucleus.Api.SwaggerGen;

public class SwaggerFileOperationFilter : IOperationFilter
{
    // https://dejanstojanovic.net/aspnet/2021/april/handling-file-upload-in-aspnet-core-5-with-swagger-ui/?theme=light
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var fileUploadMime = "multipart/form-data";
        if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
            return;

        var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
        operation.RequestBody.Content[fileUploadMime].Schema.Properties =
            fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
            {
                Type = "string",
                Format = "binary"
            });
    }
}
