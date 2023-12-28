using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.System.Text.Templating;

/// <summary>
/// Generate templating engine that will try to use best match for source and provider
/// </summary>
public class TemplateEngine(
    IEnumerable<ITemplateSource> sources,
    IEnumerable<ITemplateProvider> providers,
    ILogger<TemplateEngine> logger
        ) : ITemplateEngine
{
    private readonly ILogger _logger = logger;

    public virtual async Task<ITemplateContext?> ApplyAsync(string templateName, object data, Stream target)
    {
        _logger.LogInformation(
            $"Apply {{{nameof(templateName)}}} => {{{nameof(data)}}}",
            templateName,
            data
            );

        var templates =
            from context in GetAll(templateName)
            from provider in providers
            where provider.CanApply(context)
            select (context, provider);

        var template = templates.FirstOrDefault();
        if (template == default || template.context == null)
        {
            _logger.LogInformation(
                $"No template {{{nameof(templateName)}}}",
                templateName
                );
            return null;
        }

        if (await template.provider.ApplyAsync(template.context, data, target))
        {
            _logger.LogInformation(
                $"Applied {{{nameof(templateName)}}} => {{{nameof(template)}}}",
                templateName,
                template
                );
            return template.context;
        }

        return null;
    }

    public virtual async Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target)
    {
        var provider = providers.FirstOrDefault(p => p.CanApply(context));
        if (provider == null) return false;
        return await provider.ApplyAsync(context, data, target);
    }

    public virtual ITemplateContext? Get(string templateName) =>
        GetAll(templateName).FirstOrDefault();

    public virtual IEnumerable<ITemplateContext> GetAll(string templateName) =>
        from source in sources
        from context in source.Get(templateName)
        orderby context.Priority
        select context;
}