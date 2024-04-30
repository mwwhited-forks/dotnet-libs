// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Qdrant.Storage.Internal;

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantQueryCompilationContextFactory : IQueryCompilationContextFactory
{
    private readonly IQdrantConnection _QdrantConnection;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantQueryCompilationContextFactory(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies,
        IQdrantConnection QdrantConnection)
    {
        Dependencies = dependencies;
        RelationalDependencies = relationalDependencies;
        _QdrantConnection = QdrantConnection;
    }

    /// <summary>
    ///     Dependencies for this service.
    /// </summary>
    protected virtual QueryCompilationContextDependencies Dependencies { get; }

    /// <summary>
    ///     Relational provider-specific dependencies for this service.
    /// </summary>
    protected virtual RelationalQueryCompilationContextDependencies RelationalDependencies { get; }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public virtual QueryCompilationContext Create(bool async)
        => new QdrantQueryCompilationContext(
            Dependencies, RelationalDependencies, async, _QdrantConnection.IsMultipleActiveResultSetsEnabled);
}
