using Eliassen.Identity.Identity;

namespace Eliassen.Identity;

/// <summary>
/// Represents a provider for user management operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserManagementProvider"/> class.
/// </remarks>
/// <param name="user">The user manager for managing graph users.</param>
public class UserManagementProvider(IManageGraphUser user) : IUserManagementProvider
{

    /// <summary>
    /// Creates a new user account asynchronously.
    /// </summary>
    /// <param name="model">The model containing user information for account creation.</param>
    /// <returns>A task representing the asynchronous operation. The result is a model containing the created user's information.</returns>
    public async Task<UserCreatedModel> CreateAccountAsync(UserCreateModel model)
    {
        var (objectid, password) = await user.CreateGraphUserAsync(model.EmailAddress, model.FirstName, model.LastName);
        return new UserCreatedModel
        {
            Password = password ?? "",
            Username = objectid,
        };
    }
}
