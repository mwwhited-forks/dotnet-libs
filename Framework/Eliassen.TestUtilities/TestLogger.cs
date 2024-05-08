using Microsoft.Extensions.Logging;
using System.Threading;

namespace Eliassen.TestUtilities;

public static class TestLogger
{
    private static AsyncLocal<ILoggerFactory> _factory = new();

    public static ILoggerFactory Factory =>
        _factory.Value ??= LoggerFactory.Create(builder => builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Trace)
        );

    public static ILogger<T> CreateLogger<T>() => Factory.CreateLogger<T>();
}
