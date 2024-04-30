// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System.Collections.Generic;

namespace Eliassen.EntityFrameworkCore.Metadata.Conventions;

/// <summary>
///     A convention that creates an optimized copy of the mutable model.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public class QdrantRuntimeModelConvention : RelationalRuntimeModelConvention
{
    /// <summary>
    ///     Creates a new instance of <see cref="QdrantRuntimeModelConvention" />.
    /// </summary>
    /// <param name="dependencies">Parameter object containing dependencies for this convention.</param>
    /// <param name="relationalDependencies"> Parameter object containing relational dependencies for this convention.</param>
    public QdrantRuntimeModelConvention(
        ProviderConventionSetBuilderDependencies dependencies,
        RelationalConventionSetBuilderDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    /// <inheritdoc />
    protected override void ProcessModelAnnotations(
        Dictionary<string, object?> annotations,
        IModel model,
        RuntimeModel runtimeModel,
        bool runtime)
    {
        base.ProcessModelAnnotations(annotations, model, runtimeModel, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
            annotations.Remove(QdrantAnnotationNames.MaxDatabaseSize);
            annotations.Remove(QdrantAnnotationNames.PerformanceLevelSql);
            annotations.Remove(QdrantAnnotationNames.ServiceTierSql);
        }
    }

    /// <inheritdoc />
    protected override void ProcessPropertyAnnotations(
        Dictionary<string, object?> annotations,
        IProperty property,
        RuntimeProperty runtimeProperty,
        bool runtime)
    {
        base.ProcessPropertyAnnotations(annotations, property, runtimeProperty, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
            annotations.Remove(QdrantAnnotationNames.Sparse);

            if (!annotations.ContainsKey(QdrantAnnotationNames.ValueGenerationStrategy))
            {
                annotations[QdrantAnnotationNames.ValueGenerationStrategy] = property.GetValueGenerationStrategy();
            }
        }
    }

    /// <inheritdoc />
    protected override void ProcessPropertyOverridesAnnotations(
        Dictionary<string, object?> annotations,
        IRelationalPropertyOverrides propertyOverrides,
        RuntimeRelationalPropertyOverrides runtimePropertyOverrides,
        bool runtime)
    {
        base.ProcessPropertyOverridesAnnotations(annotations, propertyOverrides, runtimePropertyOverrides, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
        }
    }

    /// <inheritdoc />
    protected override void ProcessIndexAnnotations(
        Dictionary<string, object?> annotations,
        IIndex index,
        RuntimeIndex runtimeIndex,
        bool runtime)
    {
        base.ProcessIndexAnnotations(annotations, index, runtimeIndex, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.CreatedOnline);
            annotations.Remove(QdrantAnnotationNames.Include);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
            annotations.Remove(QdrantAnnotationNames.SortInTempDb);
            annotations.Remove(QdrantAnnotationNames.DataCompression);
        }
    }

    /// <inheritdoc />
    protected override void ProcessKeyAnnotations(
        Dictionary<string, object?> annotations,
        IKey key,
        RuntimeKey runtimeKey,
        bool runtime)
    {
        base.ProcessKeyAnnotations(annotations, key, runtimeKey, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
        }
    }

    /// <inheritdoc />
    protected override void ProcessEntityTypeAnnotations(
        Dictionary<string, object?> annotations,
        IEntityType entityType,
        RuntimeEntityType runtimeEntityType,
        bool runtime)
    {
        base.ProcessEntityTypeAnnotations(annotations, entityType, runtimeEntityType, runtime);

        if (!runtime)
        {
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableName);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableSchema);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodEndColumnName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodEndPropertyName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodStartColumnName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodStartPropertyName);
        }
    }
}
