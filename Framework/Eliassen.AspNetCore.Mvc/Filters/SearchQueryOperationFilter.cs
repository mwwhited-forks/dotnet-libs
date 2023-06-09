﻿using Eliassen.System.Linq;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters;

public class SearchQueryOperationFilter : IOperationFilter
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public SearchQueryOperationFilter(
         ILogger<SearchQueryOperationFilter> logger,
         IServiceProvider serviceProvider
        )
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        //if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IPagedQueryResult)) )
        //{
        //    var requestType = new
        //    {
        //        methods = context.MethodInfo.GetCustomAttributes(true).OfType<HttpMethodAttribute>(),
        //    };
        //}

        if (context.MethodInfo.ReturnType.IsAssignableTo(typeof(IQueryable)) && context.MethodInfo.ReturnType.IsGenericType)
        {
            var elementType = context.MethodInfo.ReturnType.GetGenericArguments()[0];
            var treeBuilder = (IExpressionTreeBuilder)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(ExpressionTreeBuilder<>).MakeGenericType(elementType));

            var requestType = typeof(SearchQuery<>).MakeGenericType(elementType);
            //var responseType = typeof(QueryResult<>).MakeGenericType(elementType);
            var pagedResponseType = typeof(PagedQueryResult<>).MakeGenericType(elementType);

            _logger.LogInformation(
                $"{{{nameof(context.MethodInfo.DeclaringType)}}}::{{{nameof(context.MethodInfo)}}}:>{{{nameof(elementType)}}}",
                context.MethodInfo.DeclaringType?.Name ?? "[Lambda]",
                context.MethodInfo.Name,
                elementType
                );

            var elementSchema = context.SchemaGenerator.GenerateSchema(elementType, context.SchemaRepository);
            var requestSchema = context.SchemaGenerator.GenerateSchema(requestType, context.SchemaRepository);
            //var responseSchema = _schemaGenerator.GenerateSchema(responseType, context.SchemaRepository);
            var pagedResponseSchema = context.SchemaGenerator.GenerateSchema(pagedResponseType, context.SchemaRepository);
            var contentTypes = (
                from responseType in context.ApiDescription.SupportedResponseTypes
                from format in responseType.ApiResponseFormats
                where format.MediaType.EndsWith("/json")
                select format.MediaType
                ).Distinct();

            if (context.ApiDescription.HttpMethod == "POST")
            {
                var schema = UpdateRequestSchema(elementType, context.SchemaRepository, requestSchema, treeBuilder);

                ApplyContent(
                    (operation.RequestBody ??= new OpenApiRequestBody()).Content,
                    requestSchema.Reference,
                    contentTypes
                    );

                //TODO: add request type for form data
                //var formDataTypes = new[] { "multipart/form-data", "multipart/form-data" };
            }
            else
            {
                var request = UpdateRequestSchema(elementType, context.SchemaRepository, requestSchema, treeBuilder);

                context.SchemaRepository.TryLookupByType(typeof(FilterParameter), out var filterSchemaReference);
                var filterSchema = UpdateRequestSchema(elementType, context.SchemaRepository, filterSchemaReference, treeBuilder);

                context.SchemaRepository.TryLookupByType(typeof(OrderDirections), out var orderSchema);

                //Type getPropertyType(string propertyName) => elementType.GetProperty(propertyName)?.PropertyType;

                //(OpenApiSchema item, OpenApiSchema array) getSchema(string propertyName) =>
                //    (
                //    context.SchemaRepository.TryLookupByType(elementType.GetProperty(propertyName)?.PropertyType, out var ps) ? ps : null,
                //    context.SchemaRepository.TryLookupByType(elementType.GetProperty(propertyName)?.PropertyType, out var pas) ? pas : null
                //    );

                var parameters = operation.Parameters ??= new List<OpenApiParameter>();
                //TODO: build query request
                foreach (var property in request.Properties)
                {
                    if (property.Key.Equals(nameof(ISearchQuery.Filter), StringComparison.InvariantCultureIgnoreCase))
                    {
                        //TODO: ignore filter support for now.
                        //var fitlerableProperties = ExpressionTreeBuilder.GetFilterablePropertyNames(elementType);
                        //foreach (var filter in fitlerableProperties)
                        //{
                        //    var localFilterSchema = getSchema(filter);
                        //    foreach (var filtertype in filterSchema.Properties)
                        //    {
                        //        parameters.Add(new OpenApiParameter()
                        //        {
                        //            Name = $"{property.Key}.{filter}.{filtertype.Key}",
                        //            Schema = (filtertype.Key == "in") ? localFilterSchema.array : localFilterSchema.item,
                        //            In = ParameterLocation.Query,
                        //        });
                        //    }
                        //}
                    }
                    else if (property.Key.Equals(nameof(ISearchQuery.OrderBy), StringComparison.InvariantCultureIgnoreCase))
                    {
                        var sortableProperties = treeBuilder.GetSortablePropertyNames();
                        foreach (var sort in sortableProperties)
                        {
                            parameters.Add(new OpenApiParameter()
                            {
                                Name = $"{property.Key}.{sort}",
                                Schema = orderSchema,
                                In = ParameterLocation.Query,
                            });
                        }
                    }
                    else
                    {
                        parameters.Add(new OpenApiParameter()
                        {
                            Name = property.Key,
                            Description = property.Value.Description,
                            Schema = property.Value,
                            In = ParameterLocation.Query,
                        });
                    }
                }

            }
            ApplyContent(
                (operation.Responses["200"] ??= new OpenApiResponse()).Content,
                pagedResponseSchema.Reference,
                context.ApiDescription.SupportedResponseTypes.SelectMany(m => m.ApiResponseFormats.Select(i => i.MediaType)).Distinct()
                );
        }
    }

    private OpenApiSchema GetSchema(SchemaRepository repository, OpenApiSchema schema) =>
        repository.Schemas[schema.Reference.Id];

    private OpenApiSchema UpdateRequestSchema(
        Type elementType,
        SchemaRepository schemaRepository,
        OpenApiSchema requestSchema,
        IExpressionTreeBuilder treebuilder
        )
    {
        var schema = schemaRepository.Schemas[requestSchema.Reference.Id];
        if (schema == null) return null;

        var properties = schema.Properties.ChangeComparer(StringComparer.InvariantCultureIgnoreCase);

        if (properties.TryGetValue(nameof(ISearchQuery.PageSize), out var pageSize))
        {
            pageSize.Description = $"**Default size:** `{QueryBuilder.DefaultPageSize}`, `-1` will disable paging";
        }
        if (properties.TryGetValue(nameof(ISearchQuery.ExcludePageCount), out var excludePageCount))
        {
            excludePageCount.Description = "`true` will disable row/page counts and may decrease processing time without effecting paging functions";
        }

        if (properties.TryGetValue(nameof(ISearchQuery.Filter), out var filter))
        {
            filter.Description = $"**Filterable Properties:** {string.Join("; ", treebuilder.GetFilterablePropertyNames())}";
        }

        if (properties.TryGetValue(nameof(ISearchQuery.OrderBy), out var orderBy))
        {
            var sortableProperties = treebuilder.GetSortablePropertyNames();
            var defaultSort = from ordinal in treebuilder.DefaultSortOrder()
                              select $"{ordinal.column} {ordinal.direction.AsString()}";
            orderBy.Description =
                $"**Sortable Properties:** {string.Join(", ", sortableProperties)}  " +
                $"**Default Order:** {string.Join(", ", defaultSort)}"
                ;
        }

        if (properties.TryGetValue(nameof(ISearchQuery.SearchTerm), out var searchTerm))
        {
            searchTerm.Description = $"**Searched Properties:** {string.Join("; ", treebuilder.GetSearchablePropertyNames())}";
        }
        return schema;
    }

    private void ApplyContent(
        IDictionary<string, OpenApiMediaType> content,
        OpenApiReference reference,
        IEnumerable<string> contentTypes
        )
    {
        foreach (var contentType in contentTypes)
        {
            var mediaType = new OpenApiMediaType
            {
                Schema = new OpenApiSchema
                {
                    Reference = reference,
                },
            };
            if (content.ContainsKey(contentType))
            {
                content[contentType] = mediaType;
            }
            else
            {
                content.Add(contentType, mediaType);
            }
        }
    }
}