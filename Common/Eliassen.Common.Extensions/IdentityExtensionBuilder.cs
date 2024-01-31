namespace Eliassen.Common.Extensions;

/// <summary>
/// Represents a builder for configuring identity extensions.
/// </summary>
public record IdentityExtensionBuilder
{
    /// <summary>
    /// Gets or sets the identity provider to use.
    /// </summary>
    /// <remarks>
    /// Specifies the identity provider for authentication. The default value is <see cref="IdentityProviders.AzureB2C"/>.
    /// </remarks>
    public IdentityProviders IdentityProvider { get; init; } = IdentityProviders.AzureB2C;
}
