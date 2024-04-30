// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantStatisticsAggregateMethodTranslator : IAggregateMethodCallTranslator
{
    private readonly ISqlExpressionFactory _sqlExpressionFactory;
    private readonly RelationalTypeMapping _doubleTypeMapping;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantStatisticsAggregateMethodTranslator(
        ISqlExpressionFactory sqlExpressionFactory,
        IRelationalTypeMappingSource typeMappingSource)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
        _doubleTypeMapping = typeMappingSource.FindMapping(typeof(double))!;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual SqlExpression? Translate(
        MethodInfo method,
        EnumerableExpression source,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        // Docs: https://docs.microsoft.com/sql/t-sql/functions/aggregate-functions-transact-sql

        if (method.DeclaringType != typeof(QdrantDbFunctionsExtensions)
            || source.Selector is not SqlExpression sqlExpression)
        {
            return null;
        }

        var functionName = method.Name switch
        {
            nameof(QdrantDbFunctionsExtensions.StandardDeviationSample) => "STDEV",
            nameof(QdrantDbFunctionsExtensions.StandardDeviationPopulation) => "STDEVP",
            nameof(QdrantDbFunctionsExtensions.VarianceSample) => "VAR",
            nameof(QdrantDbFunctionsExtensions.VariancePopulation) => "VARP",
            _ => null
        };

        if (functionName is null)
        {
            return null;
        }

        return QdrantExpression.AggregateFunction(
            _sqlExpressionFactory,
            functionName,
            new[] { sqlExpression },
            source,
            enumerableArgumentIndex: 0,
            nullable: true,
            argumentsPropagateNullability: new[] { false },
            typeof(double),
            _doubleTypeMapping);
    }
}
