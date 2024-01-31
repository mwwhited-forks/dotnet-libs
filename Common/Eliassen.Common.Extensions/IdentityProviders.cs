namespace Eliassen.Common.Extensions;

/// <summary>
/// Specifies different identity providers for authentication.
/// </summary>
public enum IdentityProviders
{
    /// <summary>
    /// Represents no specific identity provider.
    /// </summary>
    None,

    /// <summary>
    /// Represents the Azure B2C identity provider.
    /// </summary>
    AzureB2C,

    /// <summary>
    /// Represents the Keycloak identity provider.
    /// </summary>
    Keycloak,
}
