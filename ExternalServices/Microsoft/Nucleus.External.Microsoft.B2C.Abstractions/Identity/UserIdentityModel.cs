namespace Nucleus.External.Microsoft.B2C.Identity;

public record UserIdentityModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public bool? ForcePasswordChangeNextSignIn { get; set; }

}
