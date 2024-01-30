﻿using Eliassen.System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Eliassen.System.Tests.Security.Cryptography;

[TestClass]
public class HashSelectorTest
{
    public required TestContext TestContext { get; set; }

    [DataTestMethod]
    [DataRow(HashTypes.Md5, typeof(Md5Hash))]
    [DataRow(HashTypes.Sha256, typeof(Sha256Hash))]
    [DataRow(HashTypes.Sha512, typeof(Sha512Hash))]
    public void DefaultHashTest(HashTypes targetType, Type expectedType)
    {
        var config = new ConfigurationBuilder().Build();
        var services = new ServiceCollection()
            .AddTransient<IConfiguration>(_ => config)
            .TryAddSystemExtensions(config, new()
            {
                DefaultHashType = targetType,
            })
            .BuildServiceProvider()
            ;
        var serializer = services.GetRequiredService<IHash>();
        Assert.IsInstanceOfType(serializer, expectedType);
    }

    [DataTestMethod]
    [DataRow(HashTypes.Md5, typeof(Md5Hash))]
    [DataRow(HashTypes.Sha256, typeof(Sha256Hash))]
    [DataRow(HashTypes.Sha512, typeof(Sha512Hash))]
    [DataRow("MD5", typeof(Md5Hash))]
    [DataRow("SHA256", typeof(Sha256Hash))]
    [DataRow("SHA512", typeof(Sha512Hash))]
    public void KeyedHashTest(object targetSerializerType, Type expectedType)
    {
        var config = new ConfigurationBuilder().Build();
        var services = new ServiceCollection()
            .AddTransient<IConfiguration>(_ => config)
            .TryAddSystemExtensions(config)
            .BuildServiceProvider()
            ;
        var serializer = services.GetRequiredKeyedService<IHash>(targetSerializerType);
        Assert.IsInstanceOfType(serializer, expectedType);
    }
}
