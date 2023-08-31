using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace Nucleus.External.Microsoft.B2C.Identity
{
    public class B2CIdentityManager : IIdentityManager
    {
        private readonly ILogger<B2CIdentityManager> _log;
        private readonly IConfiguration _config;
        private GraphServiceClient _graphServiceClient { get; set; }

        public B2CIdentityManager(
            ILogger<B2CIdentityManager> log,
            IConfiguration config)
        {
            _log = log;
            _config = config;
            _graphServiceClient = CreateGraphServiceClient();
        }

        private GraphServiceClient CreateGraphServiceClient()
        {
            // Initialize the client credential auth provider
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(_config[ConfigKeys.Azure.ADB2C.ClientID])
                .WithTenantId(_config[ConfigKeys.Azure.ADB2C.Issuer])
                .WithClientSecret(_config[ConfigKeys.Azure.ADB2C.ClientSecret])
                .Build();
            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

            // Set up the Microsoft Graph service client with client credentials
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);
            return graphClient;
        }

        public async Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string emailAddress)
        {
            var existingUsers = await _graphServiceClient.Users
                    .Request()
                    .Filter($"mail eq '{emailAddress}'")
                    .Select(u => new
                    {
                        u.Id,
                        u.Mail,
                        u.GivenName,
                        u.Surname,
                        u.PasswordProfile.ForceChangePasswordNextSignIn
                    })
                    .GetAsync();
            if (existingUsers != null && existingUsers.Count > 0)
                return existingUsers.Select(r => new UserIdentityModel()
                {
                    UserName = r.Id,
                    FirstName = r.GivenName,
                    LastName = r.Surname,
                    EmailAddress = r.Mail,
                    ForcePasswordChangeNextSignIn = r.PasswordProfile.ForceChangePasswordNextSignIn
                }).ToList();
            else
                return null;
        }

        public async Task<string> CreateIdentityUserAsync(string email, string firstName, string lastName)
        {
            try
            {
                var tenant = _config[ConfigKeys.Azure.ADB2C.Domain];
                var existingUsers = await _graphServiceClient.Users
                    .Request()
                    .Filter($"identities/any(c:c/issuerAssignedId eq '{email}' and c/issuer eq '{tenant}')")
                    .Select(u => new
                    {
                        u.Id,
                        u.Mail
                    })
                    .GetAsync();

                if (existingUsers.Count > 0)
                    return existingUsers[0].Id;

                var password = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                var graphUser = await _graphServiceClient.Users
                    .Request()
                    .AddAsync(new global::Microsoft.Graph.User
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

                return graphUser.Id;
            }
            catch (Exception ex)
            {
                _log.LogDebug($"{{{nameof(ex.Message)}}}: {{{nameof(ex.StackTrace)}}}", ex.Message, ex.StackTrace);
                throw;
            }
        }

        public async Task<bool> RemoveIdentityUserAsync(string objectId)
        {
            try
            {
                var existingUsers = await _graphServiceClient
                    .DirectoryObjects
                    .GetByIds(new[] { objectId })
                    .Request()
                    .PostAsync();

                if (existingUsers.Count > 0)
                    await _graphServiceClient.Users[objectId]
                                         .Request()
                                         .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                _log.LogDebug($"{{{nameof(ex.Message)}}}: {{{nameof(ex.StackTrace)}}}", ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}
