using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eliassen.EntityFrameworkCore.Qdrant.Design.Internal;

#pragma warning disable EF1001 // Internal EF Core API usage.
public class QdrantCSharpRuntimeAnnotationCodeGenerator : RelationalCSharpRuntimeAnnotationCodeGenerator
{
    public QdrantCSharpRuntimeAnnotationCodeGenerator(
        CSharpRuntimeAnnotationCodeGeneratorDependencies dependencies,
        RelationalCSharpRuntimeAnnotationCodeGeneratorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    public override void Generate(IModel model, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
            annotations.Remove(QdrantAnnotationNames.MaxDatabaseSize);
            annotations.Remove(QdrantAnnotationNames.PerformanceLevelSql);
            annotations.Remove(QdrantAnnotationNames.ServiceTierSql);
        }

        base.Generate(model, parameters);
    }

    public override void Generate(IRelationalModel model, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.MemoryOptimized);
            annotations.Remove(QdrantAnnotationNames.EditionOptions);
        }

        base.Generate(model, parameters);
    }

    public override void Generate(IProperty property, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
            annotations.Remove(QdrantAnnotationNames.Sparse);

            if (!annotations.ContainsKey(QdrantAnnotationNames.ValueGenerationStrategy))
            {
                annotations[QdrantAnnotationNames.ValueGenerationStrategy] = property.GetValueGenerationStrategy();
            }
        }

        base.Generate(property, parameters);
    }

    public override void Generate(IColumn column, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.Identity);
            annotations.Remove(QdrantAnnotationNames.Sparse);
            annotations.Remove(QdrantAnnotationNames.TemporalIsPeriodStartColumn);
            annotations.Remove(QdrantAnnotationNames.TemporalIsPeriodEndColumn);
        }

        base.Generate(column, parameters);
    }

    public override void Generate(IIndex index, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.CreatedOnline);
            annotations.Remove(QdrantAnnotationNames.Include);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
            annotations.Remove(QdrantAnnotationNames.SortInTempDb);
            annotations.Remove(QdrantAnnotationNames.DataCompression);
        }

        base.Generate(index, parameters);
    }

    public override void Generate(ITableIndex index, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.CreatedOnline);
            annotations.Remove(QdrantAnnotationNames.Include);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
            annotations.Remove(QdrantAnnotationNames.SortInTempDb);
            annotations.Remove(QdrantAnnotationNames.DataCompression);
        }

        base.Generate(index, parameters);
    }

    public override void Generate(IKey key, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
        }

        base.Generate(key, parameters);
    }

    public override void Generate(IUniqueConstraint uniqueConstraint, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.Clustered);
            annotations.Remove(QdrantAnnotationNames.FillFactor);
        }

        base.Generate(uniqueConstraint, parameters);
    }

    public override void Generate(IEntityType entityType, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableName);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableSchema);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodEndPropertyName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodStartPropertyName);
        }

        base.Generate(entityType, parameters);
    }

    public override void Generate(ITable table, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.MemoryOptimized);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableName);
            annotations.Remove(QdrantAnnotationNames.TemporalHistoryTableSchema);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodEndColumnName);
            annotations.Remove(QdrantAnnotationNames.TemporalPeriodStartColumnName);
        }

        base.Generate(table, parameters);
    }

    public override void Generate(IRelationalPropertyOverrides overrides, CSharpRuntimeAnnotationCodeGeneratorParameters parameters)
    {
        if (!parameters.IsRuntime)
        {
            var annotations = parameters.Annotations;
            annotations.Remove(QdrantAnnotationNames.IdentityIncrement);
            annotations.Remove(QdrantAnnotationNames.IdentitySeed);
        }

        base.Generate(overrides, parameters);
    }
}
