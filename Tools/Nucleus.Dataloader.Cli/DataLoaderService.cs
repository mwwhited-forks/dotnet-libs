using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Nucleus.Dataloader.Cli
{
    public class DataLoaderService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DataLoaderSettings _settings;
        private readonly IMongoDatabaseRegistration _databases;
        private readonly IDataloaderCommandFactory _commands;

        public DataLoaderService(
            IServiceProvider serviceProvider,
            IOptions<DataLoaderSettings> settings,
            IMongoDatabaseRegistration databases,
            IDataloaderCommandFactory commands
            )
        {
            _serviceProvider = serviceProvider;
            _settings = settings.Value;
            _databases = databases;
            _commands = commands;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var databases = from type in _databases.Types
                            select (type, database: _serviceProvider.GetRequiredService(type));
            var dbs = databases.ToList();


            var exceptions = new List<Exception>();
            foreach (var (type, database) in dbs)
            {
                try
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    await _commands.ExecuteAsync(_settings.Action, type, database, cancellationToken);
                }
                catch (AggregateException aex)
                {
                    exceptions.AddRange(aex.InnerExceptions);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
            {
               throw new AggregateException(exceptions);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}