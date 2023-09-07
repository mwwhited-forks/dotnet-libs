namespace Nucleus.External.Microsoft.B2C.Identity;

public interface IUserManagementProvider
{
    Task<UserCreatedModel> CreateAccountAsync(UserCreateModel model);
}
