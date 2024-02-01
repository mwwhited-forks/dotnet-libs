using Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;
using Eliassen.Common;
using Eliassen.Common.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Eliassen.WebApi;

/// <summary>
/// primary entry point
/// </summary>
public class Program
{
    /// <summary>
    /// primary entry point
    /// </summary>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        // Add example application services 
        services.AddApplicationServices();

        var identityProvider = Enum.TryParse<IdentityProviders>(
            Environment.GetEnvironmentVariable("IDENTITY_PROVIDER"), ignoreCase: true, out var ip) ? ip : IdentityProviders.AzureB2C;
        var authProvider = identityProvider != IdentityProviders.None ? $"{identityProvider}:" : "";
        var skipHosting = bool.TryParse(Environment.GetEnvironmentVariable("SWAGGER_ONLY"), out var ret) && ret;

        // Add internal services
        services.TryAllCommonExtensions(
            builder.Configuration,
            systemBuilder: new()
            {
            },
            aspNetBuilder: new()
            {
                RequireApplicationUserId = false,
            },
            jwtBuilder: new()
            {
                JwtBearerConfigurationSection = authProvider + nameof(JwtBearerOptions),
                OAuth2SwaggerConfigurationSection = authProvider + nameof(OAuth2SwaggerOptions),
            },
            identityBuilder: new()
            {
                IdentityProvider = identityProvider,
            },
            externalBuilder: new()
            {
            },
            hostingBuilder: new()
            {
                DisableMailKit = skipHosting,
                DisableMessageQueueing = skipHosting,
            });

        // Add services to the container.
        services.AddLogging(builder => builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Debug)
        );

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAllCommonMiddleware();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
