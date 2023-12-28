using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

/// <summary>
/// Register additional IOperationFilters
/// </summary>
/// <typeparam name="T"></typeparam>
public class AddOperationFilterOptions<T> : IConfigureOptions<SwaggerGenOptions>
    where T : IOperationFilter
{
    public void Configure(SwaggerGenOptions options) => options.OperationFilter<T>();
}