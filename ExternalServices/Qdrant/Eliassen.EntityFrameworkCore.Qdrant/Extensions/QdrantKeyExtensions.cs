// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Qdrant.Metadata.Internal;
using System;

// ReSharper disable once CheckNamespace
namespace Eliassen.EntityFrameworkCore;

/// <summary>
///     Key extension methods for SQL Server-specific metadata.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public static class QdrantKeyExtensions
{
    /// <summary>
    ///     Returns a value indicating whether the key is clustered.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns><see langword="true" /> if the key is clustered.</returns>
    public static bool? IsClustered(this IReadOnlyKey key)
        => (key is RuntimeKey)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (bool?)key[QdrantAnnotationNames.Clustered];

    /// <summary>
    ///     Returns a value indicating whether the key is clustered.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns><see langword="true" /> if the key is clustered.</returns>
    public static bool? IsClustered(this IReadOnlyKey key, in StoreObjectIdentifier storeObject)
    {
        if (key is RuntimeKey)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        var annotation = key.FindAnnotation(QdrantAnnotationNames.Clustered);
        if (annotation != null)
        {
            return (bool?)annotation.Value;
        }

        return GetDefaultIsClustered(key, storeObject);
    }

    private static bool? GetDefaultIsClustered(IReadOnlyKey key, in StoreObjectIdentifier storeObject)
    {
        var sharedTableRootKey = key.FindSharedObjectRootKey(storeObject);
        return sharedTableRootKey?.IsClustered(storeObject);
    }

    /// <summary>
    ///     Sets a value indicating whether the key is clustered.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="clustered">The value to set.</param>
    public static void SetIsClustered(this IMutableKey key, bool? clustered)
        => key.SetOrRemoveAnnotation(QdrantAnnotationNames.Clustered, clustered);

    /// <summary>
    ///     Sets a value indicating whether the key is clustered.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="clustered">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static bool? SetIsClustered(this IConventionKey key, bool? clustered, bool fromDataAnnotation = false)
        => (bool?)key.SetOrRemoveAnnotation(
            QdrantAnnotationNames.Clustered,
            clustered,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Gets the <see cref="ConfigurationSource" /> for whether the key is clustered.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for whether the key is clustered.</returns>
    public static ConfigurationSource? GetIsClusteredConfigurationSource(this IConventionKey key)
        => key.FindAnnotation(QdrantAnnotationNames.Clustered)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the fill factor that the key uses.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The fill factor that the key uses</returns>
    public static int? GetFillFactor(this IReadOnlyKey key)
        => (key is RuntimeKey)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (int?)key[QdrantAnnotationNames.FillFactor];

    /// <summary>
    ///     Returns the fill factor that the key uses.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The fill factor that the key uses</returns>
    public static int? GetFillFactor(this IReadOnlyKey key, in StoreObjectIdentifier storeObject)
    {
        if (key is RuntimeKey)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        var annotation = key.FindAnnotation(QdrantAnnotationNames.FillFactor);
        if (annotation != null)
        {
            return (int?)annotation.Value;
        }

        var sharedTableRootKey = key.FindSharedObjectRootKey(storeObject);
        return sharedTableRootKey?.GetFillFactor(storeObject);
    }

    /// <summary>
    ///     Sets a value for fill factor the key uses.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="fillFactor">The value to set.</param>
    public static void SetFillFactor(this IMutableKey key, int? fillFactor)
    {
        if (fillFactor is <= 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(fillFactor));
        }

        key.SetAnnotation(
            QdrantAnnotationNames.FillFactor,
            fillFactor);
    }

    /// <summary>
    ///     Sets a value for fill factor the key uses.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="fillFactor">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static int? SetFillFactor(
        this IConventionKey key,
        int? fillFactor,
        bool fromDataAnnotation = false)
    {
        if (fillFactor is <= 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(fillFactor));
        }

        return (int?)key.SetAnnotation(
            QdrantAnnotationNames.FillFactor,
            fillFactor,
            fromDataAnnotation)?.Value;
    }

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for whether the key uses the fill factor.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for whether the key uses the fill factor.</returns>
    public static ConfigurationSource? GetFillFactorConfigurationSource(this IConventionKey key)
        => key.FindAnnotation(QdrantAnnotationNames.FillFactor)?.GetConfigurationSource();
}
