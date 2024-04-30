using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantTableExtensions
{
    public static bool IsSqlOutputClauseUsed(this ITable table)
    {
        if (table.FindRuntimeAnnotation(QdrantAnnotationNames.UseSqlOutputClause) is { Value: bool isSqlOutputClauseUsed })
        {
            return isSqlOutputClauseUsed;
        }

        isSqlOutputClauseUsed = table.EntityTypeMappings.All(
            e => ((IEntityType)e.TypeBase).IsSqlOutputClauseUsed(StoreObjectIdentifier.Table(table.Name, table.Schema)));

        table.SetRuntimeAnnotation(QdrantAnnotationNames.UseSqlOutputClause, isSqlOutputClauseUsed);

        return isSqlOutputClauseUsed;
    }
}
