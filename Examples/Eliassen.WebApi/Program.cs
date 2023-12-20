
using Eliassen.AspNetCore.Mvc;
using Eliassen.MessageQueueing;
using Eliassen.System;
using Eliassen.WebApi.Provider;
using Eliassen.Azure.StorageAccount;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Security.Principal;
using Eliassen.WebApi.Workers;

namespace Eliassen.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;
        // Add example application services 


        // Add internal services
        services
            .TryAddMessageQueueingExtensions()
            .TryAllSystemExtensions(builder.Configuration)
            .AddAspNetCoreExtensions()
            .AddAzureStorageAccountServices()
            ;

        services.AddLogging(builder => builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Debug)
        );

        services.AddHostedService<QueueWorker>();


        //services.AddAccessor<ClaimsPrincipal>();
        //services.AddTransient(sp =>
        //{
        //    var principalAccessor = sp.GetRequiredService<IAccessor<ClaimsPrincipal>>();

        //    var principal = principalAccessor.Value ??= new ClaimsPrincipal();
        //    principal.AddIdentity(new ClaimsIdentity(new GenericIdentity("test-user")));

        //    return principal;
        //});

        services.AddTransient<IExampleMessageProvider, ExampleMessageProvider>();
        services.AddTransient<IMessageHandler, ExampleMessageProvider>();

        // Add services to the container.

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
