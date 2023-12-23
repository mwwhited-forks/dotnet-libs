using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;


namespace Eliassen.AspNetCore.SwaggerGen.B2C;

/// <summary>
/// Configures SwaggerUI options for OAuth authentication.
/// </summary>
public class ConfigureOAuthSwaggerUIOptions : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IOptions<JwtBearerOptions> _jwtBearer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureOAuthSwaggerUIOptions"/> class.
    /// </summary>
    /// <param name="jwtBearer">The JwtBearer options.</param>
    public ConfigureOAuthSwaggerUIOptions(IOptions<JwtBearerOptions> jwtBearer)
    {
        _jwtBearer = jwtBearer ?? throw new ArgumentNullException(nameof(jwtBearer));
    }

    /// <inheritdoc/>
    public void Configure(SwaggerUIOptions options)
    {
        options.OAuthClientId(_jwtBearer.Value.Audience);
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    }
}