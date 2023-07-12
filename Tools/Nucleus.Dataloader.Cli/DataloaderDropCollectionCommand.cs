using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Nucleus.Dataloader.Cli
{
    public class DataloaderDropCollectionCommand : IDataloaderCommand
    {
        private readonly ILogger _log;

        public DataloaderDropCollectionCommand(
            ILogger<DataloaderExportCommand> log
            )
        {
            _log = log;
        }

        public DataLoaderActions Action => DataLoaderActions.DropCollection;
        public int Priority => 5;

        public async Task ExecuteAsync(string collectionName, Type elementType, object data, CancellationToken cancellationToken)
        {
            _log.LogInformation($"Deleting: {{{nameof(collectionName)}}}", collectionName);

            var db = (IMongoDatabase?)data.GetType().GetProperty("Database")?.GetValue(data);
            if (db != null)
                await db.DropCollectionAsync(collectionName, cancellationToken);

            _log.LogInformation($"Deleted: {{{nameof(collectionName)}}}", collectionName);
        }
    }
}