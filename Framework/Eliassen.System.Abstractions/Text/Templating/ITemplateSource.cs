namespace Eliassen.System.Text.Templating;

public interface ITemplateSource
{
    IEnumerable<ITemplateContext> Get(string templateName);
}
