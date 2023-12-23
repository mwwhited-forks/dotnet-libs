using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Eliassen.Microsoft.B2C.Identity;

public class ManageGraphUser : IManageGraphUser, IIdentityManager
{
    private readonly ILogger _log;
    private readonly IConfiguration _config;

    public ManageGraphUser(
        ILogger<ManageGraphUser> log,
        IConfiguration config
        )
    {
        _log = log;
        _config = config;
    }

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


    public async Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string email)
    {
        // Set up the Microsoft Graph service client with client credentials
        var graphClient = new GraphServiceClient(GetAuthProvider());

        // Query existing users by email, iff it already exists, return that id.
        var existingUsers = await graphClient.Users.GetAsync(user =>
        {
            user.QueryParameters.Select = [
                nameof(User.Id),
                nameof(User.Mail),
                nameof(User.GivenName),
                nameof(User.Surname),
                "PasswordProfile.ForceChangePasswordNextSignIn",
            ];
            user.QueryParameters.Top = 1;
            user.QueryParameters.Filter = $"mail eq '{email}'";
        });

        return existingUsers?.Value?.Select(r => new UserIdentityModel()
        {
            UserName = r.Id,
            FirstName = r.GivenName,
            LastName = r.Surname,
            EmailAddress = r.Mail,
            ForcePasswordChangeNextSignIn = r.PasswordProfile?.ForceChangePasswordNextSignIn ?? false
        })?.ToList() ?? new List<UserIdentityModel>();
    }

    public Task<(string objectId, string? password)> CreateIdentityUserAsync(string email, string firstName, string lastName) =>
        CreateGraphUserAsync(email, firstName, lastName);

    public async Task<(string objectId, string? password)> CreateGraphUserAsync(string email, string firstName, string lastName)
    {
        try
        {
            // Set up the Microsoft Graph service client with client credentials
            var graphClient = new GraphServiceClient(GetAuthProvider());

            // Query existing users by email, iff it already exists, return that id.
            var existingUsers = await graphClient.Users.GetAsync(user =>
            {
                user.QueryParameters.Select = ["Id", "Mail"];
                user.QueryParameters.Top = 1;
                user.QueryParameters.Filter = $"mail eq '{email}'";
            });

            var existingId = existingUsers?.Value?.FirstOrDefault()?.Id;

            if (!string.IsNullOrWhiteSpace(existingId))
            {
                _log.LogInformation($"Exists: {{{nameof(email)}}}", email);
                return (existingId, null);
            }

            var password = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            _log.LogInformation($"Creating: {{{nameof(email)}}}", email);
            var graphUser = await graphClient.Users.PostAsync(new User
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

            if (graphUser?.Id == null)
                throw new ApplicationException($"Unable to create user for {email}");

            _log.LogInformation($"Created: {{{nameof(email)}}}", email);
            return (graphUser.Id, password);
        }
        catch (Exception ex)
        {
            _log.LogError($"Error: {{{nameof(ex.Message)}}}", ex.Message);
            _log.LogDebug($"Error: {{{nameof(Exception)}}}", ex);
            throw;
        }
    }

    public Task<bool> RemoveIdentityUserAsync(string objectId) => RemoveGraphUserAsync(objectId);
    public async Task<bool> RemoveGraphUserAsync(string userId)
    {
        try
        {
            // Set up the Microsoft Graph service client with client credentials
            var graphClient = new GraphServiceClient(GetAuthProvider());

            var existingUsers = await graphClient.DirectoryObjects.GetByIds.PostAsync(
                new global::Microsoft.Graph.DirectoryObjects.GetByIds.GetByIdsPostRequestBody
                {
                    Ids = new() { userId },
                });

            if (existingUsers?.Value?.Count > 0)
            {
                _log.LogInformation($"Deleting: {{{nameof(userId)}}}", userId);
                await graphClient.Users[userId].DeleteAsync();
                _log.LogInformation($"Deleted: {{{nameof(userId)}}}", userId);
            }
            else
            {
                _log.LogInformation($"Does not exist: {{{nameof(userId)}}}", userId);
            }

            return true;
        }
        catch (Exception ex)
        {
            _log.LogError($"Error: {{{nameof(ex.Message)}}}", ex.Message);
            _log.LogDebug($"Error: {{{nameof(Exception)}}}", ex);
            return false;
        }
    }

}
