using Eliassen.Common;
using Eliassen.Common.Extensions;
using Eliassen.Extensions.Configuration;
using Eliassen.System.Text.Templating;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Eliassen.FileRagEngine.Cli;

public class Program
{
    private static async Task Main(string[] args) =>
        await Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => config.AddCommandLine(args,
                    CommandLine.BuildParameters<FileRagEngineOptions>()
                               .AddParameters<FileTemplatingOptions>()
                    ))
            .ConfigureServices((context, services) =>
            {
                services.Configure<FileRagEngineOptions>(options => context.Configuration.Bind(nameof(FileRagEngineOptions), options));

                services.AddHostedService<FileRagEngineService>();

                services.TryCommonExtensions(context.Configuration, new());
                services.TryCommonExternalExtensions(context.Configuration, new(), new());
            })
            .StartAsync();
}
