using System.Reflection;
using Nucleus.Core.Business;
using Nucleus.Blog.Business;
using Nucleus.Vlog.Business;
using Nucleus.Project.Business;
using Nucleus.Core.Shared.Persistence;
using Nucleus.Core.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Nucleus.Api.Auth;
using Nucleus.Core.Contracts.Models.DbSettings;
using System.Security.Claims;
using Nucleus.Blog.Contracts.Collections.DbSettings;
using Nucleus.Vlog.Contracts.Collections.DbSettings;
using Nucleus.Project.Contracts.Collections.DbSettings;
using Nucleus.Blog.Persistence;
using Nucleus.Vlog.Persistence;
using Nucleus.Core.Shared.Business;

var builder = WebApplication.CreateBuilder(args);

// Setup connection strings
builder.Services.Configure<DocumentDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));
builder.Services.Configure<BlogDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));
builder.Services.Configure<VlogDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));
builder.Services.Configure<ProjectDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));
builder.Services.Configure<ModuleDatabaseSettings>(
    builder.Configuration.GetSection("MongoDatabase"));

// Add additional assemblies here so we can keep our API Project clean and easily scalable
builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load("Nucleus.Blog.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Vlog.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Project.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Core.Controllers"))
    .AddApplicationPart(Assembly.Load("Nucleus.Core.Shared.Controllers"));

// Adding Module Registrations for IOC
builder.Services
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddTransient(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? ClaimsPrincipal.Current)
    .AddCorePersistenceServices()
    .AddCoreBusinessServices()
    .AddSharedBusinessServices()
    .AddPublicBusinessServices()
    .AddVlogBusinessServices()
    .AddProjectBusinessServices()
    .AddProjectPersistenceServices()
    .AddBlogPersistenceServices()
    .AddVlogPersistenceServices()
    ;

// Adding in the magic sauce that connects B2C Bearer tokens to our internal users
builder.Services.AddSingleton<IAuthorizationHandler, AuthorizationHandler>();

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

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .AddRequirements(new UserAuthorizationRequirement())
    .Build();
});

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

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
