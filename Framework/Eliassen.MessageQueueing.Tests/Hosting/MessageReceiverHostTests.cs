﻿using Eliassen.MessageQueueing.Hosting;
using Eliassen.MessageQueueing.Services;
using Eliassen.TestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing.Tests.Hosting;

[TestClass]
public class MessageReceiverHostTests
{
    public required TestContext TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public async Task StartStopTest()
    {
        var cancellationTokenSourceBlocker = new CancellationTokenSource();
        var cancellationTokenSource = new CancellationTokenSource();

        var mockRepo = new MockRepository(MockBehavior.Strict);
        var mockReceiverProviderFactory = mockRepo.Create<IMessageReceiverProviderFactory>();
        var mockReceiverProvider = mockRepo.Create<IMessageReceiverProvider>();

        mockReceiverProvider
            .Setup(s => s.RunAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Callback(async () =>
            {
                this.TestContext.WriteLine("Ran Child!");
                await cancellationTokenSourceBlocker.CancelAsync();
                await Task.Delay(100);
            })
            ;
        mockReceiverProviderFactory
            .Setup(s => s.Create())
            .Returns([mockReceiverProvider.Object])
            ;

        using (var host = new MessageReceiverHost(
             TestLogger.CreateLogger<MessageReceiverHost>(),
             mockReceiverProviderFactory.Object
             ))
        {
            await host.StartAsync(cancellationTokenSource.Token);

            var spinCount = 0;
            while (!cancellationTokenSourceBlocker.IsCancellationRequested)
            {
                this.TestContext.WriteLine($"Spin! : {spinCount++}");
                await Task.Yield();
            }
            await host.StopAsync(cancellationTokenSource.Token);
        }

        mockRepo.VerifyAll();
    }
}
