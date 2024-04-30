using Eliassen.EntityFrameworkCore.Qdrant.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Eliassen.EntityFrameworkCore;

public static class QdrantDatabaseFacadeExtensions
{
    public static bool IsQdrant(this DatabaseFacade database)
        => database.ProviderName == typeof(QdrantOptionsExtension).Assembly.GetName().Name;
}
