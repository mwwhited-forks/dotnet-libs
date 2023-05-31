using Eliassen.System.Linq.Search;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
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
            var elementType = context.MethodInfo.ReturnType.GetGenericArguments()[0];
            var requestType = typeof(SearchQuery<>).MakeGenericType(elementType);
            var responseType = typeof(PagedSearchResult<>).MakeGenericType(elementType);

            _logger.LogInformation(
                $"{{{nameof(context.MethodInfo.DeclaringType)}}}::{{{nameof(context.MethodInfo)}}}:>{{{nameof(elementType)}}}",
                context.MethodInfo.DeclaringType.Name,
                context.MethodInfo.Name,
                elementType
                );

            BuildSchemas(context.SchemaRepository.Schemas, elementType, requestType, responseType);
            BuildRequestBodies(operation.RequestBody ??= new OpenApiRequestBody(), requestType);
            BuildResponses(operation.Responses ??= new OpenApiResponses(), responseType);
        }
    }

    private void BuildResponses(OpenApiResponses responses, params Type[] types)
    {
        var contentTypes = new[]
        {
            "application/json",
            "text/json",
            "text/plain"
            //"text/plain",
            //"text/csv",
        };

        //TODO: clean this model up a little

        var response = responses["200"] ??= new OpenApiResponse()
        {
            Description = "Success",
        };

        response.Content.Clear();

        foreach (var type in types)
            foreach (var contentType in contentTypes)
            {
                response.Content.Add(contentType, new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = new OpenApiReference
                        {
                            Id = type.FullName,
                            Type = ReferenceType.Schema,
                        },
                    },
                });
            }
    }

    private void BuildRequestBodies(OpenApiRequestBody requestBody, params Type[] types)
    {
        var contentTypes = new[]
        {
            "application/json",
            "text/json",
            "application/*+json",
            //"text/plain",
        };

        //TODO: clean this model up a little

        foreach (var type in types)
            foreach (var contentType in contentTypes)
            {
                requestBody.Content.Add(contentType, new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = new OpenApiReference
                        {
                            Id = type.FullName,
                            Type = ReferenceType.Schema,
                        },
                    },
                });
            }
    }

    private void BuildSchemas(Dictionary<string, OpenApiSchema> schemas, params Type[] types)
    {
        foreach (var type in types)
        {
            if (schemas.ContainsKey(type.FullName)) continue;
            schemas.Add(type.FullName, GetSchema(type));
        }
    }

    private OpenApiSchema GetSchema(Type type)
    {
        if (type.IsPrimitive)
        {
            if (type == typeof(int))
            {
                return new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int32"
                };
            }
            else if (type == typeof(bool))
            {
                return new OpenApiSchema
                {
                    Type = "boolean"
                };
            }
            else if (type == typeof(long))
            {
                return new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int64"
                };
            }

            throw new NotSupportedException();
        }
        else if (type == typeof(string))
        {
            return new OpenApiSchema
            {
                Type = "string"
            };
        }

        var schema = new OpenApiSchema()
        {
            Type = "object",
        };
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
        foreach (var property in properties)
        {
            schema.Properties.Add(property.Name, GetSchema(property.PropertyType));
        }

        return schema;
    }
}