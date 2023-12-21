namespace Eliassen.System.Text.Templating;

public interface IFileType
{
    string Extension { get; }
    string ContentType { get; }
    bool IsTemplateType { get; }
}
