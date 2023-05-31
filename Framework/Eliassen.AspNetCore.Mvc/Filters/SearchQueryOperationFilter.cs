using Eliassen.System.Linq.Search;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eliassen.AspNetCore.Mvc.Filters;

public class SearchQueryOperationFilter : IOperationFilter
{
    private readonly ILogger _logger;
    private readonly ISchemaGenerator _schemaGenerator;

    public SearchQueryOperationFilter(
         ILogger<SearchQueryOperationFilter> logger,
         ISchemaGenerator schemaGenerator
        )
    {
        _logger = logger;
        _schemaGenerator = schemaGenerator;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable)) && context.MethodInfo.ReturnType.IsGenericType)
        {
            var elementType = context.MethodInfo.ReturnType.GetGenericArguments()[0];
            var requestType = typeof(SearchQuery<>).MakeGenericType(elementType);
            var responseType = typeof(QueryResult<>).MakeGenericType(elementType);
            var pagedResponseType = typeof(PagedQueryResult<>).MakeGenericType(elementType);

            _logger.LogInformation(
                $"{{{nameof(context.MethodInfo.DeclaringType)}}}::{{{nameof(context.MethodInfo)}}}:>{{{nameof(elementType)}}}",
                context.MethodInfo.DeclaringType?.Name ?? "[Lambda]",
                context.MethodInfo.Name,
                elementType
                );

            var elementSchema = _schemaGenerator.GenerateSchema(elementType, context.SchemaRepository);
            var requestSchema = _schemaGenerator.GenerateSchema(requestType, context.SchemaRepository);
            var responseSchema = _schemaGenerator.GenerateSchema(responseType, context.SchemaRepository);
            var pagedResponseSchema = _schemaGenerator.GenerateSchema(pagedResponseType, context.SchemaRepository);

            var responseContentTypes = new[]
            {
                "application/json",
                "text/json",
                "text/plain"
                //"text/plain",
                //"text/csv",
            };
            var response = operation.Responses["200"] ??= new OpenApiResponse()
            {
                Description = "Success",
            };
            response.Content.Clear();
            foreach (var contentType in responseContentTypes)
            {
                response.Content.Add(contentType, new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = pagedResponseSchema.Reference,
                    },
                });
            }

            var requestBody = operation.RequestBody ??= new OpenApiRequestBody();
            var requestContentTypes = new[]
            {
                "application/json",
                "text/json",
                "text/plain"
            };
            foreach (var contentType in requestContentTypes)
            {
                requestBody.Content.Add(contentType, new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = requestSchema.Reference,
                    },
                });
            }
        }
    }
}