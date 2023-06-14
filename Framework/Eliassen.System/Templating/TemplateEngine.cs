using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Templating
{
    /// <summary>
    /// Generate templating engine that will try to use best match for source and provider
    /// </summary>
    public class TemplateEngine : ITemplateEngine
    {
        private readonly IEnumerable<ITemplateSource> _sources;
        private readonly IEnumerable<ITemplateProvider> _providers;

        /// <inheritdoc/>
        public TemplateEngine(
            IEnumerable<ITemplateSource> sources,
            IEnumerable<ITemplateProvider> providers
            )
        {
            _sources = sources;
            _providers = providers;
        }

        private ITemplateSource? GetSource(string templateName, string targetName) =>
            _sources.FirstOrDefault(s => s.CanGet(templateName, targetName));
        private ITemplateProvider? GetProvider(string template, object data) =>
            _providers.FirstOrDefault(s => s.CanApply(template, data));

        /// <inheritdoc/>
        public string? Apply(string templateName, string targetName, object data) =>
            Get(templateName, targetName) switch
            {
                string template => GetProvider(template, data) switch
                {
                    ITemplateProvider provider => provider.Apply(template, data),
                    _ => null,
                },
                _ => null,
            };

        /// <inheritdoc/>
        public string? Get(string templateName, string targetName) =>
            GetSource(templateName, targetName) switch
            {
                ITemplateSource source => source.Get(templateName, targetName),
                _ => null,
            };

        /// <inheritdoc/>
        public string? SuggestedContentType(string templateName, string targetName) =>
            GetSource(templateName, targetName) switch
            {
                ITemplateSource source => source.SuggestedContentType(templateName, targetName),
                _ => null,
            };

        /// <inheritdoc/>
        public string? SuggestedFileName(string templateName, string targetName) =>
            GetSource(templateName, targetName) switch
            {
                ITemplateSource source => source.SuggestedFileName(templateName, targetName),
                _ => null,
            };
    }
}