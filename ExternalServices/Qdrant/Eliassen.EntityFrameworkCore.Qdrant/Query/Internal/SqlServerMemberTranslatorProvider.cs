// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantMemberTranslatorProvider : RelationalMemberTranslatorProvider
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantMemberTranslatorProvider(
        RelationalMemberTranslatorProviderDependencies dependencies,
        IRelationalTypeMappingSource typeMappingSource)
        : base(dependencies)
    {
        var sqlExpressionFactory = dependencies.SqlExpressionFactory;

        AddTranslators(
            new IMemberTranslator[]
            {
                new QdrantDateOnlyMemberTranslator(sqlExpressionFactory),
                new QdrantDateTimeMemberTranslator(sqlExpressionFactory, typeMappingSource),
                new QdrantStringMemberTranslator(sqlExpressionFactory),
                new QdrantTimeSpanMemberTranslator(sqlExpressionFactory),
                new QdrantTimeOnlyMemberTranslator(sqlExpressionFactory)
            });
    }
}
