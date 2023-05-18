using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Nucleus.Api.Auth;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Nucleus.Api.SwaggerGen;

public class AdditionalSwaggerUIEndpointsOptions : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IActionDescriptorCollectionProvider _provider;
    public AdditionalSwaggerUIEndpointsOptions(
        IActionDescriptorCollectionProvider provider,
        IOptions<AzureB2CConfig> b2cConfig
        )
    {
        _provider = provider;
    }

    public void Configure(SwaggerUIOptions options)
    {
        options.SwaggerEndpoint("/swagger/all/swagger.json", "All");

        if (_provider != null)
        {
            foreach (var group in _provider.ActionDescriptors.Items.OfType<ControllerActionDescriptor>()
                .Select(c => c.ControllerTypeInfo.Assembly)
                .Distinct()
                .Select(s => s.GetName().Name))
            {
                options.SwaggerEndpoint($"/swagger/{group}/swagger.json", group);
            }
        }

        options.ShowExtensions();
    }
}
