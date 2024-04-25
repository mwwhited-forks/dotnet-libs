using Eliassen.Common;
using Eliassen.Documents;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Examples.Tests.Documents;

[TestClass]
public class BlobContainerTests
{
    public required TestContext TestContext { get; set; }

    private IServiceProvider ServiceProvider()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                {"AzureBlobProviderOptions:ConnectionString","DefaultEndpointsProtocol=https;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://192.168.1.170:10000/devstoreaccount1;" },
            })
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
        return serviceProvider;
    }

    [TestMethod]
    public async Task Create_IBlobContainer__Docs_Test()
    {
        var wrapper = ServiceProvider().GetRequiredService<IBlobContainer<Docs>>();

        var ms = new MemoryStream();
        var writer = new StreamWriter(ms) { AutoFlush = true };
        writer.WriteLine("Hello!");
        ms.Position = 0;

        var metadata = await wrapper.GetContentMetaDataAsync("helloWorld.txt");

        if (metadata == null)
            await wrapper.StoreContentAsync(
                new() { Content = ms, ContentType = "text/plain", FileName = "helloWorld.txt" },
                new Dictionary<string, string>
                {
                {"other", "stuff" }
                });

        var result = await wrapper.GetContentMetaDataAsync("helloWorld.txt");
    }

    [TestMethod]
    public void Create_IBlobContainer__Summary_Test()
    {
        var wrapper = ServiceProvider().GetRequiredService<IBlobContainer<Summary>>();
    }

    [TestMethod]
    public void Create_IBlobContainer__Summary_List_Test()
    {
        var wrapper = ServiceProvider().GetRequiredService<IBlobContainer<Summary>>();
        var items = wrapper.QueryContent().ToArray();
        this.TestContext.AddResult(items);
    }

    public class Docs { }
    public class Summary { }

}
