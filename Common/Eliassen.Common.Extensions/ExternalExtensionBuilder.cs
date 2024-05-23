﻿using Eliassen.Apache.Tika;
using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.MailKit.Services;
using Eliassen.MongoDB.Extensions;
using Eliassen.Ollama;
using Eliassen.OpenAI.AI.Services;
using Eliassen.OpenSearch;
using Eliassen.Qdrant;
using Eliassen.SBert;

namespace Eliassen.Common.Extensions;

/// <summary>
/// Represents a builder for configuring external extensions.
/// </summary>
public record ExternalExtensionBuilder
{
    /// <summary>
    /// Gets or sets the configuration section name for MongoDB database options.
    /// </summary>
    /// <value>
    /// The configuration section name for MongoDB database options. Default is "MongoDatabaseOptions".
    /// </value>
    public string MongoDatabaseConfigurationSection { get; init; } = nameof(MongoDatabaseOptions);

    /// <summary>
    /// Gets or sets the configuration section name for Azure Blob Container options.
    /// </summary>
    /// <value>
    /// The configuration section name for Azure Blob Container options. Default is "AzureBlobContainerOptions".
    /// </value>
    public string AzureBlobProviderOptionSection { get; init; } = nameof(AzureBlobProviderOptions);

    /// <summary>
    /// Gets or sets the configuration section name for SMTP client options (MailKit).
    /// </summary>
    /// <value>
    /// The configuration section name for SMTP client options (MailKit). Default is "MailKitSmtpClientOptions".
    /// </value>
    public string SmtpConfigurationSection { get; init; } = nameof(MailKitSmtpClientOptions);

    /// <summary>
    /// Gets or sets the configuration section name for IMAP client options (MailKit).
    /// </summary>
    /// <value>
    /// The configuration section name for IMAP client options (MailKit). Default is "MailKitImapClientOptions".
    /// </value>
    public string ImapConfigurationSection { get; init; } = nameof(MailKitImapClientOptions);

    /// <summary>
    /// Gets or sets the configuration section name for OpenAI client options.
    /// </summary>
    public string OpenAIClientOptionsSection { get; init; } = nameof(OpenAIClientOptions);

    /// <summary>
    /// Gets or sets the configuration section name for SentenceEmbeddingOptions.
    /// </summary>
    public string SentenceEmbeddingOptionSection { get; init; } = nameof(SentenceEmbeddingOptions);

    /// <summary>
    /// Gets or sets the configuration section name for Qdrant options.
    /// </summary>
    public string QdrantOptionSection { get; init; } = nameof(QdrantOptions);

    /// <summary>
    /// Gets or sets the configuration section name for OpenSearch options.
    /// </summary>
    public string OpenSearchOptionSection { get; init; } = nameof(OpenSearchOptions);

    /// <summary>
    /// Gets or sets the configuration section name for Ollama Api Client options.
    /// </summary>
    public string OllamaApiClientOptionSection { get; init; } = nameof(OllamaApiClientOptions);

    /// <summary>
    /// gets or sets the configuration section name of Apache Tika Client options.
    /// </summary>
    public string ApacheTikaClientOptionSection { get; init; } = nameof(ApacheTikaClientOptions);
}