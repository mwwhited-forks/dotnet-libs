namespace Nucleus.External.Microsoft.B2C.Identity;

public interface IManageGraphUser
{
    Task<(string objectId, string? password)> CreateGraphUserAsync(string email, string firstName, string lastName);

    Task<bool> RemoveGraphUserAsync(string userId);

}
