using Eliassen.Documents.Conversion;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

public abstract class TikaToHtmlConversionHandlerBaseTests<T>
{
    public async Task ConvertAsyncTest(
        string resourceName,
        string sourceType,
        string targetType,
        string ext,
        TestContext testContext
        )
    {
        var config = new ConfigurationBuilder()
            .Build();
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Trace)
                )
            .TryAddApacheTikaServices()
            .BuildServiceProvider()
            ;

        var converter = (IDocumentConversionHandler)ActivatorUtilities.CreateInstance<T>(serviceProvider)!;

        var resource = GetType().Assembly.GetManifestResourceNames().FirstOrDefault(l => l.EndsWith($".{resourceName}"))
            ?? throw new ApplicationException($"missing .{resourceName} resource");
        using var stream = GetType().Assembly.GetManifestResourceStream(resource)
            ?? throw new ApplicationException($"missing .{resourceName} resource");

        using var htmlStream = new MemoryStream();
        stream.CopyTo(htmlStream);
        htmlStream.Position = 0;
        using var pdfStream = new MemoryStream();

        await converter.ConvertAsync(htmlStream, sourceType, pdfStream, targetType);
        pdfStream.Position = 0;

        testContext.WriteLine($"Content Length: {pdfStream.Length}");

        testContext.AddResult(pdfStream, fileName: Path.ChangeExtension(resourceName, ext));

        Assert.IsTrue(pdfStream.Length > 240);
    }
}
