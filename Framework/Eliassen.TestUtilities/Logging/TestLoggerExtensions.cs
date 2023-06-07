using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.TestUtilities.Logging
{
    public static class TestLoggerExtensions
    {
        public static IServiceCollection AddTestLoggingServices(this IServiceCollection services, TestContext context, LogLevel logLevel = LogLevel.Debug)
        {
            services
                .AddSingleton(sp => LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel).AddConsole().AddDebug()))
                .AddSingleton<ILogger, TestLogger>()
                .AddSingleton(typeof(ILogger<>), typeof(TestLogger<>))
                ;
            services.TryAddSingleton<ITestCallbackWrapper, TestCallbackWrapper>();
            services.TryAddTransient<ITestContextWrapper>(sp => new TestContextWrapper(context));
            return services;
        }

        public static ILogger<T> GetTestLoggingServices<T>(this TestContext context, LogLevel logLevel = LogLevel.Debug) =>
            new ServiceCollection().AddTestLoggingServices(context, logLevel)
                                   .BuildServiceProvider()
                                   .GetRequiredService<ILogger<T>>();
    }
}
