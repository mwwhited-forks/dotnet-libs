using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Eliassen.AspNetCore.SwaggerGen.B2C;

/// <summary>
/// Configures SwaggerUI options for OAuth authentication.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ConfigureOAuthSwaggerUIOptions"/> class.
/// </remarks>
/// <param name="jwtBearer">The JwtBearer options.</param>
public class ConfigureOAuthSwaggerUIOptions(
    IOptions<JwtBearerOptions> jwtBearer
    ) : IConfigureOptions<SwaggerUIOptions>
{
    /// <summary>
    /// Configures SwaggerUI options for OAuth authentication.
    /// </summary>
    /// <param name="options">The SwaggerUI options to configure.</param>
    public void Configure(SwaggerUIOptions options)
    {
        options.OAuthClientId(jwtBearer.Value.Audience);
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    }
}