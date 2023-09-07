using Eliassen.System.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Extensions.Configuration;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddInMemoryCollection(
        this IConfigurationBuilder configurationBuilder,
        IEnumerable<(string key, string? value)> initialData) =>
        configurationBuilder.AddInMemoryCollection(
            initialData
            .GroupBy(i => i.key)
            .ToDictionary(i => i.Key, i => i.First().value)
            );

    public static IConfigurationBuilder AddInMemoryCollection(
        this IConfigurationBuilder configurationBuilder,
        (string key, string? value) item,
        params (string key, string? value)[] initialData) =>
        configurationBuilder.AddInMemoryCollection(
            new[] { item }.Concat(initialData)
            );
}