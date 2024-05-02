using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaRtfToHtmlConversionHandlerTests :
    TikaToHtmlConversionHandlerBaseTests<TikaRtfToHtmlConversionHandler>
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.Unit)]
    [DataTestMethod]
    [DataRow("sample-1.rtf", "application/rtf", "text/html", ".html")]
    [DataRow("sample-2.rtf", "application/rtf", "text/html", ".html")]
    [DataRow("sample-3.rtf", "application/rtf", "text/html", ".html")]
    public async Task ConvertAsyncTest(string resourceName, string sourceType, string targetType, string ext) =>
        await ConvertAsyncTest(resourceName, sourceType, targetType, ext, TestContext);
}
