using Eliassen.System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Nucleus.Dataloader.Cli
{
    public class DataloaderExportCommand : IDataloaderCommand
    {
        private readonly ILogger _log;
        private readonly DataLoaderSettings _settings;
        private readonly IJsonSerializer _jsonSerializer;

        public DataloaderExportCommand(
            ILogger<DataloaderExportCommand> log,
            IOptions<DataLoaderSettings> settings,
            IJsonSerializer jsonSerializer
            )
        {
            _log = log;
            _settings = settings.Value;
            _jsonSerializer = jsonSerializer;
        }

        public DataLoaderActions Action => DataLoaderActions.Export;
        public int Priority => 0;

        public async Task ExecuteAsync(string collectionName, Type elementType, object data, CancellationToken cancellationToken)
        {
            _log.LogInformation($"Exporting: {{{nameof(collectionName)}}}", collectionName);
            var arr = AsArray(data ?? throw new NotSupportedException(nameof(data)), elementType);

            var targetFile = Path.Combine(_settings.SourcePath, $"{collectionName}.json");
            using var fileStream = File.Create(targetFile);
            await _jsonSerializer.SerializeAsync(arr, fileStream);

            _log.LogInformation($"Exported: {{{nameof(collectionName)}}} to \"{{{nameof(targetFile)}}}\"", collectionName, targetFile);
        }

        private Array AsArray(object input, Type type) =>
            (Array)this.GetType()
                .GetMethod(nameof(this.AsArray), 1, new[] {
                    typeof(IMongoCollection<>).MakeGenericType(Type.MakeGenericMethodParameter(0))
                })
                .MakeGenericMethod(type)
                .Invoke(this, new[] { input });
        private T[] AsArray<T>(IMongoCollection<T> collection) => collection.AsQueryable().ToArray();
    }
}