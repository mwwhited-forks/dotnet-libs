﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Eliassen.EntityFrameworkCore.Qdrant.Extensions.Internal;
using Eliassen.EntityFrameworkCore.Qdrant.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

// ReSharper disable once CheckNamespace
namespace Eliassen.EntityFrameworkCore.Metadata.Conventions;

/// <summary>
///     A convention that ensures that properties aren't configured to have a default value, as computed column
///     or using a <see cref="QdrantValueGenerationStrategy" /> at the same time.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see>, and
///     <see href="https://aka.ms/efcore-docs-Qdrant">Accessing SQL Server and Azure SQL databases with EF Core</see>
///     for more information and examples.
/// </remarks>
public class QdrantStoreGenerationConvention : StoreGenerationConvention
{
    /// <summary>
    ///     Creates a new instance of <see cref="QdrantStoreGenerationConvention" />.
    /// </summary>
    /// <param name="dependencies">Parameter object containing dependencies for this convention.</param>
    /// <param name="relationalDependencies"> Parameter object containing relational dependencies for this convention.</param>
    public QdrantStoreGenerationConvention(
        ProviderConventionSetBuilderDependencies dependencies,
        RelationalConventionSetBuilderDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    /// <summary>
    ///     Called after an annotation is changed on a property.
    /// </summary>
    /// <param name="propertyBuilder">The builder for the property.</param>
    /// <param name="name">The annotation name.</param>
    /// <param name="annotation">The new annotation.</param>
    /// <param name="oldAnnotation">The old annotation.</param>
    /// <param name="context">Additional information associated with convention execution.</param>
    public override void ProcessPropertyAnnotationChanged(
        IConventionPropertyBuilder propertyBuilder,
        string name,
        IConventionAnnotation? annotation,
        IConventionAnnotation? oldAnnotation,
        IConventionContext<IConventionAnnotation> context)
    {
        if (annotation == null
            || oldAnnotation?.Value != null)
        {
            return;
        }

        var configurationSource = annotation.GetConfigurationSource();
        var fromDataAnnotation = configurationSource != ConfigurationSource.Convention;
        switch (name)
        {
            case RelationalAnnotationNames.DefaultValue:
                if (propertyBuilder.HasValueGenerationStrategy(null, fromDataAnnotation) == null
                    && propertyBuilder.HasDefaultValue(null, fromDataAnnotation) != null)
                {
                    context.StopProcessing();
                    return;
                }

                break;
            case RelationalAnnotationNames.DefaultValueSql:
                if (propertyBuilder.Metadata.GetValueGenerationStrategy() != QdrantValueGenerationStrategy.Sequence
                    && propertyBuilder.HasValueGenerationStrategy(null, fromDataAnnotation) == null
                    && propertyBuilder.HasDefaultValueSql(null, fromDataAnnotation) != null)
                {
                    context.StopProcessing();
                    return;
                }

                break;
            case RelationalAnnotationNames.ComputedColumnSql:
                if (propertyBuilder.HasValueGenerationStrategy(null, fromDataAnnotation) == null
                    && propertyBuilder.HasComputedColumnSql(null, fromDataAnnotation) != null)
                {
                    context.StopProcessing();
                    return;
                }

                break;
            case QdrantAnnotationNames.ValueGenerationStrategy:
                if (((propertyBuilder.Metadata.GetValueGenerationStrategy() != QdrantValueGenerationStrategy.Sequence
                            && (propertyBuilder.HasDefaultValue(null, fromDataAnnotation) == null
                                || propertyBuilder.HasDefaultValueSql(null, fromDataAnnotation) == null
                                || propertyBuilder.HasComputedColumnSql(null, fromDataAnnotation) == null))
                        || (propertyBuilder.HasDefaultValue(null, fromDataAnnotation) == null
                            || propertyBuilder.HasComputedColumnSql(null, fromDataAnnotation) == null))
                    && propertyBuilder.HasValueGenerationStrategy(null, fromDataAnnotation) != null)
                {
                    context.StopProcessing();
                    return;
                }

                break;
        }

        base.ProcessPropertyAnnotationChanged(propertyBuilder, name, annotation, oldAnnotation, context);
    }

    /// <inheritdoc />
    protected override void Validate(IConventionProperty property, in StoreObjectIdentifier storeObject)
    {
        if (property.GetValueGenerationStrategyConfigurationSource() != null)
        {
            var generationStrategy = property.GetValueGenerationStrategy(storeObject, Dependencies.TypeMappingSource);
            if (generationStrategy == QdrantValueGenerationStrategy.None)
            {
                base.Validate(property, storeObject);
                return;
            }

            if (property.TryGetDefaultValue(storeObject, out _))
            {
                Dependencies.ValidationLogger.ConflictingValueGenerationStrategiesWarning(
                    generationStrategy, "DefaultValue", property);
            }

            if (property.GetDefaultValueSql(storeObject) != null)
            {
                Dependencies.ValidationLogger.ConflictingValueGenerationStrategiesWarning(
                    generationStrategy, "DefaultValueSql", property);
            }

            if (property.GetComputedColumnSql(storeObject) != null)
            {
                Dependencies.ValidationLogger.ConflictingValueGenerationStrategiesWarning(
                    generationStrategy, "ComputedColumnSql", property);
            }
        }

        base.Validate(property, storeObject);
    }
}
