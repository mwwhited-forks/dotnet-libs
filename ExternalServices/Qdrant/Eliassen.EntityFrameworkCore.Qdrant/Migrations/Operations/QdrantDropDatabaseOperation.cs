// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Eliassen.EntityFrameworkCore.Migrations.Operations;

/// <summary>
///     A SQL Server-specific <see cref="MigrationOperation" /> to drop a database.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-migrations">Database migrations</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public class QdrantDropDatabaseOperation : MigrationOperation
{
    /// <summary>
    ///     The name of the database.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}
