using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantDbFunctionsExtensions
{
    #region Full-text search

    /// <summary>
    ///     A DbFunction method stub that can be used in LINQ queries to target the SQL Server <c>FREETEXT</c> store function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="propertyReference">The property on which the search will be performed.</param>
    /// <param name="freeText">The text that will be searched for in the property.</param>
    /// <param name="languageTerm">A Language ID from the <c>sys.syslanguages</c> table.</param>
    public static bool FreeText(
        this DbFunctions _,
        object propertyReference,
        string freeText,
        [NotParameterized] int languageTerm)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FreeText)));

    /// <summary>
    ///     A DbFunction method stub that can be used in LINQ queries to target the SQL Server <c>FREETEXT</c> store function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="propertyReference">The property on which the search will be performed.</param>
    /// <param name="freeText">The text that will be searched for in the property.</param>
    public static bool FreeText(
        this DbFunctions _,
        object propertyReference,
        string freeText)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(FreeText)));

    /// <summary>
    ///     A DbFunction method stub that can be used in LINQ queries to target the SQL Server <c>CONTAINS</c> store function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="propertyReference">The property on which the search will be performed.</param>
    /// <param name="searchCondition">The text that will be searched for in the property and the condition for a match.</param>
    /// <param name="languageTerm">A Language ID from the <c>sys.syslanguages</c> table.</param>
    public static bool Contains(
        this DbFunctions _,
        object propertyReference,
        string searchCondition,
        [NotParameterized] int languageTerm)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Contains)));

    /// <summary>
    ///     A DbFunction method stub that can be used in LINQ queries to target the SQL Server <c>CONTAINS</c> store function.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="propertyReference">The property on which the search will be performed.</param>
    /// <param name="searchCondition">The text that will be searched for in the property and the condition for a match.</param>
    public static bool Contains(
        this DbFunctions _,
        object propertyReference,
        string searchCondition)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(Contains)));

    #endregion Full-text search

    #region DateDiffYear

    /// <summary>
    ///     Counts the number of year boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int DateDiffYear(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    /// <summary>
    ///     Counts the number of year boundaries crossed between <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int? DateDiffYear(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    /// <summary>
    ///     Counts the number of year boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int DateDiffYear(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    /// <summary>
    ///     Counts the number of year boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int? DateDiffYear(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    /// <summary>
    ///     Counts the number of year boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int DateDiffYear(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    /// <summary>
    ///     Counts the number of year boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(year, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of year boundaries crossed between the dates.</returns>
    public static int? DateDiffYear(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffYear)));

    #endregion DateDiffYear

    #region DateDiffMonth

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int DateDiffMonth(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int? DateDiffMonth(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int DateDiffMonth(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int? DateDiffMonth(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int DateDiffMonth(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    /// <summary>
    ///     Counts the number of month boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(month, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of month boundaries crossed between the dates.</returns>
    public static int? DateDiffMonth(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMonth)));

    #endregion DateDiffMonth

    #region DateDiffDay

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int DateDiffDay(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int? DateDiffDay(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int DateDiffDay(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int? DateDiffDay(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int DateDiffDay(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    /// <summary>
    ///     Counts the number of day boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(day, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of day boundaries crossed between the dates.</returns>
    public static int? DateDiffDay(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffDay)));

    #endregion DateDiffDay

    #region DateDiffHour

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int DateDiffHour(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int? DateDiffHour(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int DateDiffHour(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int? DateDiffHour(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the timespans.</returns>
    public static int DateDiffHour(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the timespans.</returns>
    public static int? DateDiffHour(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the times.</returns>
    public static int DateDiffHour(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the times.</returns>
    public static int? DateDiffHour(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int DateDiffHour(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    /// <summary>
    ///     Counts the number of hour boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(hour, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of hour boundaries crossed between the dates.</returns>
    public static int? DateDiffHour(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffHour)));

    #endregion DateDiffHour

    #region DateDiffMinute

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int DateDiffMinute(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int? DateDiffMinute(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int DateDiffMinute(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int? DateDiffMinute(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the timespans.</returns>
    public static int DateDiffMinute(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the timespans.</returns>
    public static int? DateDiffMinute(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the times.</returns>
    public static int DateDiffMinute(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the times.</returns>
    public static int? DateDiffMinute(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int DateDiffMinute(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    /// <summary>
    ///     Counts the number of minute boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(minute, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of minute boundaries crossed between the dates.</returns>
    public static int? DateDiffMinute(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMinute)));

    #endregion DateDiffMinute

    #region DateDiffSecond

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int DateDiffSecond(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int? DateDiffSecond(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int DateDiffSecond(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and <paramref name="endDate" />.
    ///     Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int? DateDiffSecond(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the timespans.</returns>
    public static int DateDiffSecond(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the timespans.</returns>
    public static int? DateDiffSecond(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the times.</returns>
    public static int DateDiffSecond(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the times.</returns>
    public static int? DateDiffSecond(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int DateDiffSecond(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    /// <summary>
    ///     Counts the number of second boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(second, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of second boundaries crossed between the dates.</returns>
    public static int? DateDiffSecond(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffSecond)));

    #endregion DateDiffSecond

    #region DateDiffMillisecond

    public static int DateDiffMillisecond(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    public static int? DateDiffMillisecond(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));


    public static int DateDiffMillisecond(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the dates.</returns>
    public static int? DateDiffMillisecond(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the timespans.</returns>
    public static int DateDiffMillisecond(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startTimeSpan" /> and
    ///     <paramref name="endTimeSpan" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startTimeSpan, @endTimeSpan)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTimeSpan">Starting timespan for the calculation.</param>
    /// <param name="endTimeSpan">Ending timespan for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the timespans.</returns>
    public static int? DateDiffMillisecond(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the times.</returns>
    public static int DateDiffMillisecond(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startTime" /> and
    ///     <paramref name="endTime" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startTime, @endTime)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startTime">Starting time for the calculation.</param>
    /// <param name="endTime">Ending time for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the times.</returns>
    public static int? DateDiffMillisecond(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the dates.</returns>
    public static int DateDiffMillisecond(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    /// <summary>
    ///     Counts the number of millisecond boundaries crossed between the <paramref name="startDate" /> and
    ///     <paramref name="endDate" />. Corresponds to SQL Server's <c>DATEDIFF(millisecond, @startDate, @endDate)</c>.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-database-functions">Database functions</see>, and
    ///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="_">The <see cref="DbFunctions" /> instance.</param>
    /// <param name="startDate">Starting date for the calculation.</param>
    /// <param name="endDate">Ending date for the calculation.</param>
    /// <returns>Number of millisecond boundaries crossed between the dates.</returns>
    public static int? DateDiffMillisecond(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMillisecond)));

    #endregion DateDiffMillisecond

    #region DateDiffMicrosecond

    public static int DateDiffMicrosecond(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int? DateDiffMicrosecond(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int DateDiffMicrosecond(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int? DateDiffMicrosecond(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int DateDiffMicrosecond(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int? DateDiffMicrosecond(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int DateDiffMicrosecond(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int? DateDiffMicrosecond(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int DateDiffMicrosecond(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    public static int? DateDiffMicrosecond(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffMicrosecond)));

    #endregion DateDiffMicrosecond

    #region DateDiffNanosecond

    public static int DateDiffNanosecond(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int? DateDiffNanosecond(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int DateDiffNanosecond(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int? DateDiffNanosecond(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int DateDiffNanosecond(
        this DbFunctions _,
        TimeSpan startTimeSpan,
        TimeSpan endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int? DateDiffNanosecond(
        this DbFunctions _,
        TimeSpan? startTimeSpan,
        TimeSpan? endTimeSpan)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int DateDiffNanosecond(
        this DbFunctions _,
        TimeOnly startTime,
        TimeOnly endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int? DateDiffNanosecond(
        this DbFunctions _,
        TimeOnly? startTime,
        TimeOnly? endTime)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    public static int DateDiffNanosecond(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));


    public static int? DateDiffNanosecond(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffNanosecond)));

    #endregion DateDiffNanosecond

    #region DateDiffWeek

    public static int DateDiffWeek(
        this DbFunctions _,
        DateTime startDate,
        DateTime endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

    public static int? DateDiffWeek(
        this DbFunctions _,
        DateTime? startDate,
        DateTime? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

    public static int DateDiffWeek(
        this DbFunctions _,
        DateTimeOffset startDate,
        DateTimeOffset endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

    public static int? DateDiffWeek(
        this DbFunctions _,
        DateTimeOffset? startDate,
        DateTimeOffset? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

    public static int DateDiffWeek(
        this DbFunctions _,
        DateOnly startDate,
        DateOnly endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

   public static int? DateDiffWeek(
        this DbFunctions _,
        DateOnly? startDate,
        DateOnly? endDate)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateDiffWeek)));

    #endregion DateDiffWeek

    public static bool IsDate(
        this DbFunctions _,
        string expression)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(IsDate)));

    public static DateTime DateTimeFromParts(
        this DbFunctions _,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second,
        int millisecond)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateTimeFromParts)));

    public static DateTime DateFromParts(
          this DbFunctions _,
          int year,
          int month,
          int day)
          => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateFromParts)));

    public static DateTime DateTime2FromParts(
        this DbFunctions _,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second,
        int fractions,
        int precision)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateTime2FromParts)));


    public static DateTimeOffset DateTimeOffsetFromParts(
        this DbFunctions _,
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int second,
        int fractions,
        int hourOffset,
        int minuteOffset,
        int precision)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DateTimeOffsetFromParts)));

    public static DateTime SmallDateTimeFromParts(
           this DbFunctions _,
           int year,
           int month,
           int day,
           int hour,
           int minute)
           => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(SmallDateTimeFromParts)));

    public static TimeSpan TimeFromParts(
        this DbFunctions _,
        int hour,
        int minute,
        int second,
        int fractions,
        int precision)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(TimeFromParts)));

    public static int? DataLength(
        this DbFunctions _,
        string? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        bool? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        double? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        decimal? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        DateTime? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        TimeSpan? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        DateTimeOffset? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        byte[]? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static int? DataLength(
        this DbFunctions _,
        Guid? arg)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(DataLength)));

    public static bool IsNumeric(
        this DbFunctions _,
        string expression)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(IsNumeric)));

    public static DateTimeOffset AtTimeZone(
        this DbFunctions _,
        DateTime dateTime,
        string timeZone)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AtTimeZone)));

    public static DateTimeOffset AtTimeZone(
        this DbFunctions _,
        DateTimeOffset dateTimeOffset,
        string timeZone)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(AtTimeZone)));

    #region Sample standard deviation

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<byte> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<short> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<int> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<long> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<float> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<double> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    public static double? StandardDeviationSample(this DbFunctions _, IEnumerable<decimal> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationSample)));

    #endregion Sample standard deviation

    #region Population standard deviation

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<byte> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<short> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<int> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<long> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<float> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<double> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    public static double? StandardDeviationPopulation(this DbFunctions _, IEnumerable<decimal> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(StandardDeviationPopulation)));

    #endregion Population standard deviation

    #region Sample variance

    public static double? VarianceSample(this DbFunctions _, IEnumerable<byte> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<short> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<int> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<long> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<float> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<double> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    public static double? VarianceSample(this DbFunctions _, IEnumerable<decimal> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VarianceSample)));

    #endregion Sample variance

    #region Population variance

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<byte> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<short> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<int> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<long> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<float> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<double> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    public static double? VariancePopulation(this DbFunctions _, IEnumerable<decimal> values)
        => throw new InvalidOperationException(CoreStrings.FunctionOnClient(nameof(VariancePopulation)));

    #endregion Population variance
}
