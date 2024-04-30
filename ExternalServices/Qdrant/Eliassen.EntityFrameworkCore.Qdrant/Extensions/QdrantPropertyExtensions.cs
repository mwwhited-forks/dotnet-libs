using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eliassen.EntityFrameworkCore;

/// <summary>
///     Property extension methods for SQL Server-specific metadata.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public static class QdrantPropertyExtensions
{
    /// <summary>
    ///     Returns the name to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The name to use for the hi-lo sequence.</returns>
    public static string? GetHiLoSequenceName(this IReadOnlyProperty property)
        => (string?)property[QdrantAnnotationNames.HiLoSequenceName];

    /// <summary>
    ///     Returns the name to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The name to use for the hi-lo sequence.</returns>
    public static string? GetHiLoSequenceName(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var annotation = property.FindAnnotation(QdrantAnnotationNames.HiLoSequenceName);
        if (annotation != null)
        {
            return (string?)annotation.Value;
        }

        return property.FindSharedStoreObjectRootProperty(storeObject)?.GetHiLoSequenceName(storeObject);
    }

    /// <summary>
    ///     Sets the name to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="name">The sequence name to use.</param>
    public static void SetHiLoSequenceName(this IMutableProperty property, string? name)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceName,
            Check.NullButNotEmpty(name, nameof(name)));

    /// <summary>
    ///     Sets the name to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="name">The sequence name to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetHiLoSequenceName(
        this IConventionProperty property,
        string? name,
        bool fromDataAnnotation = false)
        => (string?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceName,
            Check.NullButNotEmpty(name, nameof(name)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the hi-lo sequence name.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the hi-lo sequence name.</returns>
    public static ConfigurationSource? GetHiLoSequenceNameConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.HiLoSequenceName)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the schema to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The schema to use for the hi-lo sequence.</returns>
    public static string? GetHiLoSequenceSchema(this IReadOnlyProperty property)
        => (string?)property[QdrantAnnotationNames.HiLoSequenceSchema];

    /// <summary>
    ///     Returns the schema to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The schema to use for the hi-lo sequence.</returns>
    public static string? GetHiLoSequenceSchema(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var annotation = property.FindAnnotation(QdrantAnnotationNames.HiLoSequenceSchema);
        if (annotation != null)
        {
            return (string?)annotation.Value;
        }

        return property.FindSharedStoreObjectRootProperty(storeObject)?.GetHiLoSequenceSchema(storeObject);
    }

    /// <summary>
    ///     Sets the schema to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="schema">The schema to use.</param>
    public static void SetHiLoSequenceSchema(this IMutableProperty property, string? schema)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceSchema,
            Check.NullButNotEmpty(schema, nameof(schema)));

    /// <summary>
    ///     Sets the schema to use for the hi-lo sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="schema">The schema to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetHiLoSequenceSchema(
        this IConventionProperty property,
        string? schema,
        bool fromDataAnnotation = false)
        => (string?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.HiLoSequenceSchema,
            Check.NullButNotEmpty(schema, nameof(schema)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the hi-lo sequence schema.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the hi-lo sequence schema.</returns>
    public static ConfigurationSource? GetHiLoSequenceSchemaConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.HiLoSequenceSchema)?.GetConfigurationSource();

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the hi-lo pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static IReadOnlySequence? FindHiLoSequence(this IReadOnlyProperty property)
    {
        var model = property.DeclaringType.Model;

        var sequenceName = property.GetHiLoSequenceName()
            ?? model.GetHiLoSequenceName();

        var sequenceSchema = property.GetHiLoSequenceSchema()
            ?? model.GetHiLoSequenceSchema();

        return model.FindSequence(sequenceName, sequenceSchema);
    }

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the hi-lo pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static IReadOnlySequence? FindHiLoSequence(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var model = property.DeclaringType.Model;

        var sequenceName = property.GetHiLoSequenceName(storeObject)
            ?? model.GetHiLoSequenceName();

        var sequenceSchema = property.GetHiLoSequenceSchema(storeObject)
            ?? model.GetHiLoSequenceSchema();

        return model.FindSequence(sequenceName, sequenceSchema);
    }

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the hi-lo pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static ISequence? FindHiLoSequence(this IProperty property)
        => (ISequence?)((IReadOnlyProperty)property).FindHiLoSequence();

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the hi-lo pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static ISequence? FindHiLoSequence(this IProperty property, in StoreObjectIdentifier storeObject)
        => (ISequence?)((IReadOnlyProperty)property).FindHiLoSequence(storeObject);

    /// <summary>
    ///     Returns the name to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The name to use for the key value generation sequence.</returns>
    public static string? GetSequenceName(this IReadOnlyProperty property)
        => (string?)property[QdrantAnnotationNames.SequenceName];

    /// <summary>
    ///     Returns the name to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The name to use for the key value generation sequence.</returns>
    public static string? GetSequenceName(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var annotation = property.FindAnnotation(QdrantAnnotationNames.SequenceName);
        if (annotation != null)
        {
            return (string?)annotation.Value;
        }

        return property.FindSharedStoreObjectRootProperty(storeObject)?.GetSequenceName(storeObject);
    }

    /// <summary>
    ///     Sets the name to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="name">The sequence name to use.</param>
    public static void SetSequenceName(this IMutableProperty property, string? name)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceName,
            Check.NullButNotEmpty(name, nameof(name)));

    /// <summary>
    ///     Sets the name to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="name">The sequence name to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetSequenceName(
        this IConventionProperty property,
        string? name,
        bool fromDataAnnotation = false)
        => (string?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceName,
            Check.NullButNotEmpty(name, nameof(name)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the key value generation sequence name.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the key value generation sequence name.</returns>
    public static ConfigurationSource? GetSequenceNameConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.SequenceName)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the schema to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The schema to use for the key value generation sequence.</returns>
    public static string? GetSequenceSchema(this IReadOnlyProperty property)
        => (string?)property[QdrantAnnotationNames.SequenceSchema];

    /// <summary>
    ///     Returns the schema to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The schema to use for the key value generation sequence.</returns>
    public static string? GetSequenceSchema(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var annotation = property.FindAnnotation(QdrantAnnotationNames.SequenceSchema);
        if (annotation != null)
        {
            return (string?)annotation.Value;
        }

        return property.FindSharedStoreObjectRootProperty(storeObject)?.GetSequenceSchema(storeObject);
    }

    /// <summary>
    ///     Sets the schema to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="schema">The schema to use.</param>
    public static void SetSequenceSchema(this IMutableProperty property, string? schema)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceSchema,
            Check.NullButNotEmpty(schema, nameof(schema)));

    /// <summary>
    ///     Sets the schema to use for the key value generation sequence.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="schema">The schema to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static string? SetSequenceSchema(
        this IConventionProperty property,
        string? schema,
        bool fromDataAnnotation = false)
        => (string?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.SequenceSchema,
            Check.NullButNotEmpty(schema, nameof(schema)),
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the key value generation sequence schema.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the key value generation sequence schema.</returns>
    public static ConfigurationSource? GetSequenceSchemaConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.SequenceSchema)?.GetConfigurationSource();

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the key value generation pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static IReadOnlySequence? FindSequence(this IReadOnlyProperty property)
    {
        var model = property.DeclaringType.Model;

        var sequenceName = property.GetSequenceName()
            ?? model.GetSequenceNameSuffix();

        var sequenceSchema = property.GetSequenceSchema()
            ?? model.GetSequenceSchema();

        return model.FindSequence(sequenceName, sequenceSchema);
    }

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the key value generation pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static IReadOnlySequence? FindSequence(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        var model = property.DeclaringType.Model;

        var sequenceName = property.GetSequenceName(storeObject)
            ?? model.GetSequenceNameSuffix();

        var sequenceSchema = property.GetSequenceSchema(storeObject)
            ?? model.GetSequenceSchema();

        return model.FindSequence(sequenceName, sequenceSchema);
    }

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the key value generation pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static ISequence? FindSequence(this IProperty property)
        => (ISequence?)((IReadOnlyProperty)property).FindSequence();

    /// <summary>
    ///     Finds the <see cref="ISequence" /> in the model to use for the key value generation pattern.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The sequence to use, or <see langword="null" /> if no sequence exists in the model.</returns>
    public static ISequence? FindSequence(this IProperty property, in StoreObjectIdentifier storeObject)
        => (ISequence?)((IReadOnlyProperty)property).FindSequence(storeObject);

    /// <summary>
    ///     Returns the identity seed.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The identity seed.</returns>
    public static long? GetIdentitySeed(this IReadOnlyProperty property)
    {
        if (property is RuntimeProperty)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        // Support pre-6.0 IdentitySeed annotations, which contained an int rather than a long
        var annotation = property.FindAnnotation(QdrantAnnotationNames.IdentitySeed);
        return annotation is null
            ? null
            : annotation.Value is int intValue
                ? intValue
                : (long?)annotation.Value;
    }

    /// <summary>
    ///     Returns the identity seed.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The identity seed.</returns>
    public static long? GetIdentitySeed(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        if (property is RuntimeProperty)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        var @override = property.FindOverrides(storeObject)?.FindAnnotation(QdrantAnnotationNames.IdentitySeed);
        if (@override != null)
        {
            return (long?)@override.Value;
        }

        var annotation = property.FindAnnotation(QdrantAnnotationNames.IdentitySeed);
        if (annotation is not null)
        {
            // Support pre-6.0 IdentitySeed annotations, which contained an int rather than a long
            return annotation.Value is int intValue
                ? intValue
                : (long?)annotation.Value;
        }

        var sharedProperty = property.FindSharedStoreObjectRootProperty(storeObject);
        return sharedProperty == null
            ? property.DeclaringType.Model.GetIdentitySeed()
            : sharedProperty.GetIdentitySeed(storeObject);
    }

    /// <summary>
    ///     Returns the identity seed.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The identity seed.</returns>
    public static long? GetIdentitySeed(this IReadOnlyRelationalPropertyOverrides overrides)
        => overrides is RuntimeRelationalPropertyOverrides
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (long?)overrides.FindAnnotation(QdrantAnnotationNames.IdentitySeed)?.Value;

    /// <summary>
    ///     Sets the identity seed.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="seed">The value to set.</param>
    public static void SetIdentitySeed(this IMutableProperty property, long? seed)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentitySeed,
            seed);

    /// <summary>
    ///     Sets the identity seed.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="seed">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static long? SetIdentitySeed(
        this IConventionProperty property,
        long? seed,
        bool fromDataAnnotation = false)
        => (long?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentitySeed,
            seed,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Sets the identity seed for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="seed">The value to set.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    public static void SetIdentitySeed(
        this IMutableProperty property,
        long? seed,
        in StoreObjectIdentifier storeObject)
        => property.GetOrCreateOverrides(storeObject)
            .SetIdentitySeed(seed);

    /// <summary>
    ///     Sets the identity seed for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="seed">The value to set.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static long? SetIdentitySeed(
        this IConventionProperty property,
        long? seed,
        in StoreObjectIdentifier storeObject,
        bool fromDataAnnotation = false)
        => property.GetOrCreateOverrides(storeObject, fromDataAnnotation)
            .SetIdentitySeed(seed, fromDataAnnotation);

    /// <summary>
    ///     Sets the identity seed for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="seed">The value to set.</param>
    public static void SetIdentitySeed(this IMutableRelationalPropertyOverrides overrides, long? seed)
        => overrides.SetOrRemoveAnnotation(QdrantAnnotationNames.IdentitySeed, seed);

    /// <summary>
    ///     Sets the identity seed for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="seed">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static long? SetIdentitySeed(
        this IConventionRelationalPropertyOverrides overrides,
        long? seed,
        bool fromDataAnnotation = false)
        => (long?)overrides.SetOrRemoveAnnotation(QdrantAnnotationNames.IdentitySeed, seed, fromDataAnnotation)?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity seed.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity seed.</returns>
    public static ConfigurationSource? GetIdentitySeedConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.IdentitySeed)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity seed for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity seed.</returns>
    public static ConfigurationSource? GetIdentitySeedConfigurationSource(
        this IConventionProperty property,
        in StoreObjectIdentifier storeObject)
        => property.FindOverrides(storeObject)?.GetIdentitySeedConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity seed for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity seed.</returns>
    public static ConfigurationSource? GetIdentitySeedConfigurationSource(
        this IConventionRelationalPropertyOverrides overrides)
        => overrides.FindAnnotation(QdrantAnnotationNames.IdentitySeed)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the identity increment.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The identity increment.</returns>
    public static int? GetIdentityIncrement(this IReadOnlyProperty property)
        => (property is RuntimeProperty)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (int?)property[QdrantAnnotationNames.IdentityIncrement]
            ?? property.DeclaringType.Model.GetIdentityIncrement();

    /// <summary>
    ///     Returns the identity increment.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The identity increment.</returns>
    public static int? GetIdentityIncrement(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        if (property is RuntimeProperty)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        var @override = property.FindOverrides(storeObject)?.FindAnnotation(QdrantAnnotationNames.IdentityIncrement);
        if (@override != null)
        {
            return (int?)@override.Value;
        }

        var annotation = property.FindAnnotation(QdrantAnnotationNames.IdentityIncrement);
        if (annotation != null)
        {
            return (int?)annotation.Value;
        }

        var sharedProperty = property.FindSharedStoreObjectRootProperty(storeObject);
        return sharedProperty == null
            ? property.DeclaringType.Model.GetIdentityIncrement()
            : sharedProperty.GetIdentityIncrement(storeObject);
    }

    /// <summary>
    ///     Returns the identity increment.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The identity increment.</returns>
    public static int? GetIdentityIncrement(this IReadOnlyRelationalPropertyOverrides overrides)
        => overrides is RuntimeRelationalPropertyOverrides
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (int?)overrides.FindAnnotation(QdrantAnnotationNames.IdentityIncrement)?.Value;

    /// <summary>
    ///     Sets the identity increment.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="increment">The value to set.</param>
    public static void SetIdentityIncrement(this IMutableProperty property, int? increment)
        => property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentityIncrement,
            increment);

    /// <summary>
    ///     Sets the identity increment.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="increment">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static int? SetIdentityIncrement(
        this IConventionProperty property,
        int? increment,
        bool fromDataAnnotation = false)
        => (int?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.IdentityIncrement,
            increment,
            fromDataAnnotation)?.Value;

    /// <summary>
    ///     Sets the identity increment for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="increment">The value to set.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    public static void SetIdentityIncrement(
        this IMutableProperty property,
        int? increment,
        in StoreObjectIdentifier storeObject)
        => property.GetOrCreateOverrides(storeObject)
            .SetIdentityIncrement(increment);

    /// <summary>
    ///     Sets the identity increment for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="increment">The value to set.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static int? SetIdentityIncrement(
        this IConventionProperty property,
        int? increment,
        in StoreObjectIdentifier storeObject,
        bool fromDataAnnotation = false)
        => property.GetOrCreateOverrides(storeObject, fromDataAnnotation)
            .SetIdentityIncrement(increment, fromDataAnnotation);

    /// <summary>
    ///     Sets the identity increment for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="increment">The value to set.</param>
    public static void SetIdentityIncrement(this IMutableRelationalPropertyOverrides overrides, int? increment)
        => overrides.SetOrRemoveAnnotation(QdrantAnnotationNames.IdentityIncrement, increment);

    /// <summary>
    ///     Sets the identity increment for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="increment">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static int? SetIdentityIncrement(
        this IConventionRelationalPropertyOverrides overrides,
        int? increment,
        bool fromDataAnnotation = false)
        => (int?)overrides.SetOrRemoveAnnotation(QdrantAnnotationNames.IdentityIncrement, increment, fromDataAnnotation)
            ?.Value;

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity increment.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity increment.</returns>
    public static ConfigurationSource? GetIdentityIncrementConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.IdentityIncrement)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity increment for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity increment.</returns>
    public static ConfigurationSource? GetIdentityIncrementConfigurationSource(
        this IConventionProperty property,
        in StoreObjectIdentifier storeObject)
        => property.FindOverrides(storeObject)?.GetIdentityIncrementConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the identity increment for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the identity increment.</returns>
    public static ConfigurationSource? GetIdentityIncrementConfigurationSource(
        this IConventionRelationalPropertyOverrides overrides)
        => overrides.FindAnnotation(QdrantAnnotationNames.IdentityIncrement)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="QdrantValueGenerationStrategy" /> to use for the property.
    /// </summary>
    /// <remarks>
    ///     If no strategy is set for the property, then the strategy to use will be taken from the <see cref="IModel" />.
    /// </remarks>
    /// <param name="property">The property.</param>
    /// <returns>The strategy, or <see cref="QdrantValueGenerationStrategy.None" /> if none was set.</returns>
    public static QdrantValueGenerationStrategy GetValueGenerationStrategy(this IReadOnlyProperty property)
    {
        var annotation = property.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy);
        if (annotation != null)
        {
            return (QdrantValueGenerationStrategy?)annotation.Value ?? QdrantValueGenerationStrategy.None;
        }

        var defaultValueGenerationStrategy = GetDefaultValueGenerationStrategy(property);

        if (property.ValueGenerated != ValueGenerated.OnAdd
            || property.IsForeignKey()
            || property.TryGetDefaultValue(out _)
            || (defaultValueGenerationStrategy != QdrantValueGenerationStrategy.Sequence && property.GetDefaultValueSql() != null)
            || property.GetComputedColumnSql() != null)
        {
            return QdrantValueGenerationStrategy.None;
        }

        return defaultValueGenerationStrategy;
    }

    /// <summary>
    ///     Returns the <see cref="QdrantValueGenerationStrategy" /> to use for the property.
    /// </summary>
    /// <remarks>
    ///     If no strategy is set for the property, then the strategy to use will be taken from the <see cref="IModel" />.
    /// </remarks>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns>The strategy, or <see cref="QdrantValueGenerationStrategy.None" /> if none was set.</returns>
    public static QdrantValueGenerationStrategy GetValueGenerationStrategy(
        this IReadOnlyProperty property,
        in StoreObjectIdentifier storeObject)
        => GetValueGenerationStrategy(property, storeObject, null);

    internal static QdrantValueGenerationStrategy GetValueGenerationStrategy(
        this IReadOnlyProperty property,
        in StoreObjectIdentifier storeObject,
        ITypeMappingSource? typeMappingSource)
    {
        var @override = property.FindOverrides(storeObject)?.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy);
        if (@override != null)
        {
            return (QdrantValueGenerationStrategy?)@override.Value ?? QdrantValueGenerationStrategy.None;
        }

        var annotation = property.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy);
        if (annotation?.Value != null
            && StoreObjectIdentifier.Create(property.DeclaringType, storeObject.StoreObjectType) == storeObject)
        {
            return (QdrantValueGenerationStrategy)annotation.Value;
        }

        var table = storeObject;
        var sharedTableRootProperty = property.FindSharedStoreObjectRootProperty(storeObject);
        if (sharedTableRootProperty != null)
        {
            return sharedTableRootProperty.GetValueGenerationStrategy(storeObject, typeMappingSource)
                == QdrantValueGenerationStrategy.IdentityColumn
                && table.StoreObjectType == StoreObjectType.Table
                && !property.GetContainingForeignKeys().Any(
                    fk =>
                        !fk.IsBaseLinking()
                        || (StoreObjectIdentifier.Create(fk.PrincipalEntityType, StoreObjectType.Table)
                                is StoreObjectIdentifier principal
                            && fk.GetConstraintName(table, principal) != null))
                    ? QdrantValueGenerationStrategy.IdentityColumn
                    : QdrantValueGenerationStrategy.None;
        }

        if (property.ValueGenerated != ValueGenerated.OnAdd
            || table.StoreObjectType != StoreObjectType.Table
            || property.TryGetDefaultValue(storeObject, out _)
            || property.GetDefaultValueSql(storeObject) != null
            || property.GetComputedColumnSql(storeObject) != null
            || property.GetContainingForeignKeys()
                .Any(
                    fk =>
                        !fk.IsBaseLinking()
                        || (StoreObjectIdentifier.Create(fk.PrincipalEntityType, StoreObjectType.Table)
                                is StoreObjectIdentifier principal
                            && fk.GetConstraintName(table, principal) != null)))
        {
            return QdrantValueGenerationStrategy.None;
        }

        var defaultStrategy = GetDefaultValueGenerationStrategy(property, storeObject, typeMappingSource);
        if (defaultStrategy != QdrantValueGenerationStrategy.None)
        {
            if (annotation != null)
            {
                return (QdrantValueGenerationStrategy?)annotation.Value ?? QdrantValueGenerationStrategy.None;
            }
        }

        return defaultStrategy;
    }

    /// <summary>
    ///     Returns the <see cref="QdrantValueGenerationStrategy" /> to use for the property.
    /// </summary>
    /// <remarks>
    ///     If no strategy is set for the property, then the strategy to use will be taken from the <see cref="IModel" />.
    /// </remarks>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The strategy, or <see cref="QdrantValueGenerationStrategy.None" /> if none was set.</returns>
    public static QdrantValueGenerationStrategy? GetValueGenerationStrategy(
        this IReadOnlyRelationalPropertyOverrides overrides)
        => (QdrantValueGenerationStrategy?)overrides.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy)
            ?.Value;

    private static QdrantValueGenerationStrategy GetDefaultValueGenerationStrategy(IReadOnlyProperty property)
    {
        var modelStrategy = property.DeclaringType.Model.GetValueGenerationStrategy();

        if (modelStrategy is QdrantValueGenerationStrategy.SequenceHiLo or QdrantValueGenerationStrategy.Sequence
            && IsCompatibleWithValueGeneration(property))
        {
            return modelStrategy.Value;
        }

        return modelStrategy == QdrantValueGenerationStrategy.IdentityColumn
            && IsCompatibleWithValueGeneration(property)
                ? QdrantValueGenerationStrategy.IdentityColumn
                : QdrantValueGenerationStrategy.None;
    }

    private static QdrantValueGenerationStrategy GetDefaultValueGenerationStrategy(
        IReadOnlyProperty property,
        in StoreObjectIdentifier storeObject,
        ITypeMappingSource? typeMappingSource)
    {
        var modelStrategy = property.DeclaringType.Model.GetValueGenerationStrategy();

        if (modelStrategy is QdrantValueGenerationStrategy.SequenceHiLo or QdrantValueGenerationStrategy.Sequence
            && IsCompatibleWithValueGeneration(property, storeObject, typeMappingSource))
        {
            return modelStrategy.Value;
        }

        return modelStrategy == QdrantValueGenerationStrategy.IdentityColumn
            && IsCompatibleWithValueGeneration(property, storeObject, typeMappingSource)
                ? property.DeclaringType.GetMappingStrategy() == RelationalAnnotationNames.TpcMappingStrategy
                    ? QdrantValueGenerationStrategy.Sequence
                    : QdrantValueGenerationStrategy.IdentityColumn
                : QdrantValueGenerationStrategy.None;
    }

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="value">The strategy to use.</param>
    public static void SetValueGenerationStrategy(
        this IMutableProperty property,
        QdrantValueGenerationStrategy? value)
        => property.SetOrRemoveAnnotation(QdrantAnnotationNames.ValueGenerationStrategy, value);

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="value">The strategy to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static QdrantValueGenerationStrategy? SetValueGenerationStrategy(
        this IConventionProperty property,
        QdrantValueGenerationStrategy? value,
        bool fromDataAnnotation = false)
        => (QdrantValueGenerationStrategy?)property.SetOrRemoveAnnotation(
            QdrantAnnotationNames.ValueGenerationStrategy, value, fromDataAnnotation)?.Value;

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="value">The strategy to use.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    public static void SetValueGenerationStrategy(
        this IMutableProperty property,
        QdrantValueGenerationStrategy? value,
        in StoreObjectIdentifier storeObject)
        => property.GetOrCreateOverrides(storeObject)
            .SetValueGenerationStrategy(value);

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="value">The strategy to use.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static QdrantValueGenerationStrategy? SetValueGenerationStrategy(
        this IConventionProperty property,
        QdrantValueGenerationStrategy? value,
        in StoreObjectIdentifier storeObject,
        bool fromDataAnnotation = false)
        => property.GetOrCreateOverrides(storeObject, fromDataAnnotation)
            .SetValueGenerationStrategy(value, fromDataAnnotation);

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="value">The strategy to use.</param>
    public static void SetValueGenerationStrategy(
        this IMutableRelationalPropertyOverrides overrides,
        QdrantValueGenerationStrategy? value)
        => overrides.SetOrRemoveAnnotation(QdrantAnnotationNames.ValueGenerationStrategy, value);

    /// <summary>
    ///     Sets the <see cref="QdrantValueGenerationStrategy" /> to use for the property for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <param name="value">The strategy to use.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static QdrantValueGenerationStrategy? SetValueGenerationStrategy(
        this IConventionRelationalPropertyOverrides overrides,
        QdrantValueGenerationStrategy? value,
        bool fromDataAnnotation = false)
        => (QdrantValueGenerationStrategy?)overrides.SetOrRemoveAnnotation(
            QdrantAnnotationNames.ValueGenerationStrategy, value, fromDataAnnotation)?.Value;


    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" />.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" />.</returns>
    public static ConfigurationSource? GetValueGenerationStrategyConfigurationSource(
        this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy)?.GetConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" /> for a particular table.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the table containing the column.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" />.</returns>
    public static ConfigurationSource? GetValueGenerationStrategyConfigurationSource(
        this IConventionProperty property,
        in StoreObjectIdentifier storeObject)
        => property.FindOverrides(storeObject)?.GetValueGenerationStrategyConfigurationSource();

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" /> for a particular table.
    /// </summary>
    /// <param name="overrides">The property overrides.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for the <see cref="QdrantValueGenerationStrategy" />.</returns>
    public static ConfigurationSource? GetValueGenerationStrategyConfigurationSource(
        this IConventionRelationalPropertyOverrides overrides)
        => overrides.FindAnnotation(QdrantAnnotationNames.ValueGenerationStrategy)?.GetConfigurationSource();

    /// <summary>
    ///     Returns a value indicating whether the property is compatible with any <see cref="QdrantValueGenerationStrategy" />.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns><see langword="true" /> if compatible.</returns>
    public static bool IsCompatibleWithValueGeneration(IReadOnlyProperty property)
    {
        var valueConverter = property.GetValueConverter()
            ?? property.FindTypeMapping()?.Converter;

        var type = (valueConverter?.ProviderClrType ?? property.ClrType).UnwrapNullableType();
        return type.IsInteger()
            || type.IsEnum
            || type == typeof(decimal);
    }

    private static bool IsCompatibleWithValueGeneration(
        IReadOnlyProperty property,
        in StoreObjectIdentifier storeObject,
        ITypeMappingSource? typeMappingSource)
    {
        if (storeObject.StoreObjectType != StoreObjectType.Table)
        {
            return false;
        }

        var valueConverter = property.GetValueConverter()
            ?? (property.FindRelationalTypeMapping(storeObject)
                ?? typeMappingSource?.FindMapping((IProperty)property))?.Converter;

        var type = (valueConverter?.ProviderClrType ?? property.ClrType).UnwrapNullableType();

        return (type.IsInteger()
            || type.IsEnum
            || type == typeof(decimal));
    }

    /// <summary>
    ///     Returns a value indicating whether the property's column is sparse.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns><see langword="true" /> if the property's column is sparse.</returns>
    public static bool? IsSparse(this IReadOnlyProperty property)
        => (property is RuntimeProperty)
            ? throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData)
            : (bool?)property[QdrantAnnotationNames.Sparse];

    /// <summary>
    ///     Returns a value indicating whether the property's column is sparse.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="storeObject">The identifier of the store object.</param>
    /// <returns><see langword="true" /> if the property's column is sparse.</returns>
    public static bool? IsSparse(this IReadOnlyProperty property, in StoreObjectIdentifier storeObject)
    {
        if (property is RuntimeProperty)
        {
            throw new InvalidOperationException(CoreStrings.RuntimeModelMissingData);
        }

        var annotation = property.FindAnnotation(QdrantAnnotationNames.Sparse);
        if (annotation != null)
        {
            return (bool?)annotation.Value;
        }

        var sharedTableRootProperty = property.FindSharedStoreObjectRootProperty(storeObject);
        return sharedTableRootProperty?.IsSparse(storeObject);
    }

    /// <summary>
    ///     Sets a value indicating whether the property's column is sparse.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="sparse">The value to set.</param>
    public static void SetIsSparse(this IMutableProperty property, bool? sparse)
        => property.SetAnnotation(QdrantAnnotationNames.Sparse, sparse);

    /// <summary>
    ///     Sets a value indicating whether the property's column is sparse.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="sparse">The value to set.</param>
    /// <param name="fromDataAnnotation">Indicates whether the configuration was specified using a data annotation.</param>
    /// <returns>The configured value.</returns>
    public static bool? SetIsSparse(
        this IConventionProperty property,
        bool? sparse,
        bool fromDataAnnotation = false)
    {
        property.SetAnnotation(
            QdrantAnnotationNames.Sparse,
            sparse,
            fromDataAnnotation);

        return sparse;
    }

    /// <summary>
    ///     Returns the <see cref="ConfigurationSource" /> for whether the property's column is sparse.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <returns>The <see cref="ConfigurationSource" /> for whether the property's column is sparse.</returns>
    public static ConfigurationSource? GetIsSparseConfigurationSource(this IConventionProperty property)
        => property.FindAnnotation(QdrantAnnotationNames.Sparse)?.GetConfigurationSource();
}
