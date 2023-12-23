using Eliassen.Microsoft.B2C.Identity;
using Eliassen.System.Extensions.Configuration;
using Eliassen.TestUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Eliassen.Microsoft.B2C.Tests;

[TestClass]
public class ManageGraphUserIntegrationTests
{
    public TestContext TestContext { get; set; } = null!;

    private IConfiguration GetConfiguration(IServiceCollection services) =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(
                        (ConfigKeys.Azure.ADB2C.ClientID, "6721294c-f956-4290-9629-6455b92fbcf2"),
                        (ConfigKeys.Azure.ADB2C.Issuer, "f94cddd5-af89-42f6-9a81-d7898aef64a3"),
                        (ConfigKeys.Azure.ADB2C.Tenant, "lightwellnucleusdev"),
                        (ConfigKeys.Azure.ADB2C.ClientSecret, "bf68Q~SI7x0osvcUaA8qR-oE9xA3ZTqNZVvl.b86")
                )
            .Build();

    private IServiceProvider GetIntegrationServiceProvider()
    {
        var services = new ServiceCollection()
            .AddLogging(logging => logging.AddConsole())
            .AddSingleton<IManageGraphUser, ManageGraphUser>()
            .AddSingleton<IIdentityManager, ManageGraphUser>()
            ;

        services.Replace(ServiceDescriptor.Transient(_ => GetConfiguration(services)));

        return services.BuildServiceProvider();
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task CreateGraphUserAsyncTest_Integration_Exists()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();
        var emailAddress = $"mwwhited@gmail.com";


        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IManageGraphUser>();

        var result = await manageGraphUser.CreateGraphUserAsync(
            email: emailAddress,
            firstName: "Matthew",
        lastName: "Whited");

        this.TestContext.WriteLine($"emailAddress: {emailAddress}");
        this.TestContext.WriteLine($"result: {result}");

        // Assert
        Assert.AreNotEqual(Guid.Empty.ToString(), result.objectId);

        // Verify
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task GetGraphUsersByEmailTest_Integration_Exists()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();
        var emailAddress = $"mwwhited@gmail.com";

        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IIdentityManager>();

        var result = await manageGraphUser.GetGraphUsersByEmail(emailAddress);

        if (result == null) throw new ApplicationException($"{nameof(manageGraphUser.GetGraphUsersByEmail)} should return a value");

        foreach (var item in result)
        {
            this.TestContext.WriteLine($"item: {item.FirstName} {item.LastName} ({item.UserName})");
        }

        this.TestContext.WriteLine($"emailAddress: {emailAddress}");
        this.TestContext.WriteLine($"result: {result}");

        // Assert
        foreach (var customer in result.ToArray())
            Assert.AreNotEqual(Guid.Empty.ToString(), customer.EmailAddress);

        // Verify
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task CreateGraphUserAsyncTest_Integration_DoesNotExists()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();
        var emailAddress = $"mwwhited.{Guid.NewGuid()}@gmail.com";

        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IManageGraphUser>();

        var result = await manageGraphUser.CreateGraphUserAsync(
            email: emailAddress,
            firstName: "Matthew",
            lastName: "Whited");

        this.TestContext.WriteLine($"emailAddress: {emailAddress}");
        this.TestContext.WriteLine($"result: {result}");

        // Assert
        Assert.AreNotEqual(Guid.Empty.ToString(), result.objectId);

        // Verify
    }


    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task CreateIdentityUserAsyncTest_Integration_Exists()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();
        var emailAddress = $"mwwhited@gmail.com";


        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IIdentityManager>();

        var result = await manageGraphUser.CreateIdentityUserAsync(
            email: emailAddress,
            firstName: "Matthew",
        lastName: "Whited");

        this.TestContext.WriteLine($"emailAddress: {emailAddress}");
        this.TestContext.WriteLine($"result: {result}");

        // Assert
        Assert.AreNotEqual(Guid.Empty.ToString(), result.objectId);

        // Verify
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task RemoveGraphUserAsyncTest_Integration()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();

        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IManageGraphUser>();
        string userId = "581c2f51-bda2-4ca2-9bab-6fedd1470fc1";

        var result = await manageGraphUser.RemoveGraphUserAsync(userId);

        // Assert
        Assert.IsTrue(result);

        // Verify
    }

    [TestMethod]
    [TestCategory(TestCategories.DevLocal)]
    public async Task RemoveIdentityUserAsyncTest_Integration()
    {
        // Stage
        var serviceProvider = GetIntegrationServiceProvider();

        // Mock

        // Test
        var manageGraphUser = serviceProvider.GetRequiredService<IIdentityManager>();
        string userId = "581c2f51-bda2-4ca2-9bab-6fedd1470fc1";

        var result = await manageGraphUser.RemoveIdentityUserAsync(userId);

        // Assert
        Assert.IsTrue(result);

        // Verify
    }
}
