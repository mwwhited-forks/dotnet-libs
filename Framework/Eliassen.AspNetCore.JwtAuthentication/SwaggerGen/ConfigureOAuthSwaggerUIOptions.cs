using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace Eliassen.AspNetCore.SwaggerGen.B2C;

public class ConfigureOAuthSwaggerUIOptions : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IOptions<JwtBearerOptions> _jwtBearer;

    public ConfigureOAuthSwaggerUIOptions(IOptions<JwtBearerOptions> jwtBearer)
    {
        _jwtBearer = jwtBearer;
    }

    public void Configure(SwaggerUIOptions options)
    {
        options.OAuthClientId(_jwtBearer.Value.Audience);
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    }
}