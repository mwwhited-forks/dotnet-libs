namespace Eliassen.System.Templating
{
    public interface ITemplateSource
    {
        bool CanGet(string templateName, string targetName);
        string? Get(string templateName, string targetName);
        string? SuggestedFileName(string templateName, string targetName);
        string? SuggestedContentType(string templateName, string targetName);
    }
}