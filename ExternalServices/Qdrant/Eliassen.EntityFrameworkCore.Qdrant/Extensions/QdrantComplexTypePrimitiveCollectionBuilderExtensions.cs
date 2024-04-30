using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantComplexTypePrimitiveCollectionBuilderExtensions
{
    public static ComplexTypePrimitiveCollectionBuilder IsSparse(
        this ComplexTypePrimitiveCollectionBuilder primitiveCollectionBuilder,
        bool sparse = true)
    {
        primitiveCollectionBuilder.Metadata.SetIsSparse(sparse);

        return primitiveCollectionBuilder;
    }

    public static ComplexTypePrimitiveCollectionBuilder<TProperty> IsSparse<TProperty>(
        this ComplexTypePrimitiveCollectionBuilder<TProperty> primitiveCollectionBuilder,
        bool sparse = true)
        => (ComplexTypePrimitiveCollectionBuilder<TProperty>)IsSparse(
            (ComplexTypePrimitiveCollectionBuilder)primitiveCollectionBuilder, sparse);
}
