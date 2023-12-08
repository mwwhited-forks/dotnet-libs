using Eliassen.Azure.StorageAccount.MessageQueueing;
using Eliassen.MessageQueueing;
using Eliassen.MessageQueueing.Tests;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliassen.Azure.StorageAccount.Tests.MessageQueueing;

[TestClass]
[MessageQueue(QueueConfig)]
public class AzureStorageQueueMessageSenderProviderTests
{
    public const string QueueConfig = "test-config";

    public TestContext TestContext { get; set; } = null!;

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task SendAsyncTest_ByFullType()
    {
        var configBuilder = new ConfigurationBuilder();

        configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            {$"MessageQueue:{QueueConfig}:Provider", typeof(AzureStorageQueueMessageSenderProvider).AssemblyQualifiedName },

            {$"MessageQueue:{QueueConfig}:Config:ConnectionString", "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1" },
            {$"MessageQueue:{QueueConfig}:Config:QueueName", "test-queue" },
        });

        var config = configBuilder.Build();

        var service = MessageSenderTests.GetServiceProvider(TestContext, config, services =>
        {
            services.AddAzureStorageAccountServices();
        });

        // ---------------

        var sender = service.GetRequiredService<IMessageSender<AzureStorageQueueMessageSenderProviderTests>>();
        var correlationId = await sender.SendAsync(new
        {
            hello = "world",
        });

        this.TestContext.Write($"correlationId: {correlationId}");
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task SendAsyncTest_ByKeyed()
    {
        var configBuilder = new ConfigurationBuilder();

        configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            {$"MessageQueue:{QueueConfig}:Provider", AzureStorageGlobals.MessageProviderKey },

            {$"MessageQueue:{QueueConfig}:Config:ConnectionString", "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1" },
            {$"MessageQueue:{QueueConfig}:Config:QueueName", "test-queue" },

        });

        var config = configBuilder.Build();

        var service = MessageSenderTests.GetServiceProvider(TestContext, config, services =>
        {
            services.AddAzureStorageAccountServices();
        });

        // ---------------

        var sender = service.GetRequiredService<IMessageSender<AzureStorageQueueMessageSenderProviderTests>>();
        var correlationId = await sender.SendAsync(new
        {
            hello = "world",
        });

        this.TestContext.Write($"correlationId: {correlationId}");
    }
}
