using Eliassen.System.Security.Cryptography;
using Eliassen.System.Templating;
using HandlebarsDotNet;
using HandlebarsDotNet.Extension.Json;
using Microsoft.Extensions.Logging;

namespace Eliassen.Handlebars.Extensions.Templating
{
    public class HandlebarsTemplateProvider : ITemplateProvider
    {
        private readonly IHash _hash;
        private readonly IEnumerable<IHelpersRegistry> _helpersRegistry;
        private readonly ILogger _log;

        public HandlebarsTemplateProvider(
            IHash hash,
            IEnumerable<IHelpersRegistry> helpersRegistry,
            ILogger<HandlebarsTemplateProvider> log
            )
        {
            _hash = hash;
            _helpersRegistry = helpersRegistry;
            _log = log;
        }

        public bool CanApply(string template, object data) => true;

        public string Apply(string template, object data)
        {
            // https://github.com/Handlebars-Net/Handlebars.Net
            var handlebar = HandlebarsDotNet.Handlebars.Create();
            handlebar.Configuration.UseJson();

            foreach (var helpersRegistry in _helpersRegistry ?? Enumerable.Empty<IHelpersRegistry>())
                foreach (var helper in helpersRegistry.GetHelpers())
                    handlebar.RegisterHelper(helper.Value);

            //TODO: These should be abstracted out to the IoC container
            handlebar.RegisterHelper("date_now", (output, context, arguments) =>
            {
                output.WriteSafeString(DateTimeOffset.Now);
            });
            handlebar.RegisterHelper("guid_new", (output, context, arguments) =>
            {
                output.WriteSafeString(Guid.NewGuid());
            });
            handlebar.RegisterHelper("hash", (output, context, arguments) =>
            {
                var arg = arguments[0];
                var result = _hash.GetHash(arg?.ToString() ?? "");
                output.WriteSafeString(result);
            });
            handlebar.RegisterHelper("log", (output, context, arguments) =>
            {
                _log.LogInformation($"{{message}}", string.Join(' ', arguments));
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

            var compiled = handlebar.Compile(template);
            var rendered = compiled(data);
            return rendered;
        }

    }
}