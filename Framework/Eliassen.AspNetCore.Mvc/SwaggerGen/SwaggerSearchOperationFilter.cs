using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace Nucleus.Api.SwaggerGen;

public class SwaggerSearchOperationFilter : IOperationFilter
{
    private readonly ILogger _logger;

    public SwaggerSearchOperationFilter(
         ILogger<SwaggerSearchOperationFilter> logger)
    {
        _logger = logger;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable)))
        {
        }
        else if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryResult)))
        {
        }

        //if (action.ActionMethod.ReturnType.IsAssignableTo(typeof(IQueryable)))
        //{
        //    if (!action.Parameters.Any())
        //    {
        //        var element = action.ActionMethod.ReturnType.GetElementType();
        //        var searchType = typeof(SearchQuery<>).MakeGenericType(element);
        //    }
        //    // SearchQuery
        //}
        //else if (action.ActionMethod.ReturnType.IsAssignableTo(typeof(IQueryResult)))
        //{
        //}

#warning add modeling for Search
        //TODO: add modeling for Search
        //if (context.MethodInfo.Name == "EXP")
        //{

        //}

        //if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable)))
        //{
        //    var element = context.MethodInfo.ReturnType.GetGenericArguments()[0];

        //    _logger.LogInformation($"Apply: {{{nameof(context.MethodInfo)}}}", context.MethodInfo);


        //    operation.Description = $"{context.MethodInfo}<{element}>()";

        //    var yourCSharpObject = new SearchQuery();
        //    var openApiSchema = new OpenApiSchema();
        //    openApiSchema.Type = "object";
        //    openApiSchema.Properties.Add(nameof(yourCSharpObject.SearchTerm), new OpenApiSchema { Type = "string" });
        //    openApiSchema.Properties.Add(nameof(yourCSharpObject.PageSize), new OpenApiSchema { Type = "int" });

        //    // Set the converted OpenApiSchema as the parameter or response schema
        //    // Here, we assume it's a request body parameter
        //    var requestBody = new OpenApiRequestBody();
        //    requestBody.Content.Add("application/json", new OpenApiMediaType { Schema = openApiSchema });
        //    operation.RequestBody = requestBody;


        //    //operation.RequestBody ??= new OpenApiRequestBody();
        //    //operation.Parameters.Add(new OpenApiParameter()
        //    //{
        //    //    Content =
        //    //    {
        //    //        {"entity", new OpenApiMediaType() {Example = new SearchSchema(element) } }
        //    //    }
        //    //});

        //    //operation.RequestBody.Content.Clear();

        //    ////operation.RequestBody.Content.Add("text/json", new OpenApiMediaType
        //    ////{
        //    ////});
        //    //operation.RequestBody.Content.Add("application/json", new OpenApiMediaType
        //    //{
        //    //    Schema = new OpenApiSchema
        //    //    {
        //    //        Example = new SearchSchema(element)
        //    //    },
        //    //});
        //    //operation.RequestBody.Content.Add("multipart/form-data", new OpenApiMediaType
        //    //{
        //    //});
        //    //operation.RequestBody.Content.Add("application/x-www-form-urlencoded", new OpenApiMediaType
        //    //{
        //    //});

        //    //TODO: http GET


        //    // operation.Responses.Clear();

        //    //operation.Responses.Add("text/json", new OpenApiResponse
        //    //{
        //    //});
        //    //operation.Responses.Add("text/xml", new OpenApiResponse
        //    //{
        //    //});



        //    //operation.RequestBody.Content[fileUploadMime].Schema.Properties =
        //    //    fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
        //    //    {
        //    //        Type = "string",
        //    //        Format = "binary"
        //    //    });
        //}


        //var fileUploadMime = "multipart/form-data";
        //if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
        //    return;

        //var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
        //operation.RequestBody.Content[fileUploadMime].Schema.Properties =
        //    fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
        //    {
        //        Type = "string",
        //        Format = "binary"
        //    });
    }
}