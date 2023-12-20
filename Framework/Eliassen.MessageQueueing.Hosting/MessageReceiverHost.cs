using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.WebApi.Workers;

public class MessageReceiverHost : IHostedService, IDisposable
{
    private readonly ILogger _logger;
    private readonly IMessageReceiverProviderFactory _factory;

    private readonly List<Task> _tasks = new();
    private readonly CancellationTokenSource _tokenSource = new();

    public MessageReceiverHost(
        ILogger<MessageReceiverHost> logger,
        IMessageReceiverProviderFactory factory
        )
    {
        _logger = logger;
        _factory = factory;
    }

    public void Dispose()
    {
        _logger.LogInformation("Request Dispose");
        _tokenSource.Cancel();
        _logger.LogInformation("Complete Dispose");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (_tasks.Count > 0)
        {
            throw new InvalidOperationException($"Already started!");
        }

        _logger.LogInformation("Request Start");

        var providers = _factory.Create().ToArray();

        var token = _tokenSource.Token;

        foreach (var provider in providers)
        {
            _tasks.Add(Task.Run(() => StartProvider(provider, token)));
        }

        _logger.LogInformation("Completed Start");

        return Task.CompletedTask;
    }

    private async Task StartProvider(IMessageReceiverProvider provider, CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation($"Starting: {{{nameof(provider)}}}", provider);
                var task = provider.RunAsync(token);
                _logger.LogInformation($"Started: {{{nameof(provider)}}}", provider);
                await task;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {{{nameof(provider)}}}: {{{nameof(Exception)}}}", provider, ex.Message);
                _logger.LogDebug($"Error: {{{nameof(provider)}}}: {{{nameof(Exception)}}}", provider, ex.ToString());

                _logger.LogInformation($"Waiting for restart: {{{nameof(provider)}}}", provider);
                await Task.Delay(10000); //TODO: this should be configurable
            }
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Stop");

        await _tokenSource.CancelAsync();
        await Task.WhenAll(_tasks);
        _tasks.Clear();

        _logger.LogInformation("Completed Stop");
    }
}
