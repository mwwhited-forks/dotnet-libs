using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Eliassen.EntityFrameworkCore.Qdrant.Diagnostics.Internal;

public class QdrantLoggingDefinitions : RelationalLoggingDefinitions
{
    public EventDefinitionBase? LogDecimalTypeKey;
    public EventDefinitionBase? LogDefaultDecimalTypeColumn;
    public EventDefinitionBase? LogByteIdentityColumn;
    public EventDefinitionBase? LogColumnWithoutType;
    public EventDefinitionBase? LogFoundDefaultSchema;
    public EventDefinitionBase? LogFoundTypeAlias;
    public EventDefinitionBase? LogFoundColumn;
    public EventDefinitionBase? LogFoundForeignKey;
    public EventDefinitionBase? LogPrincipalTableNotInSelectionSet;
    public EventDefinitionBase? LogMissingSchema;
    public EventDefinitionBase? LogMissingTable;
    public EventDefinitionBase? LogFoundSequence;
    public EventDefinitionBase? LogFoundTable;
    public EventDefinitionBase? LogFoundIndex;
    public EventDefinitionBase? LogFoundPrimaryKey;
    public EventDefinitionBase? LogFoundUniqueConstraint;
    public EventDefinitionBase? LogPrincipalColumnNotFound;
    public EventDefinitionBase? LogReflexiveConstraintIgnored;
    public EventDefinitionBase? LogDuplicateForeignKeyConstraintIgnored;
    public EventDefinitionBase? LogPrincipalTableInformationNotFound;
    public EventDefinitionBase? LogSavepointsDisabledBecauseOfMARS;
    public EventDefinitionBase? LogConflictingValueGenerationStrategies;
    public EventDefinitionBase? LogMissingViewDefinitionRights;
}
