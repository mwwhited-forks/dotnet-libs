// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ExpressionExtensions = Microsoft.EntityFrameworkCore.Query.ExpressionExtensions;

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantDateDiffFunctionsTranslator : IMethodCallTranslator
{
    private readonly Dictionary<MethodInfo, string> _methodInfoDateDiffMapping
        = new()
        {
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffYear),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "year"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMonth),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "month"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay), [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffDay),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "day"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffHour),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "hour"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMinute),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "minute"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffSecond),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "second"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMillisecond),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "millisecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffMicrosecond),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "microsecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(TimeSpan), typeof(TimeSpan)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(TimeSpan?), typeof(TimeSpan?)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(TimeOnly), typeof(TimeOnly)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(TimeOnly?), typeof(TimeOnly?)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffNanosecond),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "nanosecond"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateTime), typeof(DateTime)])!,
                "week"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateTime?), typeof(DateTime?)])!,
                "week"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateTimeOffset), typeof(DateTimeOffset)])!,
                "week"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateTimeOffset?), typeof(DateTimeOffset?)])!,
                "week"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateOnly), typeof(DateOnly)])!,
                "week"
            },
            {
                typeof(QdrantDbFunctionsExtensions).GetRuntimeMethod(
                    nameof(QdrantDbFunctionsExtensions.DateDiffWeek),
                    [typeof(DbFunctions), typeof(DateOnly?), typeof(DateOnly?)])!,
                "week"
            }
        };

    private readonly ISqlExpressionFactory _sqlExpressionFactory;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantDateDiffFunctionsTranslator(
        ISqlExpressionFactory sqlExpressionFactory)
    {
        _sqlExpressionFactory = sqlExpressionFactory;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual SqlExpression? Translate(
        SqlExpression? instance,
        MethodInfo method,
        IReadOnlyList<SqlExpression> arguments,
        IDiagnosticsLogger<DbLoggerCategory.Query> logger)
    {
        if (_methodInfoDateDiffMapping.TryGetValue(method, out var datePart))
        {
            var startDate = arguments[1];
            var endDate = arguments[2];
            var typeMapping = ExpressionExtensions.InferTypeMapping(startDate, endDate);

            startDate = _sqlExpressionFactory.ApplyTypeMapping(startDate, typeMapping);
            endDate = _sqlExpressionFactory.ApplyTypeMapping(endDate, typeMapping);

            return _sqlExpressionFactory.Function(
                "DATEDIFF",
                new[] { _sqlExpressionFactory.Fragment(datePart), startDate, endDate },
                nullable: true,
                argumentsPropagateNullability: new[] { false, true, true },
                typeof(int));
        }

        return null;
    }
}
