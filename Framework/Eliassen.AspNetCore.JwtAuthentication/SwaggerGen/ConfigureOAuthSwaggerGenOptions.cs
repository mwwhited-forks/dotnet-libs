using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;


namespace Eliassen.AspNetCore.SwaggerGen.B2C;

public class ConfigureOAuthSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IOptions<OAuth2SwaggerOptions> _config;

    public ConfigureOAuthSwaggerGenOptions(
        IOptions<OAuth2SwaggerOptions> config
        )
    {
        _config = config;
    }
    // https://lightwellnucleusdev.onmicrosoft.com/user.read/read
    private IDictionary<string, string> GetScopes()
    {
        var scopes = new Dictionary<string, string>();

        if (!string.IsNullOrWhiteSpace(_config.Value.UserReadApiClaim))
        {
            scopes.Add(_config.Value.UserReadApiClaim, nameof(_config.Value.UserReadApiClaim));
        }

        return scopes;
    }

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
                    AuthorizationUrl = new Uri(_config.Value.AuthorizationUrl ?? throw new ApplicationException($"{nameof(_config.Value.AuthorizationUrl)} is not configured")),
                    TokenUrl = new Uri(_config.Value.TokenUrl ?? throw new ApplicationException($"{nameof(_config.Value.TokenUrl)} is not configured")),
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