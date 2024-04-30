// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Eliassen.EntityFrameworkCore.Qdrant.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantMethodCallTranslatorProvider : RelationalMethodCallTranslatorProvider
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantMethodCallTranslatorProvider(RelationalMethodCallTranslatorProviderDependencies dependencies)
        : base(dependencies)
    {
        var sqlExpressionFactory = dependencies.SqlExpressionFactory;
        var typeMappingSource = dependencies.RelationalTypeMappingSource;
        AddTranslators(
            new IMethodCallTranslator[]
            {
                new QdrantByteArrayMethodTranslator(sqlExpressionFactory),
                new QdrantConvertTranslator(sqlExpressionFactory),
                new QdrantDataLengthFunctionTranslator(sqlExpressionFactory),
                new QdrantDateDiffFunctionsTranslator(sqlExpressionFactory),
                new QdrantDateOnlyMethodTranslator(sqlExpressionFactory),
                new QdrantDateTimeMethodTranslator(sqlExpressionFactory, typeMappingSource),
                new QdrantFromPartsFunctionTranslator(sqlExpressionFactory, typeMappingSource),
                new QdrantFullTextSearchFunctionsTranslator(sqlExpressionFactory),
                new QdrantIsDateFunctionTranslator(sqlExpressionFactory),
                new QdrantIsNumericFunctionTranslator(sqlExpressionFactory),
                new QdrantMathTranslator(sqlExpressionFactory),
                new QdrantNewGuidTranslator(sqlExpressionFactory),
                new QdrantObjectToStringTranslator(sqlExpressionFactory, typeMappingSource),
                new QdrantStringMethodTranslator(sqlExpressionFactory),
                new QdrantTimeOnlyMethodTranslator(sqlExpressionFactory)
            });
    }
}
