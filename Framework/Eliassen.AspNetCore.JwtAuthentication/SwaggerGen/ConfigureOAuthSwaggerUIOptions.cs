using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;


namespace Eliassen.AspNetCore.SwaggerGen.B2C;

/// <summary>
/// Configures SwaggerUI options for OAuth authentication.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ConfigureOAuthSwaggerUIOptions"/> class.
/// </remarks>
/// <param name="jwtBearer">The JwtBearer options.</param>
public class ConfigureOAuthSwaggerUIOptions(IOptions<JwtBearerOptions> jwtBearer) : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IOptions<JwtBearerOptions> _jwtBearer = jwtBearer ?? throw new ArgumentNullException(nameof(jwtBearer));

    /// <inheritdoc/>
    public void Configure(SwaggerUIOptions options)
    {
        options.OAuthClientId(_jwtBearer.Value.Audience);
        options.OAuthUsePkce();
        options.OAuthScopeSeparator(" ");
    }
}