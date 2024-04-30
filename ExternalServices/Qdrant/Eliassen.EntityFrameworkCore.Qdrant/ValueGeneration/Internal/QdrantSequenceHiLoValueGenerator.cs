using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Qdrant.Storage.Internal;
using Microsoft.EntityFrameworkCore.Qdrant.Update.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;

public class QdrantSequenceHiLoValueGenerator<TValue> : HiLoValueGenerator<TValue>
{
    private readonly IRawSqlCommandBuilder _rawSqlCommandBuilder;
    private readonly IQdrantUpdateSqlGenerator _sqlGenerator;
    private readonly IQdrantConnection _connection;
    private readonly ISequence _sequence;
    private readonly IRelationalCommandDiagnosticsLogger _commandLogger;

    public QdrantSequenceHiLoValueGenerator(
        IRawSqlCommandBuilder rawSqlCommandBuilder,
        IQdrantUpdateSqlGenerator sqlGenerator,
        QdrantSequenceValueGeneratorState generatorState,
        IQdrantConnection connection,
        IRelationalCommandDiagnosticsLogger commandLogger)
        : base(generatorState)
    {
        _sequence = generatorState.Sequence;
        _rawSqlCommandBuilder = rawSqlCommandBuilder;
        _sqlGenerator = sqlGenerator;
        _connection = connection;
        _commandLogger = commandLogger;
    }

    protected override long GetNewLowValue()
        => (long)Convert.ChangeType(
            _rawSqlCommandBuilder
                .Build(_sqlGenerator.GenerateNextSequenceValueOperation(_sequence.Name, _sequence.Schema))
                .ExecuteScalar(
                    new RelationalCommandParameterObject(
                        _connection,
                        parameterValues: null,
                        readerColumns: null,
                        context: null,
                        _commandLogger, CommandSource.ValueGenerator)),
            typeof(long),
            CultureInfo.InvariantCulture)!;

    protected override async Task<long> GetNewLowValueAsync(CancellationToken cancellationToken = default)
        => (long)Convert.ChangeType(
            await _rawSqlCommandBuilder
                .Build(_sqlGenerator.GenerateNextSequenceValueOperation(_sequence.Name, _sequence.Schema))
                .ExecuteScalarAsync(
                    new RelationalCommandParameterObject(
                        _connection,
                        parameterValues: null,
                        readerColumns: null,
                        context: null,
                        _commandLogger, CommandSource.ValueGenerator),
                    cancellationToken)
                .ConfigureAwait(false),
            typeof(long),
            CultureInfo.InvariantCulture)!;

    public override bool GeneratesTemporaryValues
        => false;
}
