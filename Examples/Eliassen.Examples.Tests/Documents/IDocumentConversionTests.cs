using Eliassen.Common;
using Eliassen.Documents;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
    [DataRow("sample1.docx", "unknown/unknown", "application/pdf", ".pdf")]
    [DataRow("sample1.docx", "unknown/unknown", "text/markdown", ".md")]
    [DataRow("sample1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "text/plain", ".txt")]
    [DataRow("sample1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "text/html", ".html")]
    [DataRow("sample1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf", ".pdf")]

    [DataRow("Sample.pdf", "application/pdf", "application/pdf", ".pdf")]
    [DataRow("sample2.doc", "application/msword", "application/pdf", ".pdf")]
    [DataRow("sample2.odt", "application/vnd.oasis.opendocument.text", "application/pdf", ".pdf")]
    [DataRow("sample3.odt", "application/vnd.oasis.opendocument.text", "application/pdf", ".pdf")]

    [DataRow("sample-2.rtf", "application/rtf", "application/pdf", ".pdf")]
    [DataRow("accessible_epub_3.epub", "application/epub+zip", "application/pdf", ".pdf")]
    [DataRow("accessible_epub_3.epub", "unknown/unknown", "application/pdf", ".pdf")]
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
