namespace Nucleus.AspNetCore.Mvc;
public class AzureB2CConfig
{
    public const string ConfigKey = "Azure:AdB2C";

    public string? Instance { get; set; }
    public string? ClientId { get; set; }
    public string? Domain { get; set; }
    public string? SignUpSignInPolicyId { get; set; }
    public string? Issuer { get; set; }
    public string? Policy { get; set; }
    public string? Tenant { get; set; }

    public string AuthorizationUrl => $"https://{Tenant}.b2clogin.com/{Tenant}.onmicrosoft.com/oauth2/v2.0/authorize?p={SignUpSignInPolicyId}";
    public string TokenUrl => $"https://{Tenant}.b2clogin.com/{Tenant}.onmicrosoft.com/oauth2/v2.0/token?p={SignUpSignInPolicyId}";

    public string? UserReadApiClaim { get; set; }
}