using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Nucleus.Api.Auth;

public class OAuthSwaggerUIOptions : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IOptions<AzureB2CConfig> _b2cConfig;

    public OAuthSwaggerUIOptions(IOptions<AzureB2CConfig> b2cConfig)
    {
        _b2cConfig = b2cConfig;
    }

    public void Configure(SwaggerUIOptions options)
    {
        options.OAuthClientId(_b2cConfig.Value.ClientId);
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    }
}
