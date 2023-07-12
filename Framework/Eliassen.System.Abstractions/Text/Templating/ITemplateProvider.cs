namespace Eliassen.System.Text.Templating
{
    public interface ITemplateProvider
    {
        bool CanApply(ITemplateContext context);
        Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target);
    }
}