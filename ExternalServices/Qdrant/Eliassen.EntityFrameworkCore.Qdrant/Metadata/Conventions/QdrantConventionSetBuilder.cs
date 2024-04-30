// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable once CheckNamespace

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.EntityFrameworkCore.Metadata.Conventions;

/// <summary>
///     A builder for building conventions for SQL Server.
/// </summary>
/// <remarks>
///     <para>
///         The service lifetime is <see cref="ServiceLifetime.Scoped" /> and multiple registrations
///         are allowed. This means that each <see cref="DbContext" /> instance will use its own
///         set of instances of this service.
///         The implementations may depend on other services registered with any lifetime.
///         The implementations do not need to be thread-safe.
///     </para>
///     <para>
///         See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see>, and
///         <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///         for more information and examples.
///     </para>
/// </remarks>
public class QdrantConventionSetBuilder : RelationalConventionSetBuilder
{
    private readonly ISqlGenerationHelper _sqlGenerationHelper;

    /// <summary>
    ///     Creates a new <see cref="QdrantConventionSetBuilder" /> instance.
    /// </summary>
    /// <param name="dependencies">The core dependencies for this service.</param>
    /// <param name="relationalDependencies">The relational dependencies for this service.</param>
    /// <param name="sqlGenerationHelper">The SQL generation helper to use.</param>
    public QdrantConventionSetBuilder(
        ProviderConventionSetBuilderDependencies dependencies,
        RelationalConventionSetBuilderDependencies relationalDependencies,
        ISqlGenerationHelper sqlGenerationHelper)
        : base(dependencies, relationalDependencies)
    {
        _sqlGenerationHelper = sqlGenerationHelper;
    }

    /// <summary>
    ///     Builds and returns the convention set for the current database provider.
    /// </summary>
    /// <returns>The convention set for the current database provider.</returns>
    public override ConventionSet CreateConventionSet()
    {
        var conventionSet = base.CreateConventionSet();

        conventionSet.Add(new QdrantValueGenerationStrategyConvention(Dependencies, RelationalDependencies));
        conventionSet.Add(new RelationalMaxIdentifierLengthConvention(128, Dependencies, RelationalDependencies));
        conventionSet.Add(new QdrantIndexConvention(Dependencies, RelationalDependencies, _sqlGenerationHelper));
        conventionSet.Add(new QdrantMemoryOptimizedTablesConvention(Dependencies, RelationalDependencies));
        conventionSet.Add(new QdrantDbFunctionConvention(Dependencies, RelationalDependencies));
        conventionSet.Add(new QdrantOutputClauseConvention(Dependencies, RelationalDependencies));

        conventionSet.Replace<CascadeDeleteConvention>(
            new QdrantOnDeleteConvention(Dependencies, RelationalDependencies));
        conventionSet.Replace<StoreGenerationConvention>(
            new QdrantStoreGenerationConvention(Dependencies, RelationalDependencies));
        conventionSet.Replace<ValueGenerationConvention>(
            new QdrantValueGenerationConvention(Dependencies, RelationalDependencies));
        conventionSet.Replace<RuntimeModelConvention>(new QdrantRuntimeModelConvention(Dependencies, RelationalDependencies));
        conventionSet.Replace<SharedTableConvention>(
            new QdrantSharedTableConvention(Dependencies, RelationalDependencies));

        var QdrantTemporalConvention = new QdrantTemporalConvention(Dependencies, RelationalDependencies);
        ConventionSet.AddBefore(
            conventionSet.EntityTypeAnnotationChangedConventions,
            QdrantTemporalConvention,
            typeof(QdrantValueGenerationConvention));
        conventionSet.SkipNavigationForeignKeyChangedConventions.Add(QdrantTemporalConvention);
        conventionSet.ModelFinalizingConventions.Add(QdrantTemporalConvention);

        return conventionSet;
    }

    /// <summary>
    ///     Call this method to build a <see cref="ConventionSet" /> for SQL Server when using
    ///     the <see cref="ModelBuilder" /> outside of <see cref="DbContext.OnModelCreating" />.
    /// </summary>
    /// <remarks>
    ///     Note that it is unusual to use this method. Consider using <see cref="DbContext" /> in the normal way instead.
    /// </remarks>
    /// <returns>The convention set.</returns>
    public static ConventionSet Build()
    {
        using var serviceScope = CreateServiceScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<DbContext>();
        return ConventionSet.CreateConventionSet(context);
    }

    /// <summary>
    ///     Call this method to build a <see cref="ModelBuilder" /> for SQL Server outside of <see cref="DbContext.OnModelCreating" />.
    /// </summary>
    /// <remarks>
    ///     Note that it is unusual to use this method. Consider using <see cref="DbContext" /> in the normal way instead.
    /// </remarks>
    /// <returns>The convention set.</returns>
    public static ModelBuilder CreateModelBuilder()
    {
        using var serviceScope = CreateServiceScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<DbContext>();
        return new ModelBuilder(ConventionSet.CreateConventionSet(context), context.GetService<ModelDependencies>());
    }

    private static IServiceScope CreateServiceScope()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkQdrant()
            .AddDbContext<DbContext>(
                (p, o) =>
                    o.UseQdrant("Server=.")
                        .UseInternalServiceProvider(p))
            .BuildServiceProvider();

        return serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
    }
}
