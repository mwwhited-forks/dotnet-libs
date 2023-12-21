namespace Eliassen.System.Text.Templating;

public interface IFileTypeProvider
{
    IReadOnlyCollection<IFileType> Types { get; }
}