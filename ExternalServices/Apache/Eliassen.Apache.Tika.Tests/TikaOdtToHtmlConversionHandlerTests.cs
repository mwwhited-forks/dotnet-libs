using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaOdtToHtmlConversionHandlerTests :
    TikaToHtmlConversionHandlerBaseTests<TikaOdtToHtmlConversionHandler>
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("sample2.odt", "application/vnd.oasis.opendocument.text", "text/html", ".html")]
    [DataRow("sample3.odt", "application/vnd.oasis.opendocument.text", "text/html", ".html")]
    public async Task ConvertAsyncTest(string resourceName, string sourceType, string targetType, string ext) =>
        await ConvertAsyncTest(resourceName, sourceType, targetType, ext, TestContext);
}
