using Eliassen.EntityFrameworkCore.Metadata;
using Eliassen.EntityFrameworkCore.Metadata.Builders;
using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Eliassen.EntityFrameworkCore.Qdrant.Design.Internal;

public class QdrantAnnotationCodeGenerator : AnnotationCodeGenerator
{
    #region MethodInfos

    private static readonly MethodInfo ModelUseIdentityColumnsMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.UseIdentityColumns), [typeof(ModelBuilder), typeof(long), typeof(int)])!;

    private static readonly MethodInfo ModelUseHiLoMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.UseHiLo), [typeof(ModelBuilder), typeof(string), typeof(string)])!;

    private static readonly MethodInfo ModelUseKeySequencesMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.UseKeySequences), [typeof(ModelBuilder), typeof(string), typeof(string)])!;

    private static readonly MethodInfo ModelHasDatabaseMaxSizeMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.HasDatabaseMaxSize), [typeof(ModelBuilder), typeof(string)])!;

    private static readonly MethodInfo ModelHasServiceTierSqlMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.HasServiceTierSql), [typeof(ModelBuilder), typeof(string)])!;

    private static readonly MethodInfo ModelHasPerformanceLevelSqlMethodInfo
        = typeof(QdrantModelBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantModelBuilderExtensions.HasPerformanceLevelSql), [typeof(ModelBuilder), typeof(string)])!;

    private static readonly MethodInfo ModelHasAnnotationMethodInfo
        = typeof(ModelBuilder).GetRuntimeMethod(
            nameof(ModelBuilder.HasAnnotation), [typeof(string), typeof(object)])!;

    private static readonly MethodInfo EntityTypeToTableMethodInfo
        = typeof(RelationalEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(RelationalEntityTypeBuilderExtensions.ToTable), [typeof(EntityTypeBuilder), typeof(string)])!;

    private static readonly MethodInfo EntityTypeIsMemoryOptimizedMethodInfo
        = typeof(QdrantEntityTypeBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantEntityTypeBuilderExtensions.IsMemoryOptimized), [typeof(EntityTypeBuilder), typeof(bool)])!;

    private static readonly MethodInfo PropertyIsSparseMethodInfo
        = typeof(QdrantPropertyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantPropertyBuilderExtensions.IsSparse), [typeof(PropertyBuilder), typeof(bool)])!;

    private static readonly MethodInfo PropertyUseIdentityColumnsMethodInfo
        = typeof(QdrantPropertyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantPropertyBuilderExtensions.UseIdentityColumn), [typeof(PropertyBuilder), typeof(long), typeof(int)])!;

    private static readonly MethodInfo PropertyUseHiLoMethodInfo
        = typeof(QdrantPropertyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantPropertyBuilderExtensions.UseHiLo), [typeof(PropertyBuilder), typeof(string), typeof(string)])!;

    private static readonly MethodInfo PropertyUseSequenceMethodInfo
        = typeof(QdrantPropertyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantPropertyBuilderExtensions.UseSequence), [typeof(PropertyBuilder), typeof(string), typeof(string)])!;

    private static readonly MethodInfo IndexIsClusteredMethodInfo
        = typeof(QdrantIndexBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantIndexBuilderExtensions.IsClustered), [typeof(IndexBuilder), typeof(bool)])!;

    private static readonly MethodInfo IndexIncludePropertiesMethodInfo
        = typeof(QdrantIndexBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantIndexBuilderExtensions.IncludeProperties), [typeof(IndexBuilder), typeof(string[])])!;

    private static readonly MethodInfo IndexHasFillFactorMethodInfo
        = typeof(QdrantIndexBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantIndexBuilderExtensions.HasFillFactor), [typeof(IndexBuilder), typeof(int)])!;

    private static readonly MethodInfo IndexSortInTempDbMethodInfo
        = typeof(QdrantIndexBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantIndexBuilderExtensions.SortInTempDb), [typeof(IndexBuilder), typeof(bool)])!;

    private static readonly MethodInfo IndexUseDataCompressionMethodInfo
        = typeof(QdrantIndexBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantIndexBuilderExtensions.UseDataCompression), [typeof(IndexBuilder), typeof(DataCompressionType)])!;

    private static readonly MethodInfo KeyIsClusteredMethodInfo
        = typeof(QdrantKeyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantKeyBuilderExtensions.IsClustered), [typeof(KeyBuilder), typeof(bool)])!;

    private static readonly MethodInfo KeyHasFillFactorMethodInfo
        = typeof(QdrantKeyBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantKeyBuilderExtensions.HasFillFactor), [typeof(KeyBuilder), typeof(int)])!;

    private static readonly MethodInfo TableIsTemporalMethodInfo
        = typeof(QdrantTableBuilderExtensions).GetRuntimeMethod(
            nameof(QdrantTableBuilderExtensions.IsTemporal), [typeof(TableBuilder), typeof(bool)])!;

    private static readonly MethodInfo TemporalTableUseHistoryTableMethodInfo1
        = typeof(TemporalTableBuilder).GetRuntimeMethod(
            nameof(TemporalTableBuilder.UseHistoryTable), [typeof(string), typeof(string)])!;

    private static readonly MethodInfo TemporalTableUseHistoryTableMethodInfo2
        = typeof(TemporalTableBuilder).GetRuntimeMethod(
            nameof(TemporalTableBuilder.UseHistoryTable), [typeof(string)])!;

    private static readonly MethodInfo TemporalTableHasPeriodStartMethodInfo
        = typeof(TemporalTableBuilder).GetRuntimeMethod(
            nameof(TemporalTableBuilder.HasPeriodStart), [typeof(string)])!;

    private static readonly MethodInfo TemporalTableHasPeriodEndMethodInfo
        = typeof(TemporalTableBuilder).GetRuntimeMethod(
            nameof(TemporalTableBuilder.HasPeriodEnd), [typeof(string)])!;

    private static readonly MethodInfo TemporalPropertyHasColumnNameMethodInfo
        = typeof(TemporalPeriodPropertyBuilder).GetRuntimeMethod(
            nameof(TemporalPeriodPropertyBuilder.HasColumnName), [typeof(string)])!;

    #endregion MethodInfos

    public QdrantAnnotationCodeGenerator(AnnotationCodeGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(
        IModel model,
        IDictionary<string, IAnnotation> annotations)
    {
        var fragments = new List<MethodCallCodeFragment>(base.GenerateFluentApiCalls(model, annotations));

        if (GenerateValueGenerationStrategy(annotations, model, onModel: true) is MethodCallCodeFragment valueGenerationStrategy)
        {
            fragments.Add(valueGenerationStrategy);
        }

        GenerateSimpleFluentApiCall(
            annotations,
            QdrantAnnotationNames.MaxDatabaseSize, ModelHasDatabaseMaxSizeMethodInfo,
            fragments);

        GenerateSimpleFluentApiCall(
            annotations,
            QdrantAnnotationNames.ServiceTierSql, ModelHasServiceTierSqlMethodInfo,
            fragments);

        GenerateSimpleFluentApiCall(
            annotations,
            QdrantAnnotationNames.PerformanceLevelSql, ModelHasPerformanceLevelSqlMethodInfo,
            fragments);

        return fragments;
    }

    public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(
        IProperty property,
        IDictionary<string, IAnnotation> annotations)
    {
        var fragments = new List<MethodCallCodeFragment>(base.GenerateFluentApiCalls(property, annotations));

        if (GenerateValueGenerationStrategy(annotations, property.DeclaringType.Model, onModel: false) is MethodCallCodeFragment
            valueGenerationStrategy)
        {
            fragments.Add(valueGenerationStrategy);
        }

        if (GetAndRemove<bool?>(annotations, QdrantAnnotationNames.Sparse) is bool isSparse)
        {
            fragments.Add(
                isSparse
                    ? new MethodCallCodeFragment(PropertyIsSparseMethodInfo)
                    : new MethodCallCodeFragment(PropertyIsSparseMethodInfo, false));
        }

        return fragments;
    }

    public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(
        IEntityType entityType,
        IDictionary<string, IAnnotation> annotations)
    {
        var fragments = new List<MethodCallCodeFragment>(base.GenerateFluentApiCalls(entityType, annotations));

        if (GetAndRemove<bool?>(annotations, QdrantAnnotationNames.MemoryOptimized) is bool isMemoryOptimized)
        {
            fragments.Add(
                isMemoryOptimized
                    ? new MethodCallCodeFragment(EntityTypeIsMemoryOptimizedMethodInfo)
                    : new MethodCallCodeFragment(EntityTypeIsMemoryOptimizedMethodInfo, false));
        }

        if (annotations.TryGetValue(QdrantAnnotationNames.IsTemporal, out var isTemporalAnnotation)
            && isTemporalAnnotation.Value as bool? == true)
        {
            var historyTableName = annotations.ContainsKey(QdrantAnnotationNames.TemporalHistoryTableName)
                ? annotations[QdrantAnnotationNames.TemporalHistoryTableName].Value as string
                : null;

            var historyTableSchema = annotations.ContainsKey(QdrantAnnotationNames.TemporalHistoryTableSchema)
                ? annotations[QdrantAnnotationNames.TemporalHistoryTableSchema].Value as string
                : null;

            // for the RevEng path, we avoid adding period properties to the entity
            // because we don't want code for them to be generated - they need to be in shadow state
            // so if we don't find property on the entity, we know it's this scenario
            // and in that case period column name is actually the same as the period property name annotation
            // since in RevEng scenario there can't be custom column mapping
            // see #26007
            var periodStartPropertyName = entityType.GetPeriodStartPropertyName();
            var periodStartProperty = entityType.FindProperty(periodStartPropertyName!);
            var periodStartColumnName = periodStartProperty != null
                ? periodStartProperty[RelationalAnnotationNames.ColumnName] as string
                : periodStartPropertyName;

            var periodEndPropertyName = entityType.GetPeriodEndPropertyName();
            var periodEndProperty = entityType.FindProperty(periodEndPropertyName!);
            var periodEndColumnName = periodEndProperty != null
                ? periodEndProperty[RelationalAnnotationNames.ColumnName] as string
                : periodEndPropertyName;

            // ttb => ttb.UseHistoryTable("HistoryTable", "schema")
            var temporalTableBuilderCalls = new List<MethodCallCodeFragment>();
            if (historyTableName != null)
            {
                temporalTableBuilderCalls.Add(
                    historyTableSchema != null
                        ? new MethodCallCodeFragment(TemporalTableUseHistoryTableMethodInfo1, historyTableName, historyTableSchema)
                        : new MethodCallCodeFragment(TemporalTableUseHistoryTableMethodInfo2, historyTableName));
            }

            // ttb => ttb.HasPeriodStart("Start").HasColumnName("ColumnStart")
            temporalTableBuilderCalls.Add(
                periodStartColumnName != null
                    ? new MethodCallCodeFragment(TemporalTableHasPeriodStartMethodInfo, periodStartPropertyName)
                        .Chain(new MethodCallCodeFragment(TemporalPropertyHasColumnNameMethodInfo, periodStartColumnName))
                    : new MethodCallCodeFragment(TemporalTableHasPeriodStartMethodInfo, periodStartPropertyName));

            // ttb => ttb.HasPeriodEnd("End").HasColumnName("ColumnEnd")
            temporalTableBuilderCalls.Add(
                periodEndColumnName != null
                    ? new MethodCallCodeFragment(TemporalTableHasPeriodEndMethodInfo, periodEndPropertyName)
                        .Chain(new MethodCallCodeFragment(TemporalPropertyHasColumnNameMethodInfo, periodEndColumnName))
                    : new MethodCallCodeFragment(TemporalTableHasPeriodEndMethodInfo, periodEndPropertyName));

            // ToTable(tb => tb.IsTemporal(ttb => { ... }))
            var toTemporalTableCall = new MethodCallCodeFragment(
                EntityTypeToTableMethodInfo,
                new NestedClosureCodeFragment(
                    "tb",
                    new MethodCallCodeFragment(
                        TableIsTemporalMethodInfo,
                        new NestedClosureCodeFragment(
                            "ttb",
                            temporalTableBuilderCalls))));

            fragments.Add(toTemporalTableCall);

            annotations.Remove(QdrantAnnotationNames.IsTemporal);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableName);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableSchema);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodStartPropertyName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodEndPropertyName);
        }

        return fragments;
    }

    protected override bool IsHandledByConvention(IModel model, IAnnotation annotation)
    {
        if (annotation.Name == RelationalAnnotationNames.DefaultSchema)
        {
            return (string?)annotation.Value == "dbo";
        }

        return annotation.Name == QdrantAnnotationNames.ValueGenerationStrategy
            && (QdrantValueGenerationStrategy)annotation.Value! == QdrantValueGenerationStrategy.IdentityColumn;
    }

    protected override bool IsHandledByConvention(IProperty property, IAnnotation annotation)
    {
        if (annotation.Name == QdrantAnnotationNames.ValueGenerationStrategy)
        {
            return (QdrantValueGenerationStrategy)annotation.Value! == property.DeclaringType.Model.GetValueGenerationStrategy();
        }

        return base.IsHandledByConvention(property, annotation);
    }

    protected override MethodCallCodeFragment? GenerateFluentApi(IKey key, IAnnotation annotation)
        => annotation.Name switch
        {
            QdrantAnnotationNames.Clustered => (bool)annotation.Value! == false
                ? new MethodCallCodeFragment(KeyIsClusteredMethodInfo, false)
                : new MethodCallCodeFragment(KeyIsClusteredMethodInfo),

            QdrantAnnotationNames.FillFactor => new MethodCallCodeFragment(KeyHasFillFactorMethodInfo, annotation.Value),

            _ => null
        };

    protected override MethodCallCodeFragment? GenerateFluentApi(IIndex index, IAnnotation annotation)
        => annotation.Name switch
        {
            QdrantAnnotationNames.Clustered => (bool)annotation.Value! == false
                ? new MethodCallCodeFragment(IndexIsClusteredMethodInfo, false)
                : new MethodCallCodeFragment(IndexIsClusteredMethodInfo),

            QdrantAnnotationNames.Include => new MethodCallCodeFragment(IndexIncludePropertiesMethodInfo, annotation.Value),
            QdrantAnnotationNames.FillFactor => new MethodCallCodeFragment(IndexHasFillFactorMethodInfo, annotation.Value),
            QdrantAnnotationNames.SortInTempDb => new MethodCallCodeFragment(IndexSortInTempDbMethodInfo, annotation.Value),
            QdrantAnnotationNames.DataCompression => new MethodCallCodeFragment(IndexUseDataCompressionMethodInfo, annotation.Value),

            _ => null
        };

    private static MethodCallCodeFragment? GenerateValueGenerationStrategy(
        IDictionary<string, IAnnotation> annotations,
        IModel model,
        bool onModel)
    {
        QdrantValueGenerationStrategy strategy;
        if (annotations.TryGetValue(QdrantAnnotationNames.ValueGenerationStrategy, out var strategyAnnotation)
            && strategyAnnotation.Value != null)
        {
            annotations.Remove(QdrantAnnotationNames.ValueGenerationStrategy);
            strategy = (QdrantValueGenerationStrategy)strategyAnnotation.Value;
        }
        else
        {
            return null;
        }

        switch (strategy)
        {
            case QdrantValueGenerationStrategy.IdentityColumn:
                // Support pre-6.0 IdentitySeed annotations, which contained an int rather than a long
                if (annotations.TryGetValue(QdrantAnnotationNames.IdentitySeed, out var seedAnnotation)
                    && seedAnnotation.Value != null)
                {
                    annotations.Remove(QdrantAnnotationNames.IdentitySeed);
                }
                else
                {
                    seedAnnotation = model.FindAnnotation(QdrantAnnotationNames.IdentitySeed);
                }

                var seed = seedAnnotation is null
                    ? 1L
                    : seedAnnotation.Value is int intValue
                        ? intValue
                        : (long?)seedAnnotation.Value ?? 1L;

                var increment = GetAndRemove<int?>(annotations, QdrantAnnotationNames.IdentityIncrement)
                    ?? model.FindAnnotation(QdrantAnnotationNames.IdentityIncrement)?.Value as int?
                    ?? 1;
                return new MethodCallCodeFragment(
                    onModel ? ModelUseIdentityColumnsMethodInfo : PropertyUseIdentityColumnsMethodInfo,
                    (seed, increment) switch
                    {
                        (1L, 1) => [],
                        (_, 1) => [seed],
                        _ => [seed, increment]
                    });

            case QdrantValueGenerationStrategy.SequenceHiLo:
                {
                    var name = GetAndRemove<string>(annotations, QdrantAnnotationNames.HiLoSequenceName);
                    var schema = GetAndRemove<string>(annotations, QdrantAnnotationNames.HiLoSequenceSchema);
                    return new MethodCallCodeFragment(
                        onModel ? ModelUseHiLoMethodInfo : PropertyUseHiLoMethodInfo,
                        (name, schema) switch
                        {
                            (null, null) => [],
                            (_, null) => [name],
                            _ => [name!, schema]
                        });
                }

            case QdrantValueGenerationStrategy.Sequence:
                {
                    var nameOrSuffix = GetAndRemove<string>(
                        annotations,
                        onModel ? QdrantAnnotationNames.SequenceNameSuffix : QdrantAnnotationNames.SequenceName);

                    var schema = GetAndRemove<string>(annotations, QdrantAnnotationNames.SequenceSchema);
                    return new MethodCallCodeFragment(
                        onModel ? ModelUseKeySequencesMethodInfo : PropertyUseSequenceMethodInfo,
                        (name: nameOrSuffix, schema) switch
                        {
                            (null, null) => [],
                            (_, null) => [nameOrSuffix],
                            _ => [nameOrSuffix!, schema]
                        });
                }

            case QdrantValueGenerationStrategy.None:
                return new MethodCallCodeFragment(
                    ModelHasAnnotationMethodInfo,
                    QdrantAnnotationNames.ValueGenerationStrategy,
                    QdrantValueGenerationStrategy.None);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static T? GetAndRemove<T>(IDictionary<string, IAnnotation> annotations, string annotationName)
    {
        if (annotations.TryGetValue(annotationName, out var annotation)
            && annotation.Value != null)
        {
            annotations.Remove(annotationName);
            return (T)annotation.Value;
        }

        return default;
    }

    private static void GenerateSimpleFluentApiCall(
        IDictionary<string, IAnnotation> annotations,
        string annotationName,
        MethodInfo methodInfo,
        List<MethodCallCodeFragment> methodCallCodeFragments)
    {
        if (annotations.TryGetValue(annotationName, out var annotation))
        {
            annotations.Remove(annotationName);
            if (annotation.Value is object annotationValue)
            {
                methodCallCodeFragments.Add(
                    new MethodCallCodeFragment(methodInfo, annotationValue));
            }
        }
    }
}
