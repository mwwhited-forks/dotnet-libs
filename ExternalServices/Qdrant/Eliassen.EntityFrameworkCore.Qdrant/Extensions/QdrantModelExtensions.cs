// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Metadata;
using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

// ReSharper disable once CheckNamespace
namespace Eliassen.EntityFrameworkCore;

/// <summary>
///     Model extension methods for SQL Server-specific metadata.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public static class QdrantModelExtensions
{
    /// <summary>
    ///     The default name for the hi-lo sequence.
    /// </summary>
    public const string DefaultHiLoSequenceName = "EntityFrameworkHiLoSequence";

    /// <summary>
    ///     The default prefix for sequences applied to properties.
    /// </summary>
    public const string DefaultSequenceNameSuffix = "Sequence";

    /// <summary>
    ///     Returns the name to use for the default hi-lo sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The name to use for the default hi-lo sequence.</returns>
    public static string GetHiLoSequenceName(this IReadOnlyModel model)
        => (string?)model[QdrantAnnotationNames.HiLoSequenceName]
            ?? DefaultHiLoSequenceName;

    /// <summary>
    ///     Sets the name to use for the default hi-lo sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="name">The value to set.</param>
    public static void SetHiLoSequenceName(this IMutableModel model, string? name)
    {
        model.SetOrRemoveAnnotation(QdrantAnnotationNames.HiLoSequenceName, name);
    }

    /// <summary>
    ///     Sets the name to use for the default hi-lo sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="name">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetHiLoSequenceName(
        this IConventionModel model,
        string? name,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceName,
            Check.NullButNotEmpty(name, nameof(name)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default hi-lo sequence name.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default hi-lo sequence name.</returns>
    public static ConfigurationSource? GetHiLoSequenceNameConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.HiLoSequenceName)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the schema to use for the default hi-lo sequence.
    ///     <see cref="QdrantPropertyBuilderExtensions.UseHiLo" />
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The schema to use for the default hi-lo sequence.</returns>
    public static string? GetHiLoSequenceSchema(this IReadOnlyModel model)
        => (string?)model[QdrantAnnotationNames.HiLoSequenceSchema];

    /// <summary>
    ///     Sets the schema to use for the default hi-lo sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetHiLoSequenceSchema(this IMutableModel model, string? value)
    {
        model.SetOrRemoveAnnotation(QdrantAnnotationNames.HiLoSequenceSchema, value);
    }

    /// <summary>
    ///     Sets the schema to use for the default hi-lo sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetHiLoSequenceSchema(
        this IConventionModel model,
        string? value,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceSchema,
            Check.NullButNotEmpty(value, nameof(value)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default hi-lo sequence schema.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default hi-lo sequence schema.</returns>
    public static ConfigurationSource? GetHiLoSequenceSchemaConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.HiLoSequenceSchema)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the suffix to append to the name of automatically created sequences.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The name to use for the default key value generation sequence.</returns>
    public static string GetSequenceNameSuffix(this IReadOnlyModel model)
        => (string?)model[QdrantAnnotationNames.SequenceNameSuffix]
            ?? DefaultSequenceNameSuffix;

    /// <summary>
    ///     Sets the suffix to append to the name of automatically created sequences.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="name">The value to set.</param>
    public static void SetSequenceNameSuffix(this IMutableModel model, string? name)
    {
        model.SetOrRemoveAnnotation(QdrantAnnotationNames.SequenceNameSuffix, name);
    }

    /// <summary>
    ///     Sets the suffix to append to the name of automatically created sequences.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="name">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetSequenceNameSuffix(
        this IConventionModel model,
        string? name,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceNameSuffix,
            Check.NullButNotEmpty(name, nameof(name)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default value generation sequence name suffix.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default key value generation sequence name.</returns>
    public static ConfigurationSource? GetSequenceNameSuffixConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.SequenceNameSuffix)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the schema to use for the default value generation sequence.
    ///     <see cref="QdrantPropertyBuilderExtensions.UseSequence" />
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The schema to use for the default key value generation sequence.</returns>
    public static string? GetSequenceSchema(this IReadOnlyModel model)
        => (string?)model[QdrantAnnotationNames.SequenceSchema];

    /// <summary>
    ///     Sets the schema to use for the default key value generation sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetSequenceSchema(this IMutableModel model, string? value)
    {
        Check.NullButNotEmpty(value, nameof(value));

        model.SetOrRemoveAnnotation(QdrantAnnotationNames.SequenceSchema, value);
    }

    /// <summary>
    ///     Sets the schema to use for the default key value generation sequence.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetSequenceSchema(
        this IConventionModel model,
        string? value,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceSchema,
            Check.NullButNotEmpty(value, nameof(value)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default key value generation sequence schema.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default key value generation sequence schema.</returns>
    public static ConfigurationSource? GetSequenceSchemaConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.SequenceSchema)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the default identity seed.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The default identity seed.</returns>
    public static long GetIdentitySeed(this IReadOnlyModel model)
    {
        if (model is RuntimeModel)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        // Support pre-6.0 IdentitySeed annotations, which contained an int rather than a long
        var annotation = model.FindAnnotation(QdrantAnnotationNames.IdentitySeed);
        return annotation is null || annotation.Value is null
            ? 1
            : annotation.Value is int intValue
                ? intValue
                : (long)annotation.Value;
    }

    /// <summary>
    ///     Sets the default identity seed.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="seed">The value to set.</param>
    public static void SetIdentitySeed(this IMutableModel model, long? seed)
        => model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentitySeed,
            seed);

    /// <summary>
    ///     Sets the default identity seed.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="seed">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static long? SetIdentitySeed(this IConventionModel model, long? seed, bool fromDataAnnotation = false)
        => (long?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentitySeed,
            seed,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default schema.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default schema.</returns>
    public static ConfigurationSource? GetIdentitySeedConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.IdentitySeed)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the default identity increment.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The default identity increment.</returns>
    public static int GetIdentityIncrement(this IReadOnlyModel model)
        => (model is RuntimeModel)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (int?)model[QdrantAnnotationNames.IdentityIncrement] ?? 1;

    /// <summary>
    ///     Sets the default identity increment.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="increment">The value to set.</param>
    public static void SetIdentityIncrement(this IMutableModel model, int? increment)
        => model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentityIncrement,
            increment);

    /// <summary>
    ///     Sets the default identity increment.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="increment">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static int? SetIdentityIncrement(
        this IConventionModel model,
        int? increment,
        bool fromDataAnnotation = false)
        => (int?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentityIncrement,
            increment,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default identity increment.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default identity increment.</returns>
    public static ConfigurationSource? GetIdentityIncrementConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.IdentityIncrement)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="QdrantValueGenerationStrategy" /> to use for properties
    ///     of keys in the model, unless the property has a strategy explicitly set.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The default <see cref="QdrantValueGenerationStrategy" />.</returns>
    public static QdrantValueGenerationStrategy? GetValueGenerationStrategy(this IReadOnlyModel model)
        => (QdrantValueGenerationStrategy?)model[QdrantAnnotationNames.ValueGenerationStrategy];

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for properties
    ///     of keys in the model that don't have a strategy explicitly set.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetValueGenerationStrategy(
        this IMutableModel model,
        QdrantValueGenerationStrategy? value)
        => model.SetOrRemoveAnnotation(QdrantAnnotationNames.ValueGenerationStrategy, value);

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for properties
    ///     of keys in the model that don't have a strategy explicitly set.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static QdrantValueGenerationStrategy? SetValueGenerationStrategy(
        this IConventionModel model,
        QdrantValueGenerationStrategy? value,
        bool fromDataAnnotation = false)
        => (QdrantValueGenerationStrategy?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.ValueGenerationStrategy,
            value,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the default <see cref="QdrantValueGenerationStrategy" />.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the default <see cref="QdrantValueGenerationStrategy" />.</returns>
    public static ConfigurationSource? GetValueGenerationStrategyConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the maximum size of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The maximum size of the database.</returns>
    public static string? GetDatabaseMaxSize(this IReadOnlyModel model)
        => (model is RuntimeModel)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (string?)model[QdrantAnnotationNames.MaxDatabaseSize];

    /// <summary>
    ///     Sets the maximum size of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetDatabaseMaxSize(this IMutableModel model, string? value)
        => model.SetOrRemoveAnnotation(QdrantAnnotationNames.MaxDatabaseSize, value);

    /// <summary>
    ///     Sets the maximum size of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetDatabaseMaxSize(
        this IConventionModel model,
        string? value,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.MaxDatabaseSize,
            value,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the maximum size of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the maximum size of the database.</returns>
    public static ConfigurationSource? GetDatabaseMaxSizeConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.MaxDatabaseSize)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the service tier of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The service tier of the database.</returns>
    public static string? GetServiceTierSql(this IReadOnlyModel model)
        => (model is RuntimeModel)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (string?)model[QdrantAnnotationNames.ServiceTierSql];

    /// <summary>
    ///     Sets the service tier of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetServiceTierSql(this IMutableModel model, string? value)
        => model.SetOrRemoveAnnotation(QdrantAnnotationNames.ServiceTierSql, value);

    /// <summary>
    ///     Sets the service tier of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetServiceTierSql(
        this IConventionModel model,
        string? value,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.ServiceTierSql,
            value,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the service tier of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the service tier of the database.</returns>
    public static ConfigurationSource? GetServiceTierSqlConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.ServiceTierSql)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the performance level of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The performance level of the database.</returns>
    public static string? GetPerformanceLevelSql(this IReadOnlyModel model)
        => (model is RuntimeModel)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (string?)model[QdrantAnnotationNames.PerformanceLevelSql];

    /// <summary>
    ///     Sets the performance level of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    public static void SetPerformanceLevelSql(this IMutableModel model, string? value)
        => model.SetOrRemoveAnnotation(QdrantAnnotationNames.PerformanceLevelSql, value);

    /// <summary>
    ///     Sets the performance level of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="value">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetPerformanceLevelSql(
        this IConventionModel model,
        string? value,
        bool fromDataAnnotation = false)
        => (string?)model.SetOrRemoveAnnotation(
            QdrantAnnotationNames.PerformanceLevelSql,
            value,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the performance level of the database.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the performance level of the database.</returns>
    public static ConfigurationSource? GetPerformanceLevelSqlConfigurationSource(this IConventionModel model)
        => model.FindAnnotation(QdrantAnnotationNames.PerformanceLevelSql)?.GetConfigurationSource();
}
