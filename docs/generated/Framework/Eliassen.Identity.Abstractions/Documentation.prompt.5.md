Create documentation for the follow source code. 

The files should be in markdown.
When reasonable include class diagrams, component models and sequence diagrams in Plant UML.
PlantUML blocks should all be identified with "```plantuml" and closed with "```"

## Source Files

```UserCreateModel.cs
namespace Eliassen.Identity;

/// <summary>
/// Represents a model for creating a user in Microsoft B2C Identity.
/// </summary>
public record UserCreateModel
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public required string EmailAddress { get; set; }
}

```

```UserIdentityModel.cs
namespace Eliassen.Identity;

/// <summary>
/// Represents a model for user identity information.
/// </summary>
public record UserIdentityModel
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user should be forced to change their password at the next sign-in.
    /// </summary>
    public bool? ForcePasswordChangeNextSignIn { get; set; }
}

```
