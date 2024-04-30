using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eliassen.EntityFrameworkCore.Qdrant;

public static class QdrantDbServiceCollectionExtensions
{
    public static IServiceCollection AddQdrant<TContext>(
        this IServiceCollection serviceCollection,
        string? connectionString,
        Action<QdrantDbContextOptionsBuilder>? qdrantOptionsAction = null,
        Action<DbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
        => serviceCollection.AddDbContext<TContext>(
            (_, options) =>
            {
                optionsAction?.Invoke(options);
                options.UseQdrant(connectionString, qdrantOptionsAction);
            });


    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IServiceCollection AddEntityFrameworkQdrant(this IServiceCollection serviceCollection)
    {
        new EntityFrameworkRelationalServicesBuilder(serviceCollection)
            .TryAdd<LoggingDefinitions, QdrantLoggingDefinitions>()
            .TryAdd<IDatabaseProvider, DatabaseProvider<QdrantOptionsExtension>>()
            .TryAdd<IValueGeneratorCache>(p => p.GetRequiredService<IQdrantValueGeneratorCache>())
            .TryAdd<IRelationalTypeMappingSource, QdrantTypeMappingSource>()
            .TryAdd<ISqlGenerationHelper, QdrantSqlGenerationHelper>()
            .TryAdd<IRelationalAnnotationProvider, QdrantAnnotationProvider>()
            .TryAdd<IMigrationsAnnotationProvider, QdrantMigrationsAnnotationProvider>()
            .TryAdd<IModelValidator, QdrantModelValidator>()
            .TryAdd<IProviderConventionSetBuilder, QdrantConventionSetBuilder>()
            .TryAdd<IUpdateSqlGenerator>(p => p.GetRequiredService<IQdrantUpdateSqlGenerator>())
            .TryAdd<IEvaluatableExpressionFilter, QdrantEvaluatableExpressionFilter>()
            .TryAdd<IRelationalTransactionFactory, QdrantTransactionFactory>()
            .TryAdd<IModificationCommandBatchFactory, QdrantModificationCommandBatchFactory>()
            .TryAdd<IModificationCommandFactory, QdrantModificationCommandFactory>()
            .TryAdd<IValueGeneratorSelector, QdrantValueGeneratorSelector>()
            .TryAdd<IRelationalConnection>(p => p.GetRequiredService<IQdrantConnection>())
            .TryAdd<IMigrationsSqlGenerator, QdrantMigrationsSqlGenerator>()
            .TryAdd<IRelationalDatabaseCreator, QdrantDatabaseCreator>()
            .TryAdd<IHistoryRepository, QdrantHistoryRepository>()
            .TryAdd<IExecutionStrategyFactory, QdrantExecutionStrategyFactory>()
            .TryAdd<IRelationalQueryStringFactory, QdrantQueryStringFactory>()
            .TryAdd<ICompiledQueryCacheKeyGenerator, QdrantCompiledQueryCacheKeyGenerator>()
            .TryAdd<IQueryCompilationContextFactory, QdrantQueryCompilationContextFactory>()
            .TryAdd<IMethodCallTranslatorProvider, QdrantMethodCallTranslatorProvider>()
            .TryAdd<IAggregateMethodCallTranslatorProvider, QdrantAggregateMethodCallTranslatorProvider>()
            .TryAdd<IMemberTranslatorProvider, QdrantMemberTranslatorProvider>()
            .TryAdd<IQuerySqlGeneratorFactory, QdrantQuerySqlGeneratorFactory>()
            .TryAdd<IRelationalSqlTranslatingExpressionVisitorFactory, QdrantSqlTranslatingExpressionVisitorFactory>()
            .TryAdd<ISqlExpressionFactory, QdrantSqlExpressionFactory>()
            .TryAdd<IQueryTranslationPostprocessorFactory, QdrantQueryTranslationPostprocessorFactory>()
            .TryAdd<IRelationalParameterBasedSqlProcessorFactory, QdrantParameterBasedSqlProcessorFactory>()
            .TryAdd<INavigationExpansionExtensibilityHelper, QdrantNavigationExpansionExtensibilityHelper>()
            .TryAdd<IQueryableMethodTranslatingExpressionVisitorFactory, QdrantQueryableMethodTranslatingExpressionVisitorFactory>()
            .TryAdd<IExceptionDetector, QdrantExceptionDetector>()
            .TryAdd<ISingletonOptions, IQdrantSingletonOptions>(p => p.GetRequiredService<IQdrantSingletonOptions>())
            .TryAddProviderSpecificServices(
                b => b
                    .TryAddSingleton<IQdrantSingletonOptions, QdrantSingletonOptions>()
                    .TryAddSingleton<IQdrantValueGeneratorCache, QdrantValueGeneratorCache>()
                    .TryAddSingleton<IQdrantUpdateSqlGenerator, QdrantUpdateSqlGenerator>()
                    .TryAddSingleton<IQdrantSequenceValueGeneratorFactory, QdrantSequenceValueGeneratorFactory>()
                    .TryAddScoped<IQdrantConnection, QdrantConnection>())
            .TryAddCoreServices();

        return serviceCollection;
    }
}
