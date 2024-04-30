using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Eliassen.EntityFrameworkCore.Diagnostics;

public static class QdrantEventId
{
    private enum Id
    {
        // Model validation events
        DecimalTypeDefaultWarning = CoreEventId.ProviderBaseId,
        ByteIdentityColumnWarning,
        ConflictingValueGenerationStrategiesWarning,
        DecimalTypeKeyWarning,

        // Transaction events
        SavepointsDisabledBecauseOfMARS,

        // Scaffolding events
        ColumnFound = CoreEventId.ProviderDesignBaseId,
        ColumnNotNamedWarning,
        ColumnSkipped,
        DefaultSchemaFound,
        ForeignKeyColumnFound,
        ForeignKeyColumnMissingWarning,
        ForeignKeyColumnNotNamedWarning,
        ForeignKeyColumnsNotMappedWarning,
        ForeignKeyNotNamedWarning,
        ForeignKeyReferencesMissingPrincipalTableWarning,
        IndexColumnFound,
        IndexColumnNotNamedWarning,
        IndexColumnSkipped,
        IndexColumnsNotMappedWarning,
        IndexNotNamedWarning,
        IndexTableMissingWarning,
        MissingSchemaWarning,
        MissingTableWarning,
        SequenceFound,
        SequenceNotNamedWarning,
        TableFound,
        TableSkipped,
        TypeAliasFound,
        ForeignKeyTableMissingWarning,
        PrimaryKeyFound,
        UniqueConstraintFound,
        IndexFound,
        ForeignKeyFound,
        ForeignKeyPrincipalColumnMissingWarning,
        ReflexiveConstraintIgnored,
        DuplicateForeignKeyConstraintIgnored,
        ColumnWithoutTypeWarning,
        ForeignKeyReferencesUnknownPrincipalTableWarning,
        MissingViewDefinitionRightsWarning,
    }

    private static readonly string ValidationPrefix = DbLoggerCategory.Model.Validation.Name + ".";
    private static EventId MakeValidationId(Id id) => new((int)id, ValidationPrefix + id);
    public static readonly EventId DecimalTypeKeyWarning = MakeValidationId(Id.DecimalTypeKeyWarning);
    public static readonly EventId DecimalTypeDefaultWarning = MakeValidationId(Id.DecimalTypeDefaultWarning);
    public static readonly EventId ByteIdentityColumnWarning = MakeValidationId(Id.ByteIdentityColumnWarning);
    public static readonly EventId ConflictingValueGenerationStrategiesWarning = MakeValidationId(Id.ConflictingValueGenerationStrategiesWarning);
    private static readonly string TransactionPrefix = DbLoggerCategory.Database.Transaction.Name + ".";

    private static EventId MakeTransactionId(Id id) => new((int)id, TransactionPrefix + id);

    public static readonly EventId SavepointsDisabledBecauseOfMARS = MakeTransactionId(Id.SavepointsDisabledBecauseOfMARS);

    private static readonly string ScaffoldingPrefix = DbLoggerCategory.Scaffolding.Name + ".";

    private static EventId MakeScaffoldingId(Id id) => new((int)id, ScaffoldingPrefix + id);

    public static readonly EventId ColumnFound = MakeScaffoldingId(Id.ColumnFound);
    public static readonly EventId DefaultSchemaFound = MakeScaffoldingId(Id.DefaultSchemaFound);
    public static readonly EventId TypeAliasFound = MakeScaffoldingId(Id.TypeAliasFound);
    public static readonly EventId MissingSchemaWarning = MakeScaffoldingId(Id.MissingSchemaWarning);
    public static readonly EventId MissingTableWarning = MakeScaffoldingId(Id.MissingTableWarning);
    public static readonly EventId ForeignKeyReferencesMissingPrincipalTableWarning = MakeScaffoldingId(Id.ForeignKeyReferencesMissingPrincipalTableWarning);
    public static readonly EventId ForeignKeyReferencesUnknownPrincipalTableWarning = MakeScaffoldingId(Id.ForeignKeyReferencesUnknownPrincipalTableWarning);
    public static readonly EventId TableFound = MakeScaffoldingId(Id.TableFound);
    public static readonly EventId SequenceFound = MakeScaffoldingId(Id.SequenceFound);
    public static readonly EventId PrimaryKeyFound = MakeScaffoldingId(Id.PrimaryKeyFound);
    public static readonly EventId UniqueConstraintFound = MakeScaffoldingId(Id.UniqueConstraintFound);
    public static readonly EventId IndexFound = MakeScaffoldingId(Id.IndexFound);
    public static readonly EventId ForeignKeyFound = MakeScaffoldingId(Id.ForeignKeyFound);
    public static readonly EventId ForeignKeyPrincipalColumnMissingWarning = MakeScaffoldingId(Id.ForeignKeyPrincipalColumnMissingWarning);
    public static readonly EventId ReflexiveConstraintIgnored = MakeScaffoldingId(Id.ReflexiveConstraintIgnored);
    public static readonly EventId DuplicateForeignKeyConstraintIgnored = MakeScaffoldingId(Id.DuplicateForeignKeyConstraintIgnored);
    public static readonly EventId ColumnWithoutTypeWarning = MakeScaffoldingId(Id.ColumnWithoutTypeWarning);
    public static readonly EventId MissingViewDefinitionRightsWarning = MakeScaffoldingId(Id.MissingViewDefinitionRightsWarning);
}
