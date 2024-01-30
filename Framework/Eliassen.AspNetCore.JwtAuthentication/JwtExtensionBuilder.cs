using Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Eliassen.AspNetCore.JwtAuthentication;

public record JwtExtensionBuilder
{
    public string DefaultSchema { get; init; } = JwtBearerDefaults.AuthenticationScheme;
    public string JwtBearerConfigurationSection { get; init; } = nameof(JwtBearerOptions);
    public string OAuth2SwaggerConfigurationSection { get; init; } = nameof(OAuth2SwaggerOptions);
}
