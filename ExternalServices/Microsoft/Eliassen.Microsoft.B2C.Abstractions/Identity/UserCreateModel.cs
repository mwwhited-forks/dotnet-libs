namespace Eliassen.Microsoft.B2C.Identity;

public record UserCreateModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
}