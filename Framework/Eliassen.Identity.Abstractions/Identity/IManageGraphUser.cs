namespace Eliassen.Identity.Identity;

/// <summary>
/// Represents a service for managing users in the Microsoft Graph.
/// </summary>
[Obsolete]
public interface IManageGraphUser
{
    /// <summary>
    /// Creates a new user in the Microsoft Graph asynchronously with the specified details.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="firstName">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the object ID and an optional password for the created user.</returns>
    Task<(string objectId, string? password)> CreateGraphUserAsync(string email, string firstName, string lastName);

    /// <summary>
    /// Removes a user from the Microsoft Graph asynchronously based on the specified user ID.
    /// </summary>
    /// <param name="userId">The user ID of the user to remove.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is <c>true</c> if the user was successfully removed; otherwise, <c>false</c>.</returns>
    Task<bool> RemoveGraphUserAsync(string userId);
}
