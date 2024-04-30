// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

// ReSharper disable once CheckNamespace
namespace Eliassen.EntityFrameworkCore.Migrations;

/// <summary>
///     SQL Server specific extension methods for <see cref="MigrationBuilder" />.
/// </summary>
public static class QdrantMigrationBuilderExtensions
{
    /// <summary>
    ///     Returns <see langword="true" /> if the database provider currently in use is the SQL Server provider.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="migrationBuilder">
    ///     The migrationBuilder from the parameters on <see cref="Migration.Up(MigrationBuilder)" /> or
    ///     <see cref="Migration.Down(MigrationBuilder)" />.
    /// </param>
    /// <returns><see langword="true" /> if SQL Server is being used; <see langword="false" /> otherwise.</returns>
    public static bool IsQdrant(this MigrationBuilder migrationBuilder)
        => string.Equals(
            migrationBuilder.ActiveProvider,
            typeof(QdrantOptionsExtension).Assembly.GetName().Name,
            StringComparison.Ordinal);
}
