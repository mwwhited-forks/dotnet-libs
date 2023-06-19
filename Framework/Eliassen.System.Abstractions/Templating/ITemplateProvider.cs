namespace Eliassen.System.Templating
{
    public interface ITemplateProvider
    {
        bool CanApply(ITemplateContext context);
        bool Apply(ITemplateContext context, object data, Stream target);
    }
}