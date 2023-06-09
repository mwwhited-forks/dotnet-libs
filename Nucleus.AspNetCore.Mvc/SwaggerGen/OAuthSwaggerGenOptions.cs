using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Nucleus.AspNetCore.Mvc.SwaggerGen;

public class OAuthSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IOptions<AzureB2CConfig> _config;

    public OAuthSwaggerGenOptions(
        IOptions<AzureB2CConfig> config
        )
    {
        _config = config;
    }
    // https://lightwellnucleusdev.onmicrosoft.com/user.read/read
    public IDictionary<string, string> GetScopes()
    {
        var scopes = new Dictionary<string, string>();

        if (string.IsNullOrWhiteSpace(_config.Value.UserReadApiClaim))
        {
            scopes.Add($"https://{_config.Value.Tenant}.onmicrosoft.com/user.read/read", nameof(_config.Value.UserReadApiClaim));
        }
        else
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
            Description = "B2C authentication",

            Flows = new OpenApiOAuthFlows()
            {
                Implicit = new OpenApiOAuthFlow()
                {
                    Scopes = GetScopes(),
                    AuthorizationUrl = new Uri(_config.Value.AuthorizationUrl),
                    TokenUrl = new Uri(_config.Value.TokenUrl),
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