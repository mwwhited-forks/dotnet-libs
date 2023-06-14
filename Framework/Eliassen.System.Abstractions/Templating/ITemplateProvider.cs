namespace Eliassen.System.Templating
{
    public interface ITemplateProvider
    {
        bool CanApply(string template, object data);
        string? Apply(string template, object data);
    }
}