using Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;
using Eliassen.AspNetCore.Mvc;
using Eliassen.Common;
using Eliassen.Common.AspNetCore;
using Eliassen.Common.Extensions;
using Eliassen.Common.Extensions.Hosting;
using Eliassen.MessageQueueing;
using Eliassen.WebApi.Provider;
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

        services.AddTransient<IExampleMessageProvider, ExampleMessageProvider>();
        services.AddTransient<IMessageQueueHandler, ExampleMessageProvider>();

        var identityProvider = IdentityProviders.Keycloak;
        var authSuffix = identityProvider switch
        {
            IdentityProviders.Keycloak => "-kc",
            IdentityProviders.AzureB2C => "-b2c",
            _ => ""
        };
        var skipHosting = bool.TryParse(Environment.GetEnvironmentVariable("SWAGGER_ONLY"), out var ret) && ret;

        // Add internal services
        services.TryAllCommonExtensions(
            builder.Configuration,
            new()
            {
            },
            new()
            {
                RequireApplicationUserId = false,
            },
            new()
            {
                JwtBearerConfigurationSection = nameof(JwtBearerOptions) + authSuffix,
                OAuth2SwaggerConfigurationSection = nameof(OAuth2SwaggerOptions) + authSuffix,
            },
            new()
            {
                IdentityProvider = identityProvider,
            },
            new()
            {
                DisableMailKit = skipHosting,
                DisableMessageQueueing = skipHosting,
            }
            );

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
