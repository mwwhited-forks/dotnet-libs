using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

public class HealthCheckSwaggerGenEntpointOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.DocumentFilter<HealthChecksDocumentFilter>();
    }
}
