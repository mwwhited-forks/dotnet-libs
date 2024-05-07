﻿using Eliassen.Extensions;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OllamaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Ollama.Tests;

[TestClass]
public class OllamaApiClientTests
{
    public required TestContext TestContext { get; set; }

    private OllamaApiClient Build(string url, string model)
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "OllamaApiClientOptions:Url", url},
                { "OllamaApiClientOptions:DefaultModel", model},
            })
            .Build();

        var services = new ServiceCollection()
            .AddSingleton(config)
            .TryAddOllamaServices(config, nameof(OllamaApiClientOptions))
            .BuildServiceProvider()
            ;

        var factory = services.GetRequiredService<IOllamaApiClientFactory>();
        var client = factory.Build();
        return client;
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("http://127.0.0.1:11434", "phi")]
    public async Task GenerateEmbeddingsDoubleTest(string hostName, string model)
    {
        var client = Build(hostName, model);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(string.Join(", ", embedding.Embedding));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("http://127.0.0.1:11434", "phi")]
    public async Task GenerateEmbeddingsSingleTest(string hostName, string model)
    {
        var client = Build(hostName, model);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(string.Join(", ", Array.ConvertAll(embedding.Embedding, Convert.ToSingle)));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("http://127.0.0.1:11434", "phi")]
    public async Task GenerateEmbeddingsSingleExpandedTest(string hostName, string model)
    {
        var client = Build(hostName, model);
        var embedding = await client.GenerateEmbeddings(new()
        {
            Model = model,
            Prompt = "Hello World!",
        });

        this.TestContext.WriteLine(
            string.Join(", ",
            Array.ConvertAll(embedding.Embedding, d => new[] {
                    (float)d,
                    (float)(d * 10000000 - (float)d * 10000000)
                }).SelectMany(i => i)
            ));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("http://127.0.0.1:11434", "phi", "Create a hello world script for windows command prompt")]
    public async Task GetCompletionTest(string hostName, string model, string prompt)
    {
        var client = Build(hostName, model);
        var embedding = await client.GetCompletion(new()
        {
            Model = model,
            Prompt = prompt,
        });

        this.TestContext.WriteLine(embedding.Response);
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    [DataRow("http://192.168.1.170:11434", "llava:7b", "describe the image", "LadyDancingWithDog.jpg")]
    [DataRow("http://192.168.1.170:11434", "llava:7b", "describe the image", "RobotsTalking.jpg")]
    [DataRow("http://192.168.1.170:11434", "llama2:7b", "describe the image", "LadyDancingWithDog.jpg")]
    [DataRow("http://192.168.1.170:11434", "llama2:7b", "describe the image", "RobotsTalking.jpg")]
    [DataRow("http://192.168.1.170:11434", "mistral:instruct", "describe the image", "LadyDancingWithDog.jpg")]
    [DataRow("http://192.168.1.170:11434", "mistral:instruct", "describe the image", "RobotsTalking.jpg")]
    [DataRow("http://192.168.1.170:11434", "phi", "describe the image", "LadyDancingWithDog.jpg")]
    [DataRow("http://192.168.1.170:11434", "phi", "describe the image", "RobotsTalking.jpg")]
    public async Task GetCompletionWithImageTest(string hostName, string model, string prompt, string imageName)
    {
        using var img = this.GetType().Assembly.GetManifestResourceStream($"Eliassen.Ollama.Tests.TestData.{imageName}")!;
        using var ms = new MemoryStream();
        img.CopyTo(ms);

        var base54 = Convert.ToBase64String(ms.ToArray());

        var client = Build(hostName, model);
        var embedding = await client.GetCompletion(new()
        {
            Model = model,
            Prompt = prompt,
            Images = [base54],
        });

        this.TestContext.WriteLine(
            string.Join(
                Environment.NewLine,
                embedding.Response.SplitBy(50)
                ));
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    //[DataRow("http://127.0.0.1:11434")]
    [DataRow("http://192.168.1.170:11434")]
    public async Task ListModelsTest(string hostName)
    {
        var client = Build(hostName, "");
        foreach (var localModel in await client.ListLocalModels())
            this.TestContext.WriteLine($"model: {localModel.Name}");
    }

    [TestCategory(TestCategories.DevLocal)]
    [DataTestMethod]
    //[DataRow("http://127.0.0.1:11434", "phi")]
    [DataRow("http://192.168.1.170:11434", "llava:7b")]
    public async Task PullModelTest(string hostName, string model)
    {
        var client = Build(hostName, model);
        double? last = default;
        await client.PullModel(model, ps =>
        {
            if (ps.Percent != last)
            {
                Debug.WriteLine($"{model}: Pulled: {ps.Percent}%");
                last = ps.Percent;
            }
        });
    }
}
