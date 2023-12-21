using Eliassen.AspNetCore.SwaggerGen.B2C;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Eliassen.AspNetCore.JwtAuthentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddJwtBearerServices(
        this IServiceCollection services,
        IConfiguration configuration,
        string defaultScheme = JwtBearerDefaults.AuthenticationScheme,
        string jwtBearerConfigurationSection = nameof(JwtBearerOptions),
        string oAuth2SwaggerConfigurationSection = nameof(OAuth2SwaggerOptions)
        ) =>
        services
        .TryAddJwtBearerAuthentication(configuration, defaultScheme, configurationSection: jwtBearerConfigurationSection)
        .TryAddJwtBearerSwaggerGen(configuration, configurationSection: oAuth2SwaggerConfigurationSection)
        ;

    public static IServiceCollection TryAddJwtBearerAuthentication(
        this IServiceCollection services,
        IConfiguration configuration,
        string defaultScheme = JwtBearerDefaults.AuthenticationScheme,
        string configurationSection = nameof(JwtBearerOptions)
        )
    {
        services.AddAuthentication(defaultScheme).AddJwtBearer();
        services.Configure<JwtBearerOptions>(options => configuration.Bind(configurationSection, options));
        return services;
    }

    public static IServiceCollection TryAddJwtBearerSwaggerGen(
        this IServiceCollection services,
        IConfiguration configuration,
        string configurationSection = nameof(OAuth2SwaggerOptions)
        )
    {
        services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, ConfigureOAuthSwaggerUIOptions>();
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, ConfigureOAuthSwaggerGenOptions>();

        services.Configure<OAuth2SwaggerOptions>(options => configuration.Bind(configurationSection, options));

        return services;
    }
}
