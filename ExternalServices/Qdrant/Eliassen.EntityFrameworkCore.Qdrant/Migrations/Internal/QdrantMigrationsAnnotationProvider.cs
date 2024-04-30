// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.EntityFrameworkCore.Qdrant.Migrations.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantMigrationsAnnotationProvider : MigrationsAnnotationProvider
{
    /// <summary>
    ///     Initializes a new instance of this class.
    /// </summary>
    /// <param name="dependencies">Parameter object containing dependencies for this service.</param>
#pragma warning disable EF1001 // Internal EF Core API usage.
    public QdrantMigrationsAnnotationProvider(MigrationsAnnotationProviderDependencies dependencies)
#pragma warning restore EF1001 // Internal EF Core API usage.
        : base(dependencies)
    {
    }

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> ForRemove(IRelationalModel model)
        => model.GetAnnotations().Where(a => a.Name != QdrantAnnotationNames.EditionOptions);

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> ForRemove(ITable table)
        => table.GetAnnotations();

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> ForRemove(IColumn column)
    {
        if (column.Table[QdrantAnnotationNames.IsTemporal] as bool? == true)
        {
            if (column[QdrantAnnotationNames.TemporalIsPeriodStartColumn] as bool? == true)
            {
                yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodStartColumn, true);
            }

            if (column[QdrantAnnotationNames.TemporalIsPeriodEndColumn] as bool? == true)
            {
                yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodEndColumn, true);
            }
        }
    }

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> ForRename(ITable table)
    {
        if (table[QdrantAnnotationNames.IsTemporal] as bool? == true)
        {
            yield return new Annotation(QdrantAnnotationNames.IsTemporal, true);

            yield return new Annotation(
                QdrantAnnotationNames.TemporalHistoryTableName,
                table[QdrantAnnotationNames.TemporalHistoryTableName]);

            yield return new Annotation(
                QdrantAnnotationNames.TemporalHistoryTableSchema,
                table[QdrantAnnotationNames.TemporalHistoryTableSchema]);

            yield return new Annotation(
                QdrantAnnotationNames.TemporalPeriodStartColumnName,
                table[QdrantAnnotationNames.TemporalPeriodStartColumnName]);

            yield return new Annotation(
                QdrantAnnotationNames.TemporalPeriodEndColumnName,
                table[QdrantAnnotationNames.TemporalPeriodEndColumnName]);
        }
    }

    /// <inheritdoc />
    public override IEnumerable<IAnnotation> ForRename(IColumn column)
    {
        if (column[QdrantAnnotationNames.TemporalIsPeriodStartColumn] as bool? == true)
        {
            yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodStartColumn, true);
        }

        if (column[QdrantAnnotationNames.TemporalIsPeriodEndColumn] as bool? == true)
        {
            yield return new Annotation(QdrantAnnotationNames.TemporalIsPeriodEndColumn, true);
        }
    }
}
