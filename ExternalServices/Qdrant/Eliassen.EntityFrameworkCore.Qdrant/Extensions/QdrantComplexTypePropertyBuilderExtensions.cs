using Eliassen.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantComplexTypePropertyBuilderExtensions
{
    public static ComplexTypePropertyBuilder UseHiLo(
        this ComplexTypePropertyBuilder propertyBuilder,
        string? name = null,
        string? schema = null)
    {
        var property = propertyBuilder.Metadata;

        name ??= QdrantModelExtensions.DefaultHiLoSequenceName;

        var model = property.DeclaringType.Model;

        if (model.FindSequence(name, schema) == null)
        {
            model.AddSequence(name, schema).IncrementBy = 10;
        }

        property.SetValueGenerationStrategy(QdrantValueGenerationStrategy.SequenceHiLo);
        property.SetHiLoSequenceName(name);
        property.SetHiLoSequenceSchema(schema);
        property.SetIdentitySeed(null);
        property.SetIdentityIncrement(null);

        return propertyBuilder;
    }

    public static ComplexTypePropertyBuilder<TProperty> UseHiLo<TProperty>(
        this ComplexTypePropertyBuilder<TProperty> propertyBuilder,
        string? name = null,
        string? schema = null)
        => (ComplexTypePropertyBuilder<TProperty>)UseHiLo((ComplexTypePropertyBuilder)propertyBuilder, name, schema);

    public static ComplexTypePropertyBuilder UseSequence(
        this ComplexTypePropertyBuilder propertyBuilder,
        string? name = null,
        string? schema = null)
    {
        var property = propertyBuilder.Metadata;

        property.SetValueGenerationStrategy(QdrantValueGenerationStrategy.Sequence);
        property.SetSequenceName(name);
        property.SetSequenceSchema(schema);
        property.SetHiLoSequenceName(null);
        property.SetHiLoSequenceSchema(null);
        property.SetIdentitySeed(null);
        property.SetIdentityIncrement(null);

        return propertyBuilder;
    }

    public static ComplexTypePropertyBuilder<TProperty> UseSequence<TProperty>(
        this ComplexTypePropertyBuilder<TProperty> propertyBuilder,
        string? name = null,
        string? schema = null)
        => (ComplexTypePropertyBuilder<TProperty>)UseSequence((ComplexTypePropertyBuilder)propertyBuilder, name, schema);

    public static ComplexTypePropertyBuilder UseIdentityColumn(
        this ComplexTypePropertyBuilder propertyBuilder,
        long seed = 1,
        int increment = 1)
    {
        var property = propertyBuilder.Metadata;
        property.SetValueGenerationStrategy(QdrantValueGenerationStrategy.IdentityColumn);
        property.SetIdentitySeed(seed);
        property.SetIdentityIncrement(increment);
        property.SetHiLoSequenceName(null);
        property.SetHiLoSequenceSchema(null);
        property.SetSequenceName(null);
        property.SetSequenceSchema(null);

        return propertyBuilder;
    }

    public static ComplexTypePropertyBuilder UseIdentityColumn(
        this ComplexTypePropertyBuilder propertyBuilder,
        int seed,
        int increment = 1)
        => propertyBuilder.UseIdentityColumn((long)seed, increment);

    public static ComplexTypePropertyBuilder<TProperty> UseIdentityColumn<TProperty>(
        this ComplexTypePropertyBuilder<TProperty> propertyBuilder,
        long seed = 1,
        int increment = 1)
        => (ComplexTypePropertyBuilder<TProperty>)UseIdentityColumn((ComplexTypePropertyBuilder)propertyBuilder, seed, increment);

    public static ComplexTypePropertyBuilder<TProperty> UseIdentityColumn<TProperty>(
        this ComplexTypePropertyBuilder<TProperty> propertyBuilder,
        int seed,
        int increment = 1)
        => (ComplexTypePropertyBuilder<TProperty>)UseIdentityColumn((ComplexTypePropertyBuilder)propertyBuilder, (long)seed, increment);

    public static ComplexTypePropertyBuilder IsSparse(this ComplexTypePropertyBuilder propertyBuilder, bool sparse = true)
    {
        propertyBuilder.Metadata.SetIsSparse(sparse);

        return propertyBuilder;
    }

    public static ComplexTypePropertyBuilder<TProperty> IsSparse<TProperty>(
        this ComplexTypePropertyBuilder<TProperty> propertyBuilder,
        bool sparse = true)
        => (ComplexTypePropertyBuilder<TProperty>)IsSparse((ComplexTypePropertyBuilder)propertyBuilder, sparse);
}
