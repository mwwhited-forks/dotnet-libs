using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.Mvc;
using Eliassen.AspNetCore.SwaggerGen.B2C;
using Eliassen.Azure.StorageAccount;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Hosting;
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
        services.AddTransient<IMessageHandler, ExampleMessageProvider>();

        // Add internal services
        services
            .TryAddMessageQueueingExtensions()
            .TryAddMessageQueueingHosting()
            .TryAllSystemExtensions(builder.Configuration)
            .TryAddAzureStorageAccountServices()

            .TryAddAspNetCoreExtensions()
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

        app.UseAspNetCoreExtensionMiddleware();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
