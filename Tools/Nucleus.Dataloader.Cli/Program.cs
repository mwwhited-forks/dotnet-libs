using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nucleus.Blog.Persistence.Services;
using Nucleus.Core.Persistence.Services;
using Nucleus.Lesson.Persistence.Services;
using Nucleus.Project.Persistence.Sevices;
using Eliassen.System.Configuration;

namespace Nucleus.Dataloader.Cli
{
    internal class Program
    {
        static async Task Main(string[] args) =>
            await Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    //config.AddCommandLine(cli=>cli.SwitchMappings.Appdend);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddConfiguration<DefaultMongoDatabaseSettings>(context.Configuration);

                    services.AddHostedService<DataLoaderService>();

                    services
                        .AddMongoServices(context.Configuration)

                        .TryAddMongoDatabase<IBlogMongoDatabase>()
                        .TryAddMongoDatabase<ILessonMongoDatabase>()
                        .TryAddMongoDatabase<ICoreMongoDatabase>()
                        .TryAddMongoDatabase<IProjectMongoDatabase>()
                        .TryAddMongoDatabase<IProjectMongoDatabase>()
                        ;
                })
                .RunConsoleAsync();

    }
}