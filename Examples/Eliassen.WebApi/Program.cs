using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.Mvc;
using Eliassen.Azure.StorageAccount;
using Eliassen.Communications;
using Eliassen.Communications.MessageQueueing;
using Eliassen.MailKit;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Hosting;
using Eliassen.Microsoft.B2C;
using Eliassen.System;
using Eliassen.WebApi.Provider;

namespace Eliassen.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        // Add example application services 

        services.AddTransient<IExampleMessageProvider, ExampleMessageProvider>();
        services.AddTransient<IMessageQueueHandler, ExampleMessageProvider>();

        // Add internal services
        services
            .TryAllSystemExtensions(builder.Configuration)

            .TryAddMessageQueueingServices()
                .TryAddMessageQueueingHosting()
                .TryAddAzureStorageServices()

            .TryAddCommunicationsServices()
                .TryAddCommunicationQueueServices()
                .TryAddMailKitExtensions(builder.Configuration)

            .AddMicrosoftB2CServices()

            .TryAddAspNetCoreExtensions(requireApplicationUserId: false)
                .TryAddJwtBearerServices(builder.Configuration)
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
