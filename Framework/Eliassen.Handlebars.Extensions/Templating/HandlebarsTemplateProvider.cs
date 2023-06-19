using Eliassen.System.Security.Cryptography;
using Eliassen.System.Templating;
using HandlebarsDotNet;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Extension.Json;
using HandlebarsDotNet.Helpers;
using Microsoft.Extensions.Logging;

namespace Eliassen.Handlebars.Extensions.Templating
{
    public class HelpersRegistry : IHelpersRegistry
    {
        public IIndexed<string, IHelperDescriptor<BlockHelperOptions>> GetBlockHelpers()
        {
            throw new NotImplementedException();
        }

        public IIndexed<string, IHelperDescriptor<HelperOptions>> GetHelpers()
        {
            throw new NotImplementedException();
        }
    }

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

        public bool CanApply(ITemplateContext context) =>
            string.Equals(context.TemplateContentType, "text/x-handlebars-template", StringComparison.InvariantCultureIgnoreCase);

        public async Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target)
        {
            // https://github.com/Handlebars-Net/Handlebars.Net
            var handlebar = HandlebarsDotNet.Handlebars.Create();
            handlebar.Configuration.UseJson();


            foreach (var helpersRegistry in _helpersRegistry ?? Enumerable.Empty<IHelpersRegistry>())
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
}