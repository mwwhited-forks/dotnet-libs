using Eliassen.System.Accessors;
using Eliassen.System.Configuration;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Linq.Search;
using Eliassen.System.Security.Cryptography;
using Eliassen.System.Text.Templating;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel;
using System.Linq;

namespace Eliassen.System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection TryAllSystemExtensions(this IServiceCollection services, IConfiguration config) =>
            services
            .TryAddSearchQueryExtensions()
            .TrySecurityExtensions()
            .TryTemplatingExtensions(config)
            ;

        public static IServiceCollection TryAddSearchQueryExtensions(this IServiceCollection services)
        {
            services.TryAddSingleton(typeof(IQueryBuilder<>), typeof(QueryBuilder<>));
            services.TryAddSingleton(typeof(ISortBuilder<>), typeof(SortBuilder<>));
            services.TryAddSingleton(typeof(IExpressionTreeBuilder<>), typeof(ExpressionTreeBuilder<>));
            services.TryAddTransient<IPostBuildExpressionVisitor, StringComparisonReplacementExpressionVisitor>();
            return services;
        }

        public static IServiceCollection TrySecurityExtensions(this IServiceCollection services)
        {
            services.TryAddTransient<IHash, Hash>();
            return services;
        }

        public static IServiceCollection TryTemplatingExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.TryAddTransient<ITemplateEngine, TemplateEngine>();

            services.AddTransient<ITemplateSource, FileTemplateSource>();
            services.AddConfiguration<FileTemplatingSettings>(config);

            services.AddTransient<ITemplateProvider, XsltTemplateProvider>();

            services.AddTransient<IFileType>(_ => new FileType { Extension = ".md", ContentType = "text/markdown", IsTemplateType = false });
            services.AddTransient<IFileType>(_ => new FileType { Extension = ".yaml", ContentType = "text/yaml", IsTemplateType = false });

            services.AddTransient<IFileType>(_ => new FileType { Extension = ".html", ContentType = "text/html", IsTemplateType = false });
            services.AddTransient<IFileType>(_ => new FileType { Extension = ".txt", ContentType = "text/plain", IsTemplateType = false });
            services.AddTransient<IFileType>(_ => new FileType { Extension = ".json", ContentType = "text/json", IsTemplateType = false });
            services.AddTransient<IFileType>(_ => new FileType { Extension = ".xml", ContentType = "text/xml", IsTemplateType = false });

            services.AddTransient<IFileType>(_ => new FileType { Extension = ".xslt", ContentType = XsltTemplateProvider.ContentType, IsTemplateType = true });

            return services;
        }

        public static IServiceCollection AddAccessor<TService>(this IServiceCollection services)
            where TService : class
        {
            services.TryAddSingleton(typeof(IAccessor<>), typeof(Accessor<>));
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning disable CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
            services.TryAddTransient(sp => sp.GetRequiredService<IAccessor<TService>>().Value);
#pragma warning restore CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

            return services;
        }

        public static IServiceCollection AddConfiguration<TConfig>(
            this IServiceCollection services,
            IConfiguration config
            )
            where TConfig : class
        {
            var section = TypeDescriptor.GetAttributes(typeof(TConfig))
                .OfType<ConfigurationSectionAttribute>()
                .FirstOrDefault()?.ConfigurationSection ?? typeof(TConfig).Name;
            services.Configure<TConfig>(config.GetSection(section));
            return services;
        }

        public static IServiceCollection GetSingletonInstance<TService, TInstance>(this IServiceCollection services, out TInstance instance)
            where TService : class
            where TInstance : class, TService, new()
        {
            instance = (services.FirstOrDefault(i => i.ServiceType == typeof(TService))?.ImplementationInstance as TInstance) ?? new TInstance();
            services.Replace(ServiceDescriptor.Singleton<TService>(instance));
            return services;
        }
    }
}
