// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.Qdrant.Extensions.Internal;

namespace Eliassen.EntityFrameworkCore.Qdrant.Storage.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class QdrantTransaction : RelationalTransaction
{
    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public QdrantTransaction(
        IRelationalConnection connection,
        DbTransaction transaction,
        Guid transactionId,
        IDiagnosticsLogger<DbLoggerCategory.Database.Transaction> logger,
        bool transactionOwned,
        ISqlGenerationHelper sqlGenerationHelper)
        : base(connection, transaction, transactionId, logger, transactionOwned, sqlGenerationHelper)
    {
    }

    /// <inheritdoc />
    public override bool SupportsSavepoints
    {
        get
        {
            if (Connection is IQdrantConnection { IsMultipleActiveResultSetsEnabled: true })
            {
                Logger.SavepointsDisabledBecauseOfMARS();

                return false;
            }

            return true;
        }
    }

    // SQL Server doesn't support releasing savepoints. Override to do nothing.

    /// <inheritdoc />
    public override void ReleaseSavepoint(string name)
    {
    }

    /// <inheritdoc />
    public override Task ReleaseSavepointAsync(string name, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
