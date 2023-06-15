using Eliassen.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Eliassen.AspNetCore.Mvc.SwaggerGen;

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
        options.CustomSchemaIds(ResolveSchemaId); // https://wegotcode.com/microsoft/swagger-fix-for-dotnetcore/

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

    private readonly (string replace, string with)[] _replacements = new[]
    {
        //("Eliassen.", ""),
        //("Lightwell.", ""),
        //("Nucleus.", ""),
        //("Microsoft.", "Ms."),
        //("AspNetCore.", "AspNet."),
        //(".Persistence.", "."),
        //(".Contracts.", "."),
        //(".Models.", "."),
        ("System.", ""),
        ("Linq.", ""),
        (".", "_"),
    };
    // WebUtility.UrlEncode(...)
    private string ResolveSchemaId(Type type) =>
        ResolveSchemaType(type);//.Replace('.', '_');
        //_replacements.Aggregate(
        //    new StringBuilder(ResolveSchemaType(type)),
        //    (sb, v) => sb.Replace(v.replace, v.with),
        //    sb => sb.ToString()
        //    )
        //    ;

    private string ResolveSchemaType(Type type)
    {
        if (type.IsGenericType)
        {
            return $"{type.Namespace}-{type.Name.Split('`')[0]}-{string.Join("__", type.GetGenericArguments().Select(ResolveSchemaId))}";
        }

        return $"{type.Namespace}-{type.Name}";
    }

}
