using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Qdrant.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;

public interface IQdrantSequenceValueGeneratorFactory
{
    ValueGenerator? TryCreate(
        IProperty property,
        Type clrType,
        QdrantSequenceValueGeneratorState generatorState,
        IQdrantConnection connection,
        IRawSqlCommandBuilder rawSqlCommandBuilder,
        IRelationalCommandDiagnosticsLogger commandLogger);
}
