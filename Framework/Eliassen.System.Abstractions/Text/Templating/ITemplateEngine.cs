namespace Eliassen.System.Text.Templating;

public interface ITemplateEngine
{
    ITemplateContext? Get(string templateName);
    IEnumerable<ITemplateContext> GetAll(string templateName);

    Task<ITemplateContext?> ApplyAsync(string templateName, object data, Stream target);
    Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target);
}