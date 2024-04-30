
using Eliassen.EntityFrameworkCore.Diagnostics;
using Eliassen.EntityFrameworkCore.Infrastructure;
using Eliassen.EntityFrameworkCore.Qdrant.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data.Common;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantDbContextOptionsExtensions
{
    public static DbContextOptionsBuilder UseQdrant(
        this DbContextOptionsBuilder optionsBuilder,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
    {
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(GetOrCreateExtension(optionsBuilder));

        return ApplyConfiguration(optionsBuilder, QdrantOptionsAction);
    }

    public static DbContextOptionsBuilder UseQdrant(
        this DbContextOptionsBuilder optionsBuilder,
        string? connectionString,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
    {
        var extension = (QdrantOptionsExtension)GetOrCreateExtension(optionsBuilder).WithConnectionString(connectionString);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        return ApplyConfiguration(optionsBuilder, QdrantOptionsAction);
    }

    public static DbContextOptionsBuilder UseQdrant(
        this DbContextOptionsBuilder optionsBuilder,
        DbConnection connection,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
        => UseQdrant(optionsBuilder, connection, false, QdrantOptionsAction);

    public static DbContextOptionsBuilder UseQdrant(
        this DbContextOptionsBuilder optionsBuilder,
        DbConnection connection,
        bool contextOwnsConnection,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
    {
        var extension = (QdrantOptionsExtension)GetOrCreateExtension(optionsBuilder).WithConnection(connection, contextOwnsConnection);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        return ApplyConfiguration(optionsBuilder, QdrantOptionsAction);
    }

    public static DbContextOptionsBuilder<TContext> UseQdrant<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseQdrant(
            (DbContextOptionsBuilder)optionsBuilder, QdrantOptionsAction);


    public static DbContextOptionsBuilder<TContext> UseQdrant<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        string? connectionString,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseQdrant(
            (DbContextOptionsBuilder)optionsBuilder, connectionString, QdrantOptionsAction);

    public static DbContextOptionsBuilder<TContext> UseQdrant<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        DbConnection connection,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseQdrant(
            (DbContextOptionsBuilder)optionsBuilder, connection, QdrantOptionsAction);

    public static DbContextOptionsBuilder<TContext> UseQdrant<TContext>(
        this DbContextOptionsBuilder<TContext> optionsBuilder,
        DbConnection connection,
        bool contextOwnsConnection,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseQdrant(
            (DbContextOptionsBuilder)optionsBuilder, connection, contextOwnsConnection, QdrantOptionsAction);

    private static QdrantOptionsExtension GetOrCreateExtension(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.Options.FindExtension<QdrantOptionsExtension>()
            ?? new QdrantOptionsExtension();

    private static DbContextOptionsBuilder ApplyConfiguration(
        DbContextOptionsBuilder optionsBuilder,
        Action<QdrantDbContextOptionsBuilder>? QdrantOptionsAction)
    {
        ConfigureWarnings(optionsBuilder);

        QdrantOptionsAction?.Invoke(new QdrantDbContextOptionsBuilder(optionsBuilder));

        var extension = (QdrantOptionsExtension)GetOrCreateExtension(optionsBuilder).ApplyDefaults(optionsBuilder.Options);
        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

        return optionsBuilder;
    }

    private static void ConfigureWarnings(DbContextOptionsBuilder optionsBuilder)
    {
        var coreOptionsExtension
            = optionsBuilder.Options.FindExtension<CoreOptionsExtension>()
            ?? new CoreOptionsExtension();

        coreOptionsExtension = RelationalOptionsExtension.WithDefaultWarningConfiguration(coreOptionsExtension);

        coreOptionsExtension = coreOptionsExtension.WithWarningsConfiguration(
            coreOptionsExtension.WarningsConfiguration.TryWithExplicit(
                QdrantEventId.ConflictingValueGenerationStrategiesWarning, WarningBehavior.Throw));

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(coreOptionsExtension);
    }
}
