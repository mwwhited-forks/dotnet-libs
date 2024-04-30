﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantAnnotationProvider : RelationalAnnotationProvider
{
    /// <summary>
    ///     Initializes a new instance of this class.
    /// </summary>
    /// <param name="dependencies">Parameter object containing dependencies for this service.</param>
    public QdrantAnnotationProvider(RelationalAnnotationProviderDependencies dependencies)
        : base(dependencies)
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IEnumerable<IAnnotation> For(IRelationalModel model, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        var maxSize = model.Model.GetDatabaseMaxSize();
        var serviceTier = model.Model.GetServiceTierSql();
        var performanceLevel = model.Model.GetPerformanceLevelSql();
        if (maxSize != null
            || serviceTier != null
            || performanceLevel != null)
        {
            var options = new StringBuilder();

            if (maxSize != null)
            {
                options.Append("MAXSIZE = ");
                options.Append(maxSize);
                options.Append(", ");
            }

            if (serviceTier != null)
            {
                options.Append("EDITION = ");
                options.Append(serviceTier);
                options.Append(", ");
            }

            if (performanceLevel != null)
            {
                options.Append("SERVICE_OBJECTIVE = ");
                options.Append(performanceLevel);
                options.Append(", ");
            }

            options.Remove(options.Length - 2, 2);

            yield return new Annotation(QdrantAnnotationNames.EditionOptions, options.ToString());
        }

        if (model.Tables.Any(t => !t.IsExcludedFromMigrations && (t[QdrantAnnotationNames.MemoryOptimized] as bool? == true)))
        {
            yield return new Annotation(QdrantAnnotationNames.MemoryOptimized, true);
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IEnumerable<IAnnotation> For(ITable table, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        var entityType = (IEntityType)table.EntityTypeMappings.First().TypeBase;

        // Model validation ensures that these facets are the same on all mapped entity types
        if (entityType.IsMemoryOptimized())
        {
            yield return new Annotation(QdrantAnnotationNames.MemoryOptimized, true);
        }

        if (entityType.IsTemporal())
        {
            yield return new Annotation(QdrantAnnotationNames.IsTemporal, true);
            yield return new Annotation(QdrantAnnotationNames.TemporalHistoryTableName, entityType.GetHistoryTableName());
            yield return new Annotation(QdrantAnnotationNames.TemporalHistoryTableSchema, entityType.GetHistoryTableSchema());

            // for the RevEng path, we avoid adding period properties to the entity
            // because we don't want code for them to be generated - they need to be in shadow state
            // so if we don't find property on the entity, we know it's this scenario
            // and in that case period column name is actually the same as the period property name annotation
            // since in RevEng scenario there can't be custom column mapping
            // see #26007
            var storeObjectIdentifier = StoreObjectIdentifier.Table(table.Name, table.Schema);
            var periodStartPropertyName = entityType.GetPeriodStartPropertyName();
            if (periodStartPropertyName != null)
            {
                var periodStartProperty = entityType.FindProperty(periodStartPropertyName);
                var periodStartColumnName = periodStartProperty != null
                    ? periodStartProperty.GetColumnName(storeObjectIdentifier)
                    : periodStartPropertyName;

                yield return new Annotation(QdrantAnnotationNames.TemporalPeriodStartColumnName, periodStartColumnName);
            }

            var periodEndPropertyName = entityType.GetPeriodEndPropertyName();
            if (periodEndPropertyName != null)
            {
                var periodEndProperty = entityType.FindProperty(periodEndPropertyName);
                var periodEndColumnName = periodEndProperty != null
                    ? periodEndProperty.GetColumnName(storeObjectIdentifier)
                    : periodEndPropertyName;

                yield return new Annotation(QdrantAnnotationNames.TemporalPeriodEndColumnName, periodEndColumnName);
            }
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IEnumerable<IAnnotation> For(IUniqueConstraint constraint, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        // Model validation ensures that these facets are the same on all mapped keys
        var key = constraint.MappedKeys.First();

        var table = constraint.Table;

        if (key.IsClustered(StoreObjectIdentifier.Table(table.Name, table.Schema)) is bool isClustered)
        {
            yield return new Annotation(QdrantAnnotationNames.Clustered, isClustered);
        }

        if (key.GetFillFactor() is int fillFactor)
        {
            yield return new Annotation(QdrantAnnotationNames.FillFactor, fillFactor);
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IEnumerable<IAnnotation> For(ITableIndex index, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        // Model validation ensures that these facets are the same on all mapped indexes
        var modelIndex = index.MappedIndexes.First();
        var table = StoreObjectIdentifier.Table(index.Table.Name, index.Table.Schema);
        if (modelIndex.IsClustered(table) is bool isClustered)
        {
            yield return new Annotation(QdrantAnnotationNames.Clustered, isClustered);
        }

        if (modelIndex.GetIncludeProperties(table) is IReadOnlyList<string> includeProperties)
        {
            var includeColumns = includeProperties
                .Select(
                    p => modelIndex.DeclaringEntityType.FindProperty(p)!
                        .GetColumnName(StoreObjectIdentifier.Table(table.Name, table.Schema)))
                .ToArray();

            yield return new Annotation(
                QdrantAnnotationNames.Include,
                includeColumns);
        }

        if (modelIndex.IsCreatedOnline(table) is bool isOnline)
        {
            yield return new Annotation(QdrantAnnotationNames.CreatedOnline, isOnline);
        }

        if (modelIndex.GetFillFactor(table) is int fillFactor)
        {
            yield return new Annotation(QdrantAnnotationNames.FillFactor, fillFactor);
        }

        if (modelIndex.GetSortInTempDb(table) is bool sortInTempDb)
        {
            yield return new Annotation(QdrantAnnotationNames.SortInTempDb, sortInTempDb);
        }

        if (modelIndex.GetDataCompression(table) is DataCompressionType dataCompressionType)
        {
            yield return new Annotation(QdrantAnnotationNames.DataCompression, dataCompressionType);
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override IEnumerable<IAnnotation> For(IColumn column, bool designTime)
    {
        if (!designTime)
        {
            yield break;
        }

        var table = StoreObjectIdentifier.Table(column.Table.Name, column.Table.Schema);
        var identityProperty = column.PropertyMappings
            .Select(m => m.Property)
            .FirstOrDefault(
                p => p.GetValueGenerationStrategy(table)
                    == QdrantValueGenerationStrategy.IdentityColumn);
        if (identityProperty != null)
        {
            var seed = identityProperty.GetIdentitySeed(table);
            var increment = identityProperty.GetIdentityIncrement(table);

            yield return new Annotation(
                QdrantAnnotationNames.Identity,
                string.Format(CultureInfo.InvariantCulture, "{0}, {1}", seed ?? 1, increment ?? 1));
        }

        // JSON columns have no property mappings so all annotations that rely on property mappings should be skipped for them
        if (column is not JsonColumn
            && column.PropertyMappings.FirstOrDefault()?.Property.IsSparse() is bool isSparse)
        {
            // Model validation ensures that these facets are the same on all mapped properties
            yield return new Annotation(QdrantAnnotationNames.Sparse, isSparse);
        }

        var entityType = (IEntityType)column.Table.EntityTypeMappings.First().TypeBase;
        if (entityType.IsTemporal())
        {
            var periodStartPropertyName = entityType.GetPeriodStartPropertyName();
            var periodEndPropertyName = entityType.GetPeriodEndPropertyName();
            var storeObjectIdentifier = StoreObjectIdentifier.Table(table.Name, table.Schema);

            // for the RevEng path, we avoid adding period properties to the entity
            // because we don't want code for them to be generated - they need to be in shadow state
            // so if we don't find property on the entity, we know it's this scenario
            // and in that case period column name is actually the same as the period property name annotation
            // since in RevEng scenario there can't be custom column mapping
            // see #26007
            var periodStartProperty = entityType.FindProperty(periodStartPropertyName!);
            var periodStartColumnName = periodStartProperty != null
                ? periodStartProperty.GetColumnName(storeObjectIdentifier)
                : periodStartPropertyName;

            var periodEndProperty = entityType.FindProperty(periodEndPropertyName!);
            var periodEndColumnName = periodEndProperty != null
                ? periodEndProperty.GetColumnName(storeObjectIdentifier)
                : periodEndPropertyName;

            if (column.Name == periodStartColumnName)
            {
                yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodStartColumn, true);
            }
            else if (column.Name == periodEndColumnName)
            {
                yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodEndColumn, true);
            }
        }
    }
}
