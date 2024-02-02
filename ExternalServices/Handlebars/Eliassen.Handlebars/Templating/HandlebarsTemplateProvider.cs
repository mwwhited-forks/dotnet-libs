using Eliassen.System.Net.Mime;
using Eliassen.System.Security.Cryptography;
using Eliassen.System.Text.Templating;
using HandlebarsDotNet;
using HandlebarsDotNet.Extension.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Handlebars.Templating;

/// <summary>
/// Provides Handlebars template processing functionality.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="HandlebarsTemplateProvider"/> class.
/// </remarks>
/// <param name="hash">The hash provider.</param>
/// <param name="helpersRegistry">The collection of helpers registries.</param>
/// <param name="log">The logger instance.</param>
public class HandlebarsTemplateProvider(IHash hash, IEnumerable<IHelpersRegistry> helpersRegistry, ILogger<HandlebarsTemplateProvider> log) : ITemplateProvider
{
    //TODO: change the way the content types are registered

    private readonly ILogger _log = log;

    /// <summary>
    /// Gets the collection of supported content types by the template provider.
    /// 
    /// text/x-handlebars-template
    /// </summary>
    public IReadOnlyCollection<string> SupportedContentTypes { get; } = new[]
    {
         ContentTypesExtensions.Text.HandlebarsTemplate
    };

    /// <summary>
    /// Determines whether this template provider can apply template processing to the given context.
    /// </summary>
    /// <param name="context">The template context.</param>
    /// <returns><c>true</c> if the template processing can be applied; otherwise, <c>false</c>.</returns>
    public bool CanApply(ITemplateContext context) =>
        SupportedContentTypes.Any(type => string.Equals(context.TemplateContentType, type, StringComparison.InvariantCultureIgnoreCase));

    /// <summary>
    /// Asynchronously applies Handlebars template processing to the specified context, data, and target stream.
    /// </summary>
    /// <param name="context">The template context.</param>
    /// <param name="data">The data to be used during template processing.</param>
    /// <param name="target">The target stream where the processed template is written.</param>
    /// <returns>A task representing the asynchronous operation. The task result is <c>true</c> if successful, <c>false</c> otherwise.</returns>
    public async Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target)
    {
        // https://github.com/Handlebars-Net/Handlebars.Net
        var handlebar = HandlebarsDotNet.Handlebars.Create();
        handlebar.Configuration.UseJson();

        foreach (var helpersRegistry in helpersRegistry ?? Enumerable.Empty<IHelpersRegistry>())
        {
            foreach (var helper in helpersRegistry.GetBlockHelpers())
            {
                handlebar.RegisterHelper(helper.Value);
            }
            foreach (var helper in helpersRegistry.GetHelpers())
            {
                handlebar.RegisterHelper(helper.Value);
            }
        }

        //TODO: These should be abstracted out to the IoC container
        handlebar.RegisterHelper("date_now", (output, context, arguments) =>
        {
            var format = arguments.FirstOrDefault() as string;
            if (string.IsNullOrWhiteSpace(format))
            {
                output.WriteSafeString(DateTimeOffset.Now);
            }
            else
            {
                output.WriteSafeString(DateTimeOffset.Now.ToString(format));
            }
        });
        handlebar.RegisterHelper("guid_new", (output, context, arguments) => output.WriteSafeString(Guid.NewGuid()));
        handlebar.RegisterHelper("hash", (output, context, arguments) =>
        {
            var arg = arguments[0];
            var result = hash.GetHash(arg?.ToString() ?? "");
            output.WriteSafeString(result);
        });
        handlebar.RegisterHelper("log", (output, context, arguments) =>
        {
            _log.LogInformation($"{{message}}", string.Join(' ', arguments));
            return null;
        });

        var dictionary = new Dictionary<string, object>();
        handlebar.RegisterHelper("set", (output, context, arguments) =>
        {
            var key = arguments.ElementAtOrDefault(0)?.ToString();
            var value = arguments.ElementAtOrDefault(1);
            _log.LogDebug($"set: {{{nameof(key)}}}", key);
            if (!string.IsNullOrWhiteSpace(key) && !dictionary.TryAdd(key, value ?? ""))
            {
                dictionary[key] = value ?? "";
            }
        });
        handlebar.RegisterHelper("get", (output, context, arguments) =>
        {
            var key = arguments.ElementAtOrDefault(0)?.ToString();
            _log.LogDebug($"get: {{{nameof(key)}}}", key);
            if (!string.IsNullOrWhiteSpace(key) && dictionary.TryGetValue(key, out var value))
            {
                output.Write(value);
            }
        });
        handlebar.RegisterHelper("str-replace", (output, context, arguments) =>
        {
            var input = arguments.ElementAtOrDefault(0)?.ToString();
            var find = arguments.ElementAtOrDefault(1)?.ToString();
            var replacement = arguments.ElementAtOrDefault(2)?.ToString();
            //_log.LogDebug($"replace: {{{nameof(input)}}} ({{{nameof(find)}}},{{{nameof(replacement)}}})", input, find, replacement);
            if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(find))
            {
                output.Write(input.Replace(find, replacement ?? ""));
            }
        });

        using var template = context.OpenTemplate(context);
        var reader = new StreamReader(template);
        var compiled = handlebar.Compile(reader);

        using var writer = new StreamWriter(target, leaveOpen: true)
        {
            AutoFlush = true,
        };
        compiled(writer, data, context);
        await writer.FlushAsync();
        return true;
    }
}
