using System.Collections.Generic;
using System.Data;
using System.IO;
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

        /// <inheritdoc/>
        public ITemplateContext? Apply(string templateName, object data, Stream target)
        {
            var templates =
                from context in GetAll(templateName)
                from provider in _providers
                where provider.CanApply(context)
                select (context, provider);

            var template = templates.FirstOrDefault();
            if (template == default || template.context == null) return null;

            template.provider.Apply(template.context, data, target);
            return template.context;
        }

        /// <inheritdoc/>
        public bool Apply(ITemplateContext context, object data, Stream target)
        {
            var provider = _providers.FirstOrDefault(p => p.CanApply(context));
            if (provider == null) return false;
            provider.Apply(context, data, target);
            return true;
        }

        /// <inheritdoc/>
        public ITemplateContext? Get(string templateName) => 
            GetAll(templateName).FirstOrDefault();

        /// <inheritdoc/>
        public IEnumerable<ITemplateContext> GetAll(string templateName) =>
            from source in _sources
            from context in source.Get(templateName)
            orderby context.Priority
            select context;
    }
}