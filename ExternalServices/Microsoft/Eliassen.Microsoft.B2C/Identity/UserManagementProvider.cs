namespace Eliassen.Microsoft.B2C.Identity
{
    public class UserManagementProvider : IUserManagementProvider
    {
        private readonly IManageGraphUser _user;

        public UserManagementProvider(
            IManageGraphUser user
            )
        {
            _user = user;
        }

        public async Task<UserCreatedModel> CreateAccountAsync(UserCreateModel model)
        {
            var (objectid, password) = await _user.CreateGraphUserAsync(model.EmailAddress, model.FirstName, model.LastName);
            return new UserCreatedModel
            {
                Password = password ?? "",
                Username = objectid,
            };
        }
    }
}
