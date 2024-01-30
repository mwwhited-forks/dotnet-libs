using Eliassen.Identity.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Eliassen.Keycloak.Identity;

public class ManageKeycloakUser(
    ILogger<ManageKeycloakUser> log,
    IOptions<KeycloakIdentityOptions> config
        ) : IManageGraphUser, IIdentityManager
{
    private readonly ILogger _log = log;
    private readonly IOptions<KeycloakIdentityOptions> config = config;

    public Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string email) =>
         throw new NotSupportedException();

    public Task<(string objectId, string? password)> CreateIdentityUserAsync(string email, string firstName, string lastName) =>
        CreateGraphUserAsync(email, firstName, lastName);

    public Task<(string objectId, string? password)> CreateGraphUserAsync(string email, string firstName, string lastName) =>
         throw new NotSupportedException();

    public Task<bool> RemoveIdentityUserAsync(string objectId) => RemoveGraphUserAsync(objectId);

    public Task<bool> RemoveGraphUserAsync(string userId) =>
         throw new NotSupportedException();
}
