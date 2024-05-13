using Eliassen.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaContentTypeDetectorTests
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("accessible_epub_3.epub", "application/epub+zip")]
    [DataRow("Sample.pdf", "application/pdf")]
    [DataRow("sample1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
    [DataRow("sample-1.rtf", "application/rtf")]
    [DataRow("sample2.doc", "application/msword")]
    [DataRow("sample2.odt", "application/vnd.oasis.opendocument.text")]
    public async Task DetectContentTypeAsyncTest(string resourceName, string expectedContentType)
    {
        using var stream = this.GetType().Assembly.GetManifestResourceStream($"Eliassen.Apache.Tika.Tests.TestData.{resourceName}")
            ?? throw new NotSupportedException($"Not found {resourceName}");

        var serviceProvider = ApacheTikaTestHarness.GetServiceProvider(new Dictionary<string, string?>()
        {
            { "ApacheTikaClientOptions:Url","http://127.0.0.1:9998"}
        });

        var detector = ActivatorUtilities.CreateInstance<TikaContentTypeDetector>(serviceProvider);
        var contentType = await detector.DetectContentTypeAsync(stream);

        Assert.AreEqual(expectedContentType, contentType);
    }
}
