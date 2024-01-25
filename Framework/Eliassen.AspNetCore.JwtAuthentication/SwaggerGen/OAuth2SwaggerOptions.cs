namespace Eliassen.AspNetCore.JwtAuthentication.SwaggerGen;

/// <summary>
/// Represents the options for configuring OAuth2 in Swagger.
/// </summary>
public class OAuth2SwaggerOptions
{
    /// <summary>
    /// Gets or sets the claim that Swagger will use to determine the authenticated user's API access.
    /// </summary>
    public string UserReadApiClaim { get; set; } = null!;

    /// <summary>
    /// Gets or sets the URL for the authorization endpoint.
    /// </summary>
    public string AuthorizationUrl { get; set; } = null!;

    /// <summary>
    /// Gets or sets the URL for the token endpoint.
    /// </summary>
    public string TokenUrl { get; set; } = null!;
}
