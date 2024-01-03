﻿using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System;

namespace Eliassen.Azure.StorageAccount.MessageQueueing;

/// <summary>
/// Factory for creating instances of <see cref="QueueClient"/> for Azure Storage Queues.
/// </summary>
public class QueueClientFactory : IQueueClientFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="QueueClient"/> based on the provided configuration section.
    /// </summary>
    /// <param name="config">The configuration section containing connection string and queue name.</param>
    /// <returns>A new instance of <see cref="QueueClient"/> for the specified Azure Storage Queue.</returns>
    /// <exception cref="ApplicationException">
    /// Thrown if the required configuration values ("ConnectionString" or "QueueName") are missing.
    /// </exception>
    public QueueClient Create(IConfigurationSection config) =>
         new(
            config["ConnectionString"] ?? throw new ApplicationException($"Configuration \"{config.Path}:ConnectionString\" is missing"),
            config["QueueName"] ?? throw new ApplicationException($"Configuration \"{config.Path}:QueueName\" is missing"),
            new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64,
            });
}