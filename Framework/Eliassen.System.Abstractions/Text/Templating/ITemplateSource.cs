namespace Eliassen.System.Text.Templating;

public interface ITemplateSource
{
    IEnumerable<ITemplateContext> Get(string templateName);
}


public interface IFileType
{
    string Extension { get; }
    string ContentType { get; }
    bool IsTemplateType { get; }
}

public interface IFileTypeProvider
{
    IReadOnlyCollection<IFileType> Types { get; }
}