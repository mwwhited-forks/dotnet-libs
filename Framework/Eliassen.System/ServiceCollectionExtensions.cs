using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Eliassen.System.Net.Mime;
using Eliassen.System.ResponseModel;
using Eliassen.System.Security.Cryptography;
using Eliassen.System.Text;
using Eliassen.System.Text.Json.Serialization;
using Eliassen.System.Text.Templating;
using Eliassen.System.Text.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.System;

/// <summary>
/// Suggested IOC configurations
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// This will add all available extensions to the IOC container
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <param name="defaultHashType"></param>
    /// <param name="defaultSerializerType"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddSystemExtensions(
        this IServiceCollection services,
        IConfiguration config,
        string fileTemplatingConfigurationSection = nameof(FileTemplatingOptions),
        HashTypes defaultHashType = HashTypes.Md5,
        SerializerTypes defaultSerializerType = SerializerTypes.Json
        ) =>
        services
        .TryAddSearchQueryExtensions()
        .TryTemplatingExtensions(config, fileTemplatingConfigurationSection)
        .TrySecurityExtensions(defaultHashType)
        .TrySerializerExtensions(defaultSerializerType)
        ;

    /// <summary>
    /// Add support for shared security extensions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="defaultHashType"></param>
    /// <returns></returns>
    public static IServiceCollection TrySecurityExtensions(
        this IServiceCollection services,
        HashTypes defaultHashType = HashTypes.Md5
        )
    {
        services.TryAddSingleton(sp => sp.GetRequiredKeyedService<IHash>(defaultHashType));

        services.TryAddKeyedSingleton<IHash, Md5Hash>(nameof(HashTypes.Md5).ToUpper());
        services.TryAddKeyedSingleton<IHash, Sha256Hash>(nameof(HashTypes.Sha256).ToUpper());
        services.TryAddKeyedSingleton<IHash, Sha512Hash>(nameof(HashTypes.Sha512).ToUpper());

        services.TryAddKeyedSingleton(HashTypes.Md5, (sp, key) => sp.GetRequiredKeyedService<IHash>(key?.ToString()?.ToUpper()));
        services.TryAddKeyedSingleton(HashTypes.Sha256, (sp, key) => sp.GetRequiredKeyedService<IHash>(key?.ToString()?.ToUpper()));
        services.TryAddKeyedSingleton(HashTypes.Sha512, (sp, key) => sp.GetRequiredKeyedService<IHash>(key?.ToString()?.ToUpper()));

        return services;
    }

    /// <summary>
    /// Add support for shared Serializer
    /// </summary>
    /// <param name="services"></param>
    /// <param name="defaultSerializerType"></param>
    /// <returns></returns>
    public static IServiceCollection TrySerializerExtensions(
        this IServiceCollection services,
        SerializerTypes defaultSerializerType = SerializerTypes.Json
        )
    {
        services.TryAddSingleton(sp => sp.GetRequiredKeyedService<ISerializer>(defaultSerializerType));

        services.TryAddKeyedSingleton(
            SerializerTypes.Json,
            (sp, key) => sp.GetRequiredKeyedService<ISerializer>(key?.ToString()?.ToUpper())
            );
        services.TryAddKeyedSingleton(
            SerializerTypes.Bson,
            (sp, key) => sp.GetRequiredKeyedService<ISerializer>(key?.ToString()?.ToUpper())
            );
        services.TryAddKeyedSingleton(
            SerializerTypes.Xml,
            (sp, key) => sp.GetRequiredKeyedService<ISerializer>(key?.ToString()?.ToUpper())
            );

        services.TryAddSingleton<IJsonSerializer, DefaultJsonSerializer>();
        services.TryAddKeyedSingleton<ISerializer>(
            nameof(SerializerTypes.Json).ToUpper(),
            (sp, key) => sp.GetRequiredService<IJsonSerializer>()
            );

        services.TryAddSingleton<IBsonSerializer, DefaultBsonSerializer>();
        services.TryAddKeyedSingleton<ISerializer>(
            nameof(SerializerTypes.Bson).ToUpper(),
            (sp, key) => sp.GetRequiredService<IBsonSerializer>()
            );

        services.TryAddSingleton<IXmlSerializer, DefaultXmlSerializer>();
        services.TryAddKeyedSingleton<ISerializer>(
            nameof(SerializerTypes.Xml).ToUpper(),
            (sp, key) => sp.GetRequiredService<IXmlSerializer>()
            );

        services.TryAddSingleton(_ => DefaultJsonSerializer.DefaultOptions);
        return services;
    }

    /// <summary>
    /// Add support for shared Templating
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection TryTemplatingExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
        string configurationSection = nameof(FileTemplatingOptions)
        )
    {
        services.TryAddTransient<ITemplateEngine, TemplateEngine>();

        services.AddTransient<ITemplateSource, FileTemplateSource>();

        services.Configure<FileTemplatingOptions>(options => configuration.Bind(configurationSection, options));

        services.AddTransient<ITemplateProvider, XsltTemplateProvider>();

        //TODO: change these content types to .\Framework\Eliassen.System\Net\Mime\ContentTypes.cs
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".md", ContentType = "text/markdown", IsTemplateType = false });
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".yaml", ContentType = "text/yaml", IsTemplateType = false });

        services.AddTransient<IFileType>(_ => new FileType { Extension = ".html", ContentType = "text/html", IsTemplateType = false });
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".txt", ContentType = "text/plain", IsTemplateType = false });
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".json", ContentType = DefaultJsonSerializer.DefaultContentType, IsTemplateType = false });
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".xml", ContentType = DefaultXmlSerializer.DefaultContentType, IsTemplateType = false });

        services.AddTransient<IFileType>(_ => new FileType { Extension = ".xslt", ContentType = ContentTypesExtensions.Application.XSLT, IsTemplateType = true });

        return services;
    }
}
