// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Storage.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantCompiledQueryCacheKeyGenerator : Microsoft.EntityFrameworkCore.Query.RelationalCompiledQueryCacheKeyGenerator
{
    private readonly IQdrantConnection _QdrantConnection;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantCompiledQueryCacheKeyGenerator(
        CompiledQueryCacheKeyGeneratorDependencies dependencies,
        RelationalCompiledQueryCacheKeyGeneratorDependencies relationalDependencies,
        IQdrantConnection QdrantConnection)
        : base(dependencies, relationalDependencies)
    {
        _QdrantConnection = QdrantConnection;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override object GenerateCacheKey(Expression query, bool async)
        => new QdrantCompiledQueryCacheKey(
            GenerateCacheKeyCore(query, async),
            _QdrantConnection.IsMultipleActiveResultSetsEnabled);

    private readonly struct QdrantCompiledQueryCacheKey : IEquatable<QdrantCompiledQueryCacheKey>
    {
        private readonly RelationalCompiledQueryCacheKey _relationalCompiledQueryCacheKey;
        private readonly bool _multipleActiveResultSetsEnabled;

        public QdrantCompiledQueryCacheKey(
            RelationalCompiledQueryCacheKey relationalCompiledQueryCacheKey,
            bool multipleActiveResultSetsEnabled)
        {
            _relationalCompiledQueryCacheKey = relationalCompiledQueryCacheKey;
            _multipleActiveResultSetsEnabled = multipleActiveResultSetsEnabled;
        }

        public override bool Equals(object? obj)
            => obj is QdrantCompiledQueryCacheKey QdrantCompiledQueryCacheKey
                && Equals(QdrantCompiledQueryCacheKey);

        public bool Equals(QdrantCompiledQueryCacheKey other)
            => _relationalCompiledQueryCacheKey.Equals(other._relationalCompiledQueryCacheKey)
                && _multipleActiveResultSetsEnabled == other._multipleActiveResultSetsEnabled;

        public override int GetHashCode()
            => HashCode.Combine(_relationalCompiledQueryCacheKey, _multipleActiveResultSetsEnabled);
    }
}
