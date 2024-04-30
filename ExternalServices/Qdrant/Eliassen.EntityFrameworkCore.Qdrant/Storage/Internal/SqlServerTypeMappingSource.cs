// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Data;
using System.Text.Json;

namespace Eliassen.EntityFrameworkCore.Qdrant.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantTypeMappingSource : RelationalTypeMappingSource
{
    private static readonly QdrantFloatTypeMapping RealAlias
        = new("placeholder", storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantByteArrayTypeMapping Rowversion
        = new(
            "rowversion",
            size: 8,
            comparer: new ValueComparer<byte[]>(
                (v1, v2) => StructuralComparisons.StructuralEqualityComparer.Equals(v1, v2),
                v => StructuralComparisons.StructuralEqualityComparer.GetHashCode(v),
                v => v.ToArray()),
            storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantLongTypeMapping LongRowversion
        = new(
            "rowversion",
            converter: new NumberToBytesConverter<long>(),
            providerValueComparer: new ValueComparer<byte[]>(
                (v1, v2) => StructuralComparisons.StructuralEqualityComparer.Equals(v1, v2),
                v => StructuralComparisons.StructuralEqualityComparer.GetHashCode(v),
                v => v.ToArray()),
            dbType: DbType.Binary);

    private static readonly QdrantLongTypeMapping UlongRowversion
        = new(
            "rowversion",
            converter: new NumberToBytesConverter<ulong>(),
            providerValueComparer: new ValueComparer<byte[]>(
                (v1, v2) => StructuralComparisons.StructuralEqualityComparer.Equals(v1, v2),
                v => StructuralComparisons.StructuralEqualityComparer.GetHashCode(v),
                v => v.ToArray()),
            dbType: DbType.Binary);

    private static readonly QdrantStringTypeMapping FixedLengthUnicodeString
        = new(unicode: true, fixedLength: true);

    private static readonly QdrantStringTypeMapping TextUnicodeString
        = new("ntext", unicode: true, sqlDbType: SqlDbType.NText, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantStringTypeMapping VariableLengthUnicodeString
        = new(unicode: true);

    private static readonly QdrantStringTypeMapping VariableLengthMaxUnicodeString
        = new("nvarchar(max)", unicode: true, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantStringTypeMapping FixedLengthAnsiString
        = new(fixedLength: true);

    private static readonly QdrantStringTypeMapping TextAnsiString
        = new("text", sqlDbType: SqlDbType.Text, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantStringTypeMapping VariableLengthMaxAnsiString
        = new("varchar(max)", storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantByteArrayTypeMapping ImageBinary
        = new("image", sqlDbType: SqlDbType.Image);

    private static readonly QdrantByteArrayTypeMapping VariableLengthMaxBinary
        = new("varbinary(max)", storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantByteArrayTypeMapping FixedLengthBinary
        = new(fixedLength: true);

    private static readonly QdrantDateTimeTypeMapping DateAsDateTime
        = new("date", DbType.Date);

    private static readonly QdrantDateTimeTypeMapping SmallDatetime
        = new("smalldatetime", DbType.DateTime, SqlDbType.SmallDateTime);

    private static readonly QdrantDateTimeTypeMapping Datetime
        = new("datetime", DbType.DateTime);

    private static readonly QdrantDateTimeTypeMapping Datetime2Alias
        = new("placeholder", DbType.DateTime2, null, StoreTypePostfix.None);

    private static readonly DoubleTypeMapping DoubleAlias
        = new QdrantDoubleTypeMapping("placeholder", storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantDateTimeOffsetTypeMapping DatetimeoffsetAlias
        = new("placeholder", DbType.DateTimeOffset, StoreTypePostfix.None);

    private static readonly QdrantDecimalTypeMapping Decimal
        = new("decimal", precision: 18, scale: 0);

    private static readonly QdrantDecimalTypeMapping DecimalAlias
        = new("placeholder", precision: 18, scale: 2, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantDecimalTypeMapping Money
        = new("money", DbType.Currency, sqlDbType: SqlDbType.Money, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantDecimalTypeMapping SmallMoney
        = new("smallmoney", DbType.Currency, sqlDbType: SqlDbType.SmallMoney, storeTypePostfix: StoreTypePostfix.None);

    private static readonly QdrantTimeOnlyTypeMapping TimeAlias
        = new("placeholder", StoreTypePostfix.None);

    private static readonly GuidTypeMapping Uniqueidentifier
        = new("uniqueidentifier");

    private static readonly QdrantStringTypeMapping Xml
        = new("xml", unicode: true, storeTypePostfix: StoreTypePostfix.None);

    private static readonly Dictionary<Type, RelationalTypeMapping> _clrTypeMappings;

    private static readonly Dictionary<Type, RelationalTypeMapping> _clrNoFacetTypeMappings;

    private static readonly Dictionary<string, RelationalTypeMapping[]> _storeTypeMappings;

    static QdrantTypeMappingSource()
    {
        _clrTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
                { typeof(int), IntTypeMapping.Default },
                { typeof(long), QdrantLongTypeMapping.Default },
                { typeof(DateOnly), QdrantDateOnlyTypeMapping.Default },
                { typeof(DateTime), QdrantDateTimeTypeMapping.Default },
                { typeof(Guid), Uniqueidentifier },
                { typeof(bool), QdrantBoolTypeMapping.Default },
                { typeof(byte), QdrantByteTypeMapping.Default },
                { typeof(double), QdrantDoubleTypeMapping.Default },
                { typeof(DateTimeOffset), QdrantDateTimeOffsetTypeMapping.Default },
                { typeof(short), QdrantShortTypeMapping.Default },
                { typeof(float), QdrantFloatTypeMapping.Default },
                { typeof(decimal), QdrantDecimalTypeMapping.Default },
                { typeof(TimeOnly), QdrantTimeOnlyTypeMapping.Default },
                { typeof(TimeSpan), QdrantTimeSpanTypeMapping.Default },
                { typeof(JsonElement), QdrantJsonTypeMapping.Default }
            };

        _clrNoFacetTypeMappings
            = new Dictionary<Type, RelationalTypeMapping>
            {
                { typeof(DateTime), Datetime2Alias },
                { typeof(DateTimeOffset), DatetimeoffsetAlias },
                { typeof(TimeOnly), TimeAlias },
                { typeof(double), DoubleAlias },
                { typeof(float), RealAlias },
                { typeof(decimal), DecimalAlias }
            };

        // ReSharper disable CoVariantArrayConversion
        _storeTypeMappings
            = new Dictionary<string, RelationalTypeMapping[]>(StringComparer.OrdinalIgnoreCase)
            {
                { "bigint", [QdrantLongTypeMapping.Default] },
                { "binary varying", [QdrantByteArrayTypeMapping.Default] },
                { "binary", [FixedLengthBinary] },
                { "bit", [QdrantBoolTypeMapping.Default] },
                { "char varying", [QdrantStringTypeMapping.Default] },
                { "char varying(max)", [VariableLengthMaxAnsiString] },
                { "char", [FixedLengthAnsiString] },
                { "character varying", [QdrantStringTypeMapping.Default] },
                { "character varying(max)", [VariableLengthMaxAnsiString] },
                { "character", [FixedLengthAnsiString] },
                { "date", [QdrantDateOnlyTypeMapping.Default, DateAsDateTime] },
                { "datetime", [Datetime] },
                { "datetime2", [QdrantDateTimeTypeMapping.Default] },
                { "datetimeoffset", [QdrantDateTimeOffsetTypeMapping.Default] },
                { "dec", [Decimal] },
                { "decimal", [Decimal] },
                { "double precision", [QdrantDoubleTypeMapping.Default] },
                { "float", [QdrantDoubleTypeMapping.Default] },
                { "image", [ImageBinary] },
                { "int", [IntTypeMapping.Default] },
                { "money", [Money] },
                { "national char varying", [VariableLengthUnicodeString] },
                { "national char varying(max)", [VariableLengthMaxUnicodeString] },
                { "national character varying", [VariableLengthUnicodeString] },
                { "national character varying(max)", [VariableLengthMaxUnicodeString] },
                { "national character", [FixedLengthUnicodeString] },
                { "nchar", [FixedLengthUnicodeString] },
                { "ntext", [TextUnicodeString] },
                { "numeric", [Decimal] },
                { "nvarchar", [VariableLengthUnicodeString] },
                { "nvarchar(max)", [VariableLengthMaxUnicodeString] },
                { "real", [QdrantFloatTypeMapping.Default] },
                { "rowversion", [Rowversion] },
                { "smalldatetime", [SmallDatetime] },
                { "smallint", [QdrantShortTypeMapping.Default] },
                { "smallmoney", [SmallMoney] },
                { "sql_variant", [QdrantSqlVariantTypeMapping.Default] },
                { "text", [TextAnsiString] },
                { "time", [QdrantTimeOnlyTypeMapping.Default, QdrantTimeSpanTypeMapping.Default] },
                { "timestamp", [Rowversion] },
                { "tinyint", [QdrantByteTypeMapping.Default] },
                { "uniqueidentifier", [Uniqueidentifier] },
                { "varbinary", [QdrantByteArrayTypeMapping.Default] },
                { "varbinary(max)", [VariableLengthMaxBinary] },
                { "varchar", [QdrantStringTypeMapping.Default] },
                { "varchar(max)", [VariableLengthMaxAnsiString] },
                { "xml", [Xml] }
            };
        // ReSharper restore CoVariantArrayConversion
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantTypeMappingSource(
        TypeMappingSourceDependencies dependencies,
        RelationalTypeMappingSourceDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override RelationalTypeMapping? FindMapping(in RelationalTypeMappingInfo mappingInfo)
        => base.FindMapping(mappingInfo)
            ?? FindRawMapping(mappingInfo)?.WithTypeMappingInfo(mappingInfo);

    private RelationalTypeMapping? FindRawMapping(RelationalTypeMappingInfo mappingInfo)
    {
        var clrType = mappingInfo.ClrType;
        var storeTypeName = mappingInfo.StoreTypeName;

        if (storeTypeName != null)
        {
            var storeTypeNameBase = mappingInfo.StoreTypeNameBase;
            if (storeTypeNameBase!.StartsWith("[", StringComparison.Ordinal)
                && storeTypeNameBase.EndsWith("]", StringComparison.Ordinal))
            {
                storeTypeNameBase = storeTypeNameBase[1..^1];
            }

            if (clrType == typeof(float)
                && mappingInfo.Precision is <= 24
                && (storeTypeNameBase.Equals("float", StringComparison.OrdinalIgnoreCase)
                    || storeTypeNameBase.Equals("double precision", StringComparison.OrdinalIgnoreCase)))
            {
                return QdrantFloatTypeMapping.Default;
            }

            if (_storeTypeMappings.TryGetValue(storeTypeName, out var mappings)
                || _storeTypeMappings.TryGetValue(storeTypeNameBase, out mappings))
            {
                // We found the user-specified store type. No CLR type was provided - we're probably scaffolding from an existing database,
                // take the first mapping as the default.
                if (clrType is null)
                {
                    return mappings[0];
                }

                // A CLR type was provided - look for a mapping between the store and CLR types. If not found, fail
                // immediately.
                foreach (var m in mappings)
                {
                    if (m.ClrType == clrType)
                    {
                        return m;
                    }
                }

                return null;
            }

            // SQL Server supports aliases (e.g. CREATE TYPE datetimeAlias FROM datetime2(6))
            // Since we don't know the store name above, usually we end up in the clrType-only lookup below and everything goes well.
            // However, when a facet is specified (length/precision/scale), that facet would get appended to the store type; we don't want
            // this in the case of aliased types, since the facet is already part of the type. So we check whether the CLR type supports
            // facets, and return a special type mapping that doesn't support facets.
            if (clrType != null
                && _clrNoFacetTypeMappings.TryGetValue(clrType, out var mapping))
            {
                return mapping;
            }
        }

        if (clrType != null)
        {
            if (_clrTypeMappings.TryGetValue(clrType, out var mapping))
            {
                return mapping;
            }

            if (clrType == typeof(ulong) && mappingInfo.IsRowVersion == true)
            {
                return UlongRowversion;
            }

            if (clrType == typeof(long) && mappingInfo.IsRowVersion == true)
            {
                return LongRowversion;
            }

            if (clrType == typeof(string))
            {
                var isAnsi = mappingInfo.IsUnicode == false;
                var isFixedLength = mappingInfo.IsFixedLength == true;
                var maxSize = isAnsi ? 8000 : 4000;

                var size = mappingInfo.Size ?? (mappingInfo.IsKeyOrIndex ? isAnsi ? 900 : 450 : null);
                if (size < 0 || size > maxSize)
                {
                    size = isFixedLength ? maxSize : null;
                }

                if (size == null
                    && storeTypeName == null
                    && !mappingInfo.IsKeyOrIndex)
                {
                    return isAnsi
                        ? isFixedLength
                            ? FixedLengthAnsiString
                            : VariableLengthMaxAnsiString
                        : isFixedLength
                            ? FixedLengthUnicodeString
                            : VariableLengthMaxUnicodeString;
                }

                return new QdrantStringTypeMapping(
                    unicode: !isAnsi,
                    size: size,
                    fixedLength: isFixedLength,
                    storeTypePostfix: storeTypeName == null ? StoreTypePostfix.Size : StoreTypePostfix.None,
                    useKeyComparison: mappingInfo.IsKey);
            }

            if (clrType == typeof(byte[]))
            {
                if (mappingInfo.IsRowVersion == true)
                {
                    return Rowversion;
                }

                if (mappingInfo.ElementTypeMapping == null)
                {
                    var isFixedLength = mappingInfo.IsFixedLength == true;

                    var size = mappingInfo.Size ?? (mappingInfo.IsKeyOrIndex ? 900 : null);
                    if (size is < 0 or > 8000)
                    {
                        size = isFixedLength ? 8000 : null;
                    }

                    return size == null
                        ? VariableLengthMaxBinary
                        : new QdrantByteArrayTypeMapping(
                            size: size,
                            fixedLength: isFixedLength,
                            storeTypePostfix: storeTypeName == null ? StoreTypePostfix.Size : StoreTypePostfix.None);
                }
            }
        }

        return null;
    }

    private static readonly List<string> NameBasesUsingPrecision =
    [
        "decimal",
        "dec",
        "numeric",
        "datetime2",
        "datetimeoffset",
        "double precision",
        "float",
        "time"
    ];

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    protected override string? ParseStoreTypeName(
        string? storeTypeName,
        ref bool? unicode,
        ref int? size,
        ref int? precision,
        ref int? scale)
    {
        if (storeTypeName == null)
        {
            return null;
        }

        var originalSize = size;
        var parsedName = base.ParseStoreTypeName(storeTypeName, ref unicode, ref size, ref precision, ref scale);

        if (size.HasValue
            && NameBasesUsingPrecision.Any(n => storeTypeName.StartsWith(n, StringComparison.OrdinalIgnoreCase)))
        {
            precision = size;
            size = originalSize;
        }
        else if (storeTypeName.Trim().EndsWith("(max)", StringComparison.OrdinalIgnoreCase))
        {
            size = -1;
        }

        return parsedName;
    }
}
