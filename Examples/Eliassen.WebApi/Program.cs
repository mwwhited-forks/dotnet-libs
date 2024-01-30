using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;
using Eliassen.AspNetCore.Mvc;
using Eliassen.Azure.StorageAccount;
using Eliassen.Communications;
using Eliassen.Communications.MessageQueueing;
using Eliassen.Keycloak;
using Eliassen.Identity;
using Eliassen.MailKit;
using Eliassen.MailKit.Hosting;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Hosting;
using Eliassen.Microsoft.B2C;
using Eliassen.MongoDB.Extensions;
using Eliassen.RabbitMQ;
using Eliassen.System;
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

        var authSuffix = "-kc";
        //var authSuffix = "-b2c";

        // Add internal services
        services
            .TryAddSystemExtensions(builder.Configuration)
            .TryAddMongoServices(builder.Configuration)

            .TryAddMessageQueueingServices()
                .TryAddMessageQueueingHosting()
                .TryAddAzureStorageServices(builder.Configuration)
                .TryAddRabbitMQServices()

            .TryAddCommunicationsServices()
                .TryAddCommunicationQueueServices()
                .TryAddMailKitExtensions(builder.Configuration)
                   .TryAddMailKitHosting()

            .TryAddIdentityServices(builder.Configuration)
                .TryAddMicrosoftB2CServices(builder.Configuration)
                .TryAddKeycloakServices(builder.Configuration)

            .TryAddAspNetCoreExtensions(requireApplicationUserId: false)
                .TryAddJwtBearerServices(builder.Configuration, 
                    jwtBearerConfigurationSection: nameof(JwtBearerOptions) + authSuffix,
                    oAuth2SwaggerConfigurationSection: nameof(OAuth2SwaggerOptions) + authSuffix
                    )
            ;

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

        app.UseAspNetCoreExtensionMiddleware();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
