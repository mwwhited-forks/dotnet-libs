using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;

namespace Nucleus.External.Microsoft.B2C.Identity
{
    public class ManageGraphUser : IManageGraphUser
    {
        private readonly ILogger<ManageGraphUser> _log;
        private readonly IConfiguration _config;

        public ManageGraphUser(
            ILogger<ManageGraphUser> log,
            IConfiguration config
            )
        {
            _log = log;
            _config = config;
        }

        // https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/9610f1f473a23fab57aa1a4cf5efa2eed6c37d2b/docs/tokencredentials.md

        private TokenCredential GetAuthProvider()
        {
            var config = new
            {
                clientId = _config[ConfigKeys.Azure.ADB2C.ClientID],
                tenantId = _config[ConfigKeys.Azure.ADB2C.Issuer],
                clientSecret = _config[ConfigKeys.Azure.ADB2C.ClientSecret],
            };

            var token = new ClientSecretCredential(config.tenantId, config.clientId, config.clientSecret);

            return token;
        }

        public async Task<(string objectId, string? password)> CreateGraphUserAsync(string email, string firstName, string lastName)
        {
            try
            {
                // Set up the Microsoft Graph service client with client credentials
                var graphClient = new GraphServiceClient(GetAuthProvider());

                // Query existing users by email, iff it already exists, return that id.
                var existingUsers = await graphClient.Users
                    .Request()
                    .Filter($"mail eq '{email}'")
                    .Select(u => new
                    {
                        u.Id,
                        u.Mail
                    })
                    .GetAsync();
                if (existingUsers.Count > 0)
                {
                    return (existingUsers[0].Id, null);
                }

                var password = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                var graphUser = await graphClient.Users
                    .Request()
                    .AddAsync(new User
                    {
                        GivenName = firstName,
                        Surname = lastName,
                        DisplayName = $"{firstName} {lastName}",
                        Mail = email,
                        Identities = new List<ObjectIdentity>
                        {
                                new ObjectIdentity()
                                {
                                    SignInType = "emailAddress",
                                    Issuer = $"{_config[ConfigKeys.Azure.ADB2C.Tenant]}.onmicrosoft.com",
                                    IssuerAssignedId = email,
                                }
                        },
                        PasswordProfile = new PasswordProfile()
                        {
                            Password = password,
                            ForceChangePasswordNextSignIn = true
                        },
                        PasswordPolicies = "DisablePasswordExpiration",
                    });

                return (graphUser.Id, password);
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message);
                _log.LogDebug(ex.StackTrace);
                throw;
            }
        }
        public async Task<bool> RemoveGraphUserAsync(string userId)
        {
            try
            {
                // Set up the Microsoft Graph service client with client credentials
                var graphClient = new GraphServiceClient(GetAuthProvider());

                var existingUsers = await graphClient
                    .DirectoryObjects
                    .GetByIds(new[] { userId })
                    .Request()
                    .PostAsync();

                if (existingUsers.Count > 0)
                {
                    await graphClient.Users[userId]
                                         .Request()
                                         .DeleteAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex.Message);
                _log.LogDebug(ex.StackTrace);
                return false;
            }
        }
    }
}
