using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;

/// <summary>
/// Configures SwaggerGen options for OAuth2 authentication.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ConfigureOAuthSwaggerGenOptions"/> class.
/// </remarks>
/// <param name="config">The OAuth2 Swagger options.</param>
public class ConfigureOAuthSwaggerGenOptions(
    IOptions<OAuth2SwaggerOptions> config
    ) : IConfigureOptions<SwaggerGenOptions>
{
    /// <summary>
    /// Gets the OAuth2 scopes.
    /// </summary>
    /// <returns>The OAuth2 scopes.</returns>
    private Dictionary<string, string> GetScopes()
    {
        var scopes = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(config.Value.UserReadApiClaim))
        {
            scopes.Add(config.Value.UserReadApiClaim, nameof(config.Value.UserReadApiClaim));
        }

        return scopes;
    }

    /// <summary>
    /// Configures SwaggerGen options for OAuth2 authentication.
    /// </summary>
    /// <param name="options">The SwaggerGen options to configure.</param>
    public void Configure(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Name = "oauth2",
            Description = "oauth2 authentication",

            Flows = new OpenApiOAuthFlows()
            {
                Implicit = new OpenApiOAuthFlow()
                {
                    Scopes = GetScopes(),
                    AuthorizationUrl = new Uri(config.Value.AuthorizationUrl ?? throw new ApplicationException($"{nameof(config.Value.AuthorizationUrl)} is not configured")),
                    TokenUrl = new Uri(config.Value.TokenUrl ?? throw new ApplicationException($"{nameof(config.Value.TokenUrl)} is not configured")),
                },
            }
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                },
                Array.Empty<string>()
            },
        });
    }
}
