// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Eliassen.EntityFrameworkCore.Qdrant.Scaffolding.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantCodeGenerator : ProviderCodeGenerator
{
    private static readonly MethodInfo UseQdrantMethodInfo
        = typeof(QdrantDbContextOptionsExtensions).GetRuntimeMethod(
            nameof(QdrantDbContextOptionsExtensions.UseQdrant),
            [typeof(DbContextOptionsBuilder), typeof(string), typeof(Action<QdrantDbContextOptionsBuilder>)])!;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QdrantCodeGenerator" /> class.
    /// </summary>
    /// <param name="dependencies">The dependencies.</param>
    public QdrantCodeGenerator(ProviderCodeGeneratorDependencies dependencies)
        : base(dependencies)
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override MethodCallCodeFragment GenerateUseProvider(
        string connectionString,
        MethodCallCodeFragment? providerOptions)
        => new(
            UseQdrantMethodInfo,
            providerOptions == null
                ? [connectionString]
                : [connectionString, new NestedClosureCodeFragment("x", providerOptions)]);
}
