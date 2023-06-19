namespace Eliassen.System.Templating
{
    public interface ITemplateEngine
    {
        ITemplateContext? Get(string templateName);
        IEnumerable<ITemplateContext> GetAll(string templateName);

        ITemplateContext? Apply(string templateName, object data, Stream target);
        bool Apply(ITemplateContext context, object data, Stream target);
    }
}