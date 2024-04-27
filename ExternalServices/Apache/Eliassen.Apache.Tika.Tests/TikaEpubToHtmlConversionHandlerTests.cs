using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaEpubToHtmlConversionHandlerTests :
    TikaToHtmlConversionHandlerBaseTests<TikaEpubToHtmlConversionHandler>
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.Unit)]
    [DataTestMethod]
    [DataRow("accessible_epub_3.epub", "application/epub+zip", "text/html", ".html")]
    [DataRow("childrens-literature.epub", "application/epub+zip", "text/html", ".html")]
    public async Task ConvertAsyncTest(string resourceName, string sourceType, string targetType, string ext) =>
        await ConvertAsyncTest(resourceName, sourceType, targetType, ext, TestContext);
}
