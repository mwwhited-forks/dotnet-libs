using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

/// <summary>
/// Register additional IOperationFilters
/// </summary>
/// <typeparam name="T"></typeparam>
public class AddSchemaFilterOptions<T> : IConfigureOptions<SwaggerGenOptions>
    where T : ISchemaFilter
{
    /// <inheritdoc />
    public void Configure(SwaggerGenOptions options) => options.SchemaFilter<T>();
}