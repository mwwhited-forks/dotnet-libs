using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.MailKit.Services;
using Eliassen.MongoDB.Extensions;
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
    public string OpenAIClientOptionSection { get; init; } = nameof(OpenAIClientOptionSection);

    /// <summary>
    /// Gets or sets the configuration section name for SBert options.
    /// </summary>
    public string SBertOptionSection { get; init; } = nameof(SBertOptions);

    /// <summary>
    /// Gets or sets the configuration section name for Qdrant options.
    /// </summary>
    public string QdrantOptionSection { get; init; } = nameof(QdrantOptions);

    /// <summary>
    /// Gets or sets the configuration section name for OpenSearch options.
    /// </summary>
    public string OpenSearchOptionSection { get; init; } = nameof(OpenSearchOptions);
}
