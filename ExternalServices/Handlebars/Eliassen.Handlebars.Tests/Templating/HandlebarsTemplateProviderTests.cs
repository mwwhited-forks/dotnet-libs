using Eliassen.Handlebars.Helpers;
using Eliassen.Handlebars.Templating;
using Eliassen.System.Net.Mime;
using Eliassen.System.Text.Templating;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Threading.Tasks;

namespace Eliassen.Handlebars.Tests.Templating;

[TestClass]
public class HandlebarsTemplateProviderTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    public async Task ApplyAsyncTest_Simple()
    {
        var data = new
        {
        };
        var source = new MemoryStream();
        var writer = new StreamWriter(source, leaveOpen: true)
        {
            AutoFlush = true,
        };
        writer.WriteLine("Hello World!");
        source.Position = 0;
        var dest = new MemoryStream();
        var reader = new StreamReader(dest);

        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockSource = mockRepo.Create<ITemplateSource>(MockBehavior.Loose);
        var context = new TemplateContext
        {
            OpenTemplate = _ => source,
            TemplateName = "testName",
            TemplateContentType = ContentTypesExtensions.Text.HandlebarsTemplate,
            TemplateFileExtension = ".hbs",
            TargetContentType = ContentTypesExtensions.Text.Markdown,
            TargetFileExtension = ".md",
            TemplateReference = "TestReference",
            TemplateSource = mockSource.Object,
        };

        var provider = new HandlebarsTemplateProvider(
            [], [], [],
            TestLogger.CreateLogger<HandlebarsTemplateProvider>()
            );

        var result = await provider.ApplyAsync(context, data, dest);

        dest.Position= 0;   
        var read = reader.ReadToEnd();

        this.TestContext.WriteLine(read);

        Assert.IsTrue(result);

        mockRepo.VerifyAll();
    }

    [TestMethod]
    public async Task ApplyAsyncTest_WithDate()
    {
        var data = new
        {
        };
        var source = new MemoryStream();
        var writer = new StreamWriter(source, leaveOpen: true)
        {
            AutoFlush = true,
        };
        writer.WriteLine("Hello World! :{{date_now}}");
        source.Position = 0;
        var dest = new MemoryStream();
        var reader = new StreamReader(dest);

        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockSource = mockRepo.Create<ITemplateSource>(MockBehavior.Loose);
        var context = new TemplateContext
        {
            OpenTemplate = _ => source,
            TemplateName = "testName",
            TemplateContentType = ContentTypesExtensions.Text.HandlebarsTemplate,
            TemplateFileExtension = ".hbs",
            TargetContentType = ContentTypesExtensions.Text.Markdown,
            TargetFileExtension = ".md",
            TemplateReference = "TestReference",
            TemplateSource = mockSource.Object,
        };

        var provider = new HandlebarsTemplateProvider(
            [], [], [new DateNowHelperDescriptor()],
            TestLogger.CreateLogger<HandlebarsTemplateProvider>()
            );

        var result = await provider.ApplyAsync(context, data, dest);

        dest.Position = 0;
        var read = reader.ReadToEnd();

        this.TestContext.WriteLine(read);

        Assert.IsTrue(result);

        mockRepo.VerifyAll();
    }

    [TestMethod]
    public async Task ApplyAsyncTest_WithDateAndFormat()
    {
        var data = new
        {
        };
        var source = new MemoryStream();
        var writer = new StreamWriter(source, leaveOpen: true)
        {
            AutoFlush = true,
        };
        writer.WriteLine("Hello World! :{{date_now 'yyyy-MM-dd'}}");
        source.Position = 0;
        var dest = new MemoryStream();
        var reader = new StreamReader(dest);

        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockSource = mockRepo.Create<ITemplateSource>(MockBehavior.Loose);
        var context = new TemplateContext
        {
            OpenTemplate = _ => source,
            TemplateName = "testName",
            TemplateContentType = ContentTypesExtensions.Text.HandlebarsTemplate,
            TemplateFileExtension = ".hbs",
            TargetContentType = ContentTypesExtensions.Text.Markdown,
            TargetFileExtension = ".md",
            TemplateReference = "TestReference",
            TemplateSource = mockSource.Object,
        };

        var provider = new HandlebarsTemplateProvider(
            [], [], [new DateNowHelperDescriptor()],
            TestLogger.CreateLogger<HandlebarsTemplateProvider>()
            );

        var result = await provider.ApplyAsync(context, data, dest);

        dest.Position = 0;
        var read = reader.ReadToEnd();

        this.TestContext.WriteLine(read);

        Assert.IsTrue(result);

        mockRepo.VerifyAll();
    }

    [TestMethod]
    public async Task ApplyAsyncTest_WithGuid()
    {
        var data = new
        {
        };
        var source = new MemoryStream();
        var writer = new StreamWriter(source, leaveOpen: true)
        {
            AutoFlush = true,
        };
        writer.WriteLine("Hello World! :{{guid_new}}");
        source.Position = 0;
        var dest = new MemoryStream();
        var reader = new StreamReader(dest);

        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockSource = mockRepo.Create<ITemplateSource>(MockBehavior.Loose);
        var context = new TemplateContext
        {
            OpenTemplate = _ => source,
            TemplateName = "testName",
            TemplateContentType = ContentTypesExtensions.Text.HandlebarsTemplate,
            TemplateFileExtension = ".hbs",
            TargetContentType = ContentTypesExtensions.Text.Markdown,
            TargetFileExtension = ".md",
            TemplateReference = "TestReference",
            TemplateSource = mockSource.Object,
        };

        var provider = new HandlebarsTemplateProvider(
            [], [], [new GuidNewHelperDescriptor()],
            TestLogger.CreateLogger<HandlebarsTemplateProvider>()
            );

        var result = await provider.ApplyAsync(context, data, dest);

        dest.Position = 0;
        var read = reader.ReadToEnd();

        this.TestContext.WriteLine(read);

        Assert.IsTrue(result);

        mockRepo.VerifyAll();
    }
}
