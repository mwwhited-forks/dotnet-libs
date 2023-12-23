using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

/// <summary>
/// register additional ASP.Net MVC Filters
/// </summary>
/// <typeparam name="TFilter"></typeparam>
public class AddMvcFilterOptions<TFilter> : IConfigureOptions<MvcOptions>
    where TFilter : IFilterMetadata
{
    /// <inheritdoc />
    public void Configure(MvcOptions options) =>
        options.Filters.Add(typeof(TFilter));
}
