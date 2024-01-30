namespace Eliassen.Common.Extensions;

public record IdentityExtensionBuilder
{
    public IdentityProviders IdentityProvider { get; init; } = IdentityProviders.AzureB2C;
}
