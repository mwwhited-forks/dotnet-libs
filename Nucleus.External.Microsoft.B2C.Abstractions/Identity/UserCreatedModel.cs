namespace Nucleus.External.Microsoft.B2C.Identity;

public record UserCreatedModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
