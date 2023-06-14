using Eliassen.System.Security.Cryptography;
using Eliassen.System.Templating;
using HandlebarsDotNet;

namespace Eliassen.Handlebars.Extensions.Templating
{
    public class HandlebarsTemplateProvider : ITemplateProvider
    {
        private readonly IHash _hash;
        private readonly IEnumerable<IHelpersRegistry> _helpersRegistry;

        public HandlebarsTemplateProvider(
            IHash hash,
            IEnumerable<IHelpersRegistry> helpersRegistry
            )
        {
            _hash = hash;
            _helpersRegistry = helpersRegistry;
        }

        public bool CanApply(string template, object data) => true;

        public string Apply(string template, object data)
        {
            // https://github.com/Handlebars-Net/Handlebars.Net
            var handlebar = HandlebarsDotNet.Handlebars.Create();

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
            var compiled = handlebar.Compile(template);
            var rendered = compiled(data);
            return rendered;
        }

    }
}