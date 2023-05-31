using Eliassen.System.Linq;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Eliassen.System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            //var responseType = typeof(QueryResult<>).MakeGenericType(elementType);
            var pagedResponseType = typeof(PagedQueryResult<>).MakeGenericType(elementType);

            _logger.LogInformation(
                $"{{{nameof(context.MethodInfo.DeclaringType)}}}::{{{nameof(context.MethodInfo)}}}:>{{{nameof(elementType)}}}",
                context.MethodInfo.DeclaringType?.Name ?? "[Lambda]",
                context.MethodInfo.Name,
                elementType
                );

            var elementSchema = _schemaGenerator.GenerateSchema(elementType, context.SchemaRepository);
            var requestSchema = _schemaGenerator.GenerateSchema(requestType, context.SchemaRepository);
            //var responseSchema = _schemaGenerator.GenerateSchema(responseType, context.SchemaRepository);
            var pagedResponseSchema = _schemaGenerator.GenerateSchema(pagedResponseType, context.SchemaRepository);

            UpdateRequestSchema(elementType, context.SchemaRepository, requestSchema);

            ApplyContent(
                (operation.Responses["200"] ??= new OpenApiResponse()).Content,
                pagedResponseSchema.Reference,
                "application/json",
                "text/json",
                "text/plain"
                );

            ApplyContent(
                (operation.RequestBody ??= new OpenApiRequestBody()).Content,
                requestSchema.Reference,
                "application/json",
                "text/json",
                "text/plain");
        }
    }

    private void UpdateRequestSchema(Type elementType, SchemaRepository schemaRepository, OpenApiSchema requestSchema)
    {
        var schema = schemaRepository.Schemas[requestSchema.Reference.Id];
        if (schema == null) return;

        var properties = schema.Properties.ChangeComparer(StringComparer.InvariantCultureIgnoreCase);

        if (properties.TryGetValue(nameof(ISearchQuery.PageSize), out var pageSize))
        {
            pageSize.Description = $"**Default size:** `{SearchQueryExtensions.DefaultPageSize}`, `-1` will disable paging";
        }
        if (properties.TryGetValue(nameof(ISearchQuery.ExcludePageCount), out var excludePageCount))
        {
            excludePageCount.Description = "`true` will disable row/page counts and may decrease processing time without effecting paging functions";
        }

        if (properties.TryGetValue(nameof(ISearchQuery.Filter), out var filter))
        {
            filter.Description = $"**Filterable Properties:** {string.Join("; ", ExpressionTreeBuilder.GetFilterablePropertyNames(elementType))}";
        }

        if (properties.TryGetValue(nameof(ISearchQuery.OrderBy), out var orderBy))
        {
            var sortableProperties = ExpressionTreeBuilder.GetSortablePropertyNames(elementType);
            var defaultSort = from ordinal in SortByExtension.DefaultSortOrder(elementType)
                              select $"{ordinal.column} {ordinal.direction.AsString()}";
            orderBy.Description = 
                $"**Sortable Properties:** {string.Join(", ", sortableProperties)}  " +
                $"**Default Order:** {string.Join(", ", defaultSort)}"
                ;
        }

        if (properties.TryGetValue(nameof(ISearchQuery.SearchTerm), out var searchTerm))
        {
            searchTerm.Description = $"**Searched Properties:** {string.Join("; ", ExpressionTreeBuilder.GetSearchablePropertyNames(elementType))}";
        }
    }

    private void ApplyContent(IDictionary<string, OpenApiMediaType> content, OpenApiReference reference, params string[] responseContentTypes)
    {
        foreach (var contentType in responseContentTypes)
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