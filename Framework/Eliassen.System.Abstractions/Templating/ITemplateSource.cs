namespace Eliassen.System.Templating
{
    public interface ITemplateSource
    {
        IEnumerable<ITemplateContext> Get(string templateName);
    }
}