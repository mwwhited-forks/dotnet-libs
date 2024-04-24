using Azure.AI.OpenAI;
using Eliassen.AI;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliassen.OpenAI.AI.Tests;

[TestClass]
public class OpenAIManagerTests
{
    public required TestContext TestContext { get; set; }

    private ILanguageModelProvider Provider()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "OpenAIClientOptions:APIKey", "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"},
                { "OpenAIClientOptions:DeploymentName", "gpt-3.5-turbo"},
            })
            .Build();

        var services = new ServiceCollection()
            .AddSingleton(config)
            .TryAddOpenAIServices(config, nameof(OpenAIClientOptions))
            .BuildServiceProvider()
            ;

        var provider = services.GetRequiredService<ILanguageModelProvider>();
        return provider;
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("You are a client manager for a big tech firm", "hello there!")]
    [DataRow("You are a cheery Scotsman", "How are you doing today?")]
    [DataRow("You are a highly religious and only speak in binary", "hello there!")]
    public async Task GetResponseAsyncTest(string prompt, string user)
    {
        var provider = Provider();
        var result = await provider.GetResponseAsync(prompt, user);

        this.TestContext.WriteLine(result);
        Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
    }
}
