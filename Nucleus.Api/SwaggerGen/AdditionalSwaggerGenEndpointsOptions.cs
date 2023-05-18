﻿using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Nucleus.Api.Auth;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nucleus.Api.SwaggerGen;

public class AdditionalSwaggerGenEndpointsOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IActionDescriptorCollectionProvider _provider;
    private readonly ILogger _log;

    public AdditionalSwaggerGenEndpointsOptions(
        IActionDescriptorCollectionProvider provider,
        ILogger<AdditionalSwaggerGenEndpointsOptions> log
        )
    {
        _provider = provider;
        _log = log;
    }

    public void Configure(SwaggerGenOptions options)
    {
        options.OperationFilter<ApplicationPermissionsApiFilter>();

        var assemblyName = GetType().Assembly.GetName();

        options.DocInclusionPredicate((name, desc) => name == "all" || name == desc.GroupName);
        options.CustomSchemaIds(x => x.FullName); // https://wegotcode.com/microsoft/swagger-fix-for-dotnetcore/

        options.SwaggerDoc("all", new OpenApiInfo
        {
            Title = assemblyName.Name,
            Version = assemblyName.Version?.ToString() ?? "v0.0.0.0",
        });

        foreach (var group in _provider.ActionDescriptors.Items.OfType<ControllerActionDescriptor>()
            .Select(c => c.ControllerTypeInfo.Assembly)
            .Distinct())
        {
            var groupName = group.GetName().Name;
            options.SwaggerDoc(groupName, new OpenApiInfo
            {
                Title = groupName,
                Version = group.GetName().Version?.ToString() ?? "v0.0.0.0",
            });
        }

        var commentFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
        foreach (var file in commentFiles)
        {
            try
            {
                _log.LogWarning($"Loading comments from \"{{{nameof(file)}}}\"", Path.GetFileName(file));
                options.IncludeXmlComments(file);
            }
            catch (Exception e)
            {
                _log.LogWarning($"{{{nameof(file)}}}: {{{nameof(e.Message)}}}", Path.GetFileName(file), e.Message);
            }
        }
    }
}
