namespace Eliassen.System.Templating
{
    public interface ITemplateEngine
    {
        string? Get(string templateName, string targetName);
        string? Apply(string templateName, string targetName, object data);

        string? SuggestedFileName(string templateName, string targetName);
        string? SuggestedContentType(string templateName, string targetName);
    }
}