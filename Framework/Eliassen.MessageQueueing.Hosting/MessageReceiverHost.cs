using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.WebApi.Workers;

/// <summary>
/// Hosted service responsible for starting and stopping message receivers based on the configured providers.
/// </summary>
public class MessageReceiverHost : IHostedService, IDisposable
{
    private readonly ILogger _logger;
    private readonly IMessageReceiverProviderFactory _factory;

    private readonly List<Task> _tasks = [];
    private readonly CancellationTokenSource _tokenSource = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageReceiverHost"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="factory">The message receiver provider factory.</param>
    public MessageReceiverHost(
        ILogger<MessageReceiverHost> logger,
        IMessageReceiverProviderFactory factory
    )
    {
        _logger = logger;
        _factory = factory;
    }

    /// <summary>
    /// Disposes of the resources used by the <see cref="MessageReceiverHost"/>.
    /// </summary>
    public void Dispose()
    {
        _logger.LogInformation("Request Dispose");
        _tokenSource.Cancel();
        _logger.LogInformation("Complete Dispose");
    }

    /// <summary>
    /// Starts the message receiver host.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the start operation.</returns>
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
            _tasks.Add(Task.Run(() => StartProvider(provider, token), cancellationToken));
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
                await Task.Delay(10000, token); // TODO: this should be configurable
            }
        }
    }

    /// <summary>
    /// Stops the message receiver host.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the stop operation.</returns>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Stop");

        await _tokenSource.CancelAsync();
        await Task.WhenAll(_tasks);
        _tasks.Clear();

        _logger.LogInformation("Completed Stop");
    }
}