using Eliassen.AspNetCore.Mvc;
using Eliassen.MongoDB.Extensions;
using Eliassen.System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Nucleus.AspNetCore.Mvc;
using Nucleus.Blog.Business;
using Nucleus.Blog.Persistence;
using Nucleus.Core.Business;
using Nucleus.Core.Controllers;
using Nucleus.Core.Persistence;
using Nucleus.Core.Shared.Business;
using Nucleus.Lesson.Business;
using Nucleus.Lesson.Persistence;
using Nucleus.Project.Business;
using Nucleus.Project.Persistence;
using System.Reflection;
using Nucleus.External.Azure.StorageAccount;
using Nucleus.External.Microsoft.B2C.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoServices(builder.Configuration);
builder.Services.TryAllSystemExtensions(builder.Configuration);

// Add additional assemblies here so we can keep our API Project clean and easily scalable
builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load("Nucleus.Blog.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Lesson.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Project.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Core.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Core.Shared.Controllers"))
    ;

// Add Shared Modules
//Nucleus.External.Microsoft.B2C.ServiceCollectionEx.AddMicrosoftB2CServices()
Nucleus.External.Microsoft.B2C.ServiceCollectionEx.AddMicrosoftB2CServices(builder.Services);
builder.Services
    //.AddMicrosoftB2CServices()
    .AddAzureStorageAccountServices()
    ;

// Adding Module Registrations for IOC
builder.Services
    .AddCorePersistenceServices()
    .AddCoreBusinessServices()
    .AddCoreWebServices()

    .AddSharedBusinessServices()
    .AddPublicBusinessServices()
    .AddProjectBusinessServices()
    .AddProjectPersistenceServices()
    .AddBlogPersistenceServices()
    .AddLessonBusinessServices()
    .AddLessonPersistenceServices()
    ;

builder.Services.AddAspNetCoreExtensions();
builder.Services.AddApplicationAspNetCoreServices();

// B2C Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // Add the primary JWT bearer configuration for an Azure AD B2C policy.
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Azure:AdB2C:Instance"] + builder.Configuration["Azure:AdB2C:Domain"] + "/" + builder.Configuration["Azure:AdB2C:Policy"] + "/v2.0/";
        options.Audience = builder.Configuration["Azure:AdB2C:ClientId"];

        // Leaving Jwt Event listener here for development purposes so-as we can capture/log for additional feedback.
        //options.Events = new JwtBearerEvents
        //{
        //    OnTokenValidated = context =>
        //    {
        //        var objectid = context.Principal?.Claims.Where(r => r.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").FirstOrDefault()?.Value;
        //        // Log user in if they are not already logged in
        //        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        //        {
        //            // Ensure this is still the same user
        //        } else
        //        {
        //            // Log the user in
        //        }
        //        return Task.CompletedTask;
        //    },
        //    OnAuthenticationFailed = context =>
        //    {
        //        // Bearer token is invalid or has expired... kickem to the curb if they are logged in
        //        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        //        {
        //            // User should be logged out
        //        }
        //        return Task.CompletedTask;
        //    }
        //};
    });

builder.Services.Configure<AzureB2CConfig>(options => builder.Configuration.Bind(AzureB2CConfig.ConfigKey, options));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy
            .WithOrigins(builder.Configuration["CORS:AllowedOrigins"]?.Split(';') ?? Array.Empty<string>())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            ;
    });
});

builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAspNetCoreExtensionMiddleware();

app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
