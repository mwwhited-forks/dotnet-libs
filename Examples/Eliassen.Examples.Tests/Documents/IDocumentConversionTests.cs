using Eliassen.Documents;
using Eliassen.TestUtilities;
using Eliassen.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Eliassen.Examples.Tests.Documents;

[TestClass]
public class IDocumentConversionTests
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.Unit)]
    [DataTestMethod]
    [DataRow("HelloWorld.html", "text/html", "text/x-markdown", ".md")]
    [DataRow("HelloWorld.html", "text/html", "application/pdf", ".pdf")]
    [DataRow("HelloWorld.txt", "text/plain", "application/pdf", ".pdf")]
    [DataRow("HelloWorld.txt", "text/plain", "text/html", ".html")]
    [DataRow("HelloWorld.md", "text/markdown", "text/html", ".html")]
    [DataRow("HelloWorld.txt", "text/plain", "text/plain", ".txt")]
    [DataRow("HelloWorld.txt", "unknown/unknown", "text/plain", ".txt")]
    public async Task ConvertAsyncTest(string resourceName, string sourceType, string targetType, string extension)
    {
        var config = new ConfigurationBuilder()
            .Build()
            ;
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Trace)
                )
            .TryAllCommonExtensions(config,
                systemBuilder: new(),
                aspNetBuilder: new(),
                jwtBuilder: new(),
                identityBuilder: new(),
                externalBuilder: new(),
                hostingBuilder: new()
                )
            .BuildServiceProvider()
            ;

        var converter = serviceProvider.GetRequiredService<IDocumentConversion>();

        var resource = this.GetType().Assembly.GetManifestResourceNames().FirstOrDefault(l => l.EndsWith($".{resourceName}"))
            ?? throw new ApplicationException($"missing .{resourceName} resource");
        using var stream = this.GetType().Assembly.GetManifestResourceStream(resource)
            ?? throw new ApplicationException($"missing .{resourceName} resource");

        using var htmlStream = new MemoryStream();
        stream.CopyTo(htmlStream);
        htmlStream.Position = 0;
        using var pdfStream = new MemoryStream();

        await converter.ConvertAsync(htmlStream, sourceType, pdfStream, targetType);
        pdfStream.Position = 0;

        this.TestContext.WriteLine($"Content Length: {pdfStream.Length}");

        TestContext.AddResult(pdfStream, fileName: Path.ChangeExtension(resourceName, extension));

        Assert.IsTrue(pdfStream.Length > 0);
    }
}
