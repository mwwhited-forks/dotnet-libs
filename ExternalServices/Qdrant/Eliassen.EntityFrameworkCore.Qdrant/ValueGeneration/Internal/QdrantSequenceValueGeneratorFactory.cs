using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Qdrant.Storage.Internal;
using Microsoft.EntityFrameworkCore.Qdrant.Update.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;

public class QdrantSequenceValueGeneratorFactory : IQdrantSequenceValueGeneratorFactory
{
    private readonly IQdrantUpdateSqlGenerator _sqlGenerator;

    public QdrantSequenceValueGeneratorFactory(
        IQdrantUpdateSqlGenerator sqlGenerator)
    {
        _sqlGenerator = sqlGenerator;
    }

    public virtual ValueGenerator? TryCreate(
        IProperty property,
        Type type,
        QdrantSequenceValueGeneratorState generatorState,
        IQdrantConnection connection,
        IRawSqlCommandBuilder rawSqlCommandBuilder,
        IRelationalCommandDiagnosticsLogger commandLogger)
    {
        if (type == typeof(long))
        {
            return new QdrantSequenceHiLoValueGenerator<long>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(int))
        {
            return new QdrantSequenceHiLoValueGenerator<int>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(decimal))
        {
            return new QdrantSequenceHiLoValueGenerator<decimal>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(short))
        {
            return new QdrantSequenceHiLoValueGenerator<short>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(byte))
        {
            return new QdrantSequenceHiLoValueGenerator<byte>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(char))
        {
            return new QdrantSequenceHiLoValueGenerator<char>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(ulong))
        {
            return new QdrantSequenceHiLoValueGenerator<ulong>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(uint))
        {
            return new QdrantSequenceHiLoValueGenerator<uint>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(ushort))
        {
            return new QdrantSequenceHiLoValueGenerator<ushort>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        if (type == typeof(sbyte))
        {
            return new QdrantSequenceHiLoValueGenerator<sbyte>(
                rawSqlCommandBuilder, _sqlGenerator, generatorState, connection, commandLogger);
        }

        return null;
    }
}
