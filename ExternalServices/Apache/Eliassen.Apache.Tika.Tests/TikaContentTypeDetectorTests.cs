using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaContentTypeDetectorTests
{
    public required TestContext TestContext { get; set; }


    [TestCategory(TestCategories.Unit)]
    [DataTestMethod]
    [DataRow("accessible_epub_3.epub", "application/epub+zip")]
    [DataRow("Sample.pdf", "application/pdf")]
    [DataRow("sample1.docx", "application/x-tika-ooxml")]
    [DataRow("sample-1.rtf", "application/rtf")]
    [DataRow("sample2.doc", "application/x-tika-msoffice")]
    [DataRow("sample2.odt", "application/vnd.oasis.opendocument.text")]
    public async Task DetectContentTypeAsyncTest(string resourceName, string expectedContentType)
    {
        using var stream = this.GetType().Assembly.GetManifestResourceStream($"Eliassen.Apache.Tika.Tests.TestData.{resourceName}")
            ?? throw new NotSupportedException($"Not found {resourceName}");

        var detector = new TikaContentTypeDetector();
        var contentType = await detector.DetectContentTypeAsync(stream);

        Assert.AreEqual(expectedContentType, contentType);
    }

}
