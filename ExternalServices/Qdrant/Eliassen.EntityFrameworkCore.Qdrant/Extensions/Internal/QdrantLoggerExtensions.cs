
using Eliassen.EntityFrameworkCore.Diagnostics;
using Eliassen.EntityFrameworkCore.Metadata;
using Eliassen.EntityFrameworkCore.Qdrant.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace Eliassen.EntityFrameworkCore.Qdrant.Extensions.Internal;


public static class QdrantLoggerExtensions
{

    public static void DecimalTypeKeyWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Model.Validation> diagnostics,
        IProperty property)
    {
        var definition = QdrantResources.LogDecimalTypeKey(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, property.Name, property.DeclaringType.DisplayName());
        }

        if (diagnostics.NeedsEventData(definition, out var diagnosticSourceEnabled, out var simpleLogEnabled))
        {
            var eventData = new PropertyEventData(
                definition,
                DecimalTypeKeyWarning,
                property);

            diagnostics.DispatchEventData(definition, eventData, diagnosticSourceEnabled, simpleLogEnabled);
        }
    }

    private static string DecimalTypeKeyWarning(EventDefinitionBase definition, EventData payload)
    {
        var d = (EventDefinition<string, string>)definition;
        var p = (PropertyEventData)payload;
        return d.GenerateMessage(
            p.Property.Name,
            p.Property.DeclaringType.DisplayName());
    }

    public static void DecimalTypeDefaultWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Model.Validation> diagnostics,
        IProperty property)
    {
        var definition = QdrantResources.LogDefaultDecimalTypeColumn(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, property.Name, property.DeclaringType.DisplayName());
        }

        if (diagnostics.NeedsEventData(definition, out var diagnosticSourceEnabled, out var simpleLogEnabled))
        {
            var eventData = new PropertyEventData(
                definition,
                DecimalTypeDefaultWarning,
                property);

            diagnostics.DispatchEventData(definition, eventData, diagnosticSourceEnabled, simpleLogEnabled);
        }
    }

    private static string DecimalTypeDefaultWarning(EventDefinitionBase definition, EventData payload)
    {
        var d = (EventDefinition<string, string>)definition;
        var p = (PropertyEventData)payload;
        return d.GenerateMessage(
            p.Property.Name,
            p.Property.DeclaringType.DisplayName());
    }

    public static void ByteIdentityColumnWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Model.Validation> diagnostics,
        IProperty property)
    {
        var definition = QdrantResources.LogByteIdentityColumn(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, property.Name, property.DeclaringType.DisplayName());
        }

        if (diagnostics.NeedsEventData(definition, out var diagnosticSourceEnabled, out var simpleLogEnabled))
        {
            var eventData = new PropertyEventData(
                definition,
                ByteIdentityColumnWarning,
                property);

            diagnostics.DispatchEventData(definition, eventData, diagnosticSourceEnabled, simpleLogEnabled);
        }
    }

    private static string ByteIdentityColumnWarning(EventDefinitionBase definition, EventData payload)
    {
        var d = (EventDefinition<string, string>)definition;
        var p = (PropertyEventData)payload;
        return d.GenerateMessage(
            p.Property.Name,
            p.Property.DeclaringType.DisplayName());
    }

    public static void ConflictingValueGenerationStrategiesWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Model.Validation> diagnostics,
        QdrantValueGenerationStrategy QdrantValueGenerationStrategy,
        string otherValueGenerationStrategy,
        IReadOnlyProperty property)
    {
        var definition = QdrantResources.LogConflictingValueGenerationStrategies(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(
                diagnostics, QdrantValueGenerationStrategy.ToString(), otherValueGenerationStrategy,
                property.Name, property.DeclaringType.DisplayName());
        }

        if (diagnostics.NeedsEventData(definition, out var diagnosticSourceEnabled, out var simpleLogEnabled))
        {
            var eventData = new ConflictingValueGenerationStrategiesEventData(
                definition,
                ConflictingValueGenerationStrategiesWarning,
                QdrantValueGenerationStrategy,
                otherValueGenerationStrategy,
                property);

            diagnostics.DispatchEventData(definition, eventData, diagnosticSourceEnabled, simpleLogEnabled);
        }
    }

    private static string ConflictingValueGenerationStrategiesWarning(EventDefinitionBase definition, EventData payload)
    {
        var d = (EventDefinition<string, string, string, string>)definition;
        var p = (ConflictingValueGenerationStrategiesEventData)payload;
        return d.GenerateMessage(
            p.QdrantValueGenerationStrategy.ToString(),
            p.OtherValueGenerationStrategy,
            p.Property.Name,
            p.Property.DeclaringType.DisplayName());
    }

    public static void ColumnFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string tableName,
        string columnName,
        int ordinal,
        string dataTypeName,
        int maxLength,
        int precision,
        int scale,
        bool nullable,
        bool identity,
        string? defaultValue,
        string? computedValue,
        bool? stored)
    {
        var definition = QdrantResources.LogFoundColumn(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(
                diagnostics,
                l => l.LogDebug(
                    definition.EventId,
                    null,
                    definition.MessageFormat,
                    tableName,
                    columnName,
                    ordinal,
                    dataTypeName,
                    maxLength,
                    precision,
                    scale,
                    nullable,
                    identity,
                    defaultValue,
                    computedValue,
                    stored));
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ForeignKeyFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string foreignKeyName,
        string tableName,
        string principalTableName,
        string onDeleteAction)
    {
        var definition = QdrantResources.LogFoundForeignKey(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName, principalTableName, onDeleteAction);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void DefaultSchemaFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string schemaName)
    {
        var definition = QdrantResources.LogFoundDefaultSchema(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, schemaName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void TypeAliasFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string typeAliasName,
        string systemTypeName)
    {
        var definition = QdrantResources.LogFoundTypeAlias(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, typeAliasName, systemTypeName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void PrimaryKeyFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string primaryKeyName,
        string tableName)
    {
        var definition = QdrantResources.LogFoundPrimaryKey(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, primaryKeyName, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void UniqueConstraintFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string uniqueConstraintName,
        string tableName)
    {
        var definition = QdrantResources.LogFoundUniqueConstraint(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, uniqueConstraintName, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void IndexFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string indexName,
        string tableName,
        bool unique)
    {
        var definition = QdrantResources.LogFoundIndex(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, indexName, tableName, unique);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ForeignKeyReferencesUnknownPrincipalTableWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string? foreignKeyName,
        string? tableName)
    {
        var definition = QdrantResources.LogPrincipalTableInformationNotFound(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ForeignKeyReferencesMissingPrincipalTableWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string? foreignKeyName,
        string? tableName,
        string? principalTableName)
    {
        var definition = QdrantResources.LogPrincipalTableNotInSelectionSet(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName, principalTableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ForeignKeyPrincipalColumnMissingWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string foreignKeyName,
        string tableName,
        string principalColumnName,
        string principalTableName)
    {
        var definition = QdrantResources.LogPrincipalColumnNotFound(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName, principalColumnName, principalTableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void MissingSchemaWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string? schemaName)
    {
        var definition = QdrantResources.LogMissingSchema(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, schemaName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void MissingTableWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string? tableName)
    {
        var definition = QdrantResources.LogMissingTable(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ColumnWithoutTypeWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string tableName,
        string columnName)
    {
        var definition = QdrantResources.LogColumnWithoutType(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, tableName, columnName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void SequenceFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string sequenceName,
        string sequenceTypeName,
        bool cyclic,
        int increment,
        long start,
        long min,
        long max,
        bool cached,
        int? cacheSize)
    {
        // No DiagnosticsSource events because these are purely design-time messages
        var definition = QdrantResources.LogFoundSequence(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(
                diagnostics,
                l => l.LogDebug(
                    definition.EventId,
                    null,
                    definition.MessageFormat,
                    sequenceName,
                    sequenceTypeName,
                    cyclic,
                    increment,
                    start,
                    min,
                    max,
                    cached,
                    cacheSize));
        }
    }

    public static void TableFound(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string tableName)
    {
        var definition = QdrantResources.LogFoundTable(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void ReflexiveConstraintIgnored(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string foreignKeyName,
        string tableName)
    {
        var definition = QdrantResources.LogReflexiveConstraintIgnored(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void DuplicateForeignKeyConstraintIgnored(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics,
        string foreignKeyName,
        string tableName,
        string duplicateForeignKeyName)
    {
        var definition = QdrantResources.LogDuplicateForeignKeyConstraintIgnored(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics, foreignKeyName, tableName, duplicateForeignKeyName);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }

    public static void SavepointsDisabledBecauseOfMARS(
        this IDiagnosticsLogger<DbLoggerCategory.Database.Transaction> diagnostics)
    {
        var definition = QdrantResources.LogSavepointsDisabledBecauseOfMARS(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics);
        }

        if (diagnostics.NeedsEventData(definition, out var diagnosticSourceEnabled, out var simpleLogEnabled))
        {
            var eventData = new EventData(
                definition,
                (d, _) => ((EventDefinition)d).GenerateMessage());

            diagnostics.DispatchEventData(definition, eventData, diagnosticSourceEnabled, simpleLogEnabled);
        }
    }

    public static void MissingViewDefinitionRightsWarning(
        this IDiagnosticsLogger<DbLoggerCategory.Scaffolding> diagnostics)
    {
        var definition = QdrantResources.LogMissingViewDefinitionRights(diagnostics);

        if (diagnostics.ShouldLog(definition))
        {
            definition.Log(diagnostics);
        }

        // No DiagnosticsSource events because these are purely design-time messages
    }
}
