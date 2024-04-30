// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Infrastructure;
using Eliassen.EntityFrameworkCore.Metadata.Conventions;
using Eliassen.EntityFrameworkCore.Migrations;
using Eliassen.EntityFrameworkCore.Qdrant.Diagnostics.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Infrastructure.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Migrations.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Storage.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Update.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.ComponentModel;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     SQL Server specific extension methods for <see cref="IServiceCollection" />.
/// </summary>
public static class QdrantServiceCollectionExtensions
{
    /// <summary>
    ///     Registers the given Entity Framework <see cref="DbContext" /> as a service in the <see cref="IServiceCollection" />
    ///     and configures it to connect to a SQL Server database.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method is a shortcut for configuring a <see cref="DbContext" /> to use SQL Server. It does not support all options.
    ///         Use <see cref="O:EntityFrameworkServiceCollectionExtensions.AddDbContext" /> and related methods for full control of
    ///         this process.
    ///     </para>
    ///     <para>
    ///         Use this method when using dependency injection in your application, such as with ASP.NET Core.
    ///         For applications that don't use dependency injection, consider creating <see cref="DbContext" />
    ///         instances directly with its constructor. The <see cref="DbContext.OnConfiguring" /> method can then be
    ///         overridden to configure the SQL Server provider and connection string.
    ///     </para>
    ///     <para>
    ///         To configure the <see cref="DbContextOptions{TContext}" /> for the context, either override the
    ///         <see cref="DbContext.OnConfiguring" /> method in your derived context, or supply
    ///         an optional action to configure the <see cref="DbContextOptions" /> for the context.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-di">Using DbContext with dependency injection</see> for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-dbcontext-options">Using DbContextOptions</see>, and
    ///         <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TContext">The type of context to be registered.</typeparam>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="connectionString">The connection string of the database to connect to.</param>
    /// <param name="QdrantOptionsAction">An optional action to allow additional SQL Server specific configuration.</param>
    /// <param name="optionsAction">An optional action to configure the <see cref="DbContextOptions" /> for the context.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddQdrant<TContext>(
        this IServiceCollection serviceCollection,
        string? connectionString,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null,
        Action<DbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
        => serviceCollection.AddDbContext<TContext>(
            (_, options) =>
            {
                optionsAction?.Invoke(options);
                options.UseQdrant(connectionString, QdrantOptionsAction);
            });

    /// <summary>
    ///     <para>
    ///         Adds the services required by the Microsoft SQL Server database provider for Entity Framework
    ///         to an <see cref="IServiceCollection" />.
    ///     </para>
    ///     <para>
    ///         Warning: Do not call this method accidentally. It is much more likely you need
    ///         to call <see cref="AddQdrant{TContext}" />.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     Calling this method is no longer necessary when building most applications, including those that
    ///     use dependency injection in ASP.NET or elsewhere.
    ///     It is only needed when building the internal service provider for use with
    ///     the <see cref="DbContextOptionsBuilder.UseInternalServiceProvider" /> method.
    ///     This is not recommend other than for some advanced scenarios.
    /// </remarks>
    /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>
    ///     The same service collection so that multiple calls can be chained.
    /// </returns>
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
