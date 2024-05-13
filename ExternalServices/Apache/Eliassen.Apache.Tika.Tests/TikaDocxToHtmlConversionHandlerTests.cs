using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Eliassen.Apache.Tika.Tests;

[TestClass]
public class TikaDocxToHtmlConversionHandlerTests :
    TikaToHtmlConversionHandlerBaseTests<TikaDocxToHtmlConversionHandler>
{
    public required TestContext TestContext { get; set; }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("sample1.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "text/html", ".html")]
    [DataRow("sample4.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "text/html", ".html")]

    public async Task ConvertAsyncTest(string resourceName, string sourceType, string targetType, string ext) =>
        await ConvertAsyncTest(resourceName, sourceType, targetType, ext, TestContext);
}
