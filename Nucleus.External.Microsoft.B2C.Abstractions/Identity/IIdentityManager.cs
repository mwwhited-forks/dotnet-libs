namespace Nucleus.External.Microsoft.B2C.Identity;

public interface IIdentityManager
{
    Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string emailAddress);
    Task<string> CreateIdentityUserAsync(string email, string firstName, string lastName);
    Task<bool> RemoveIdentityUserAsync(string objectId);
}
