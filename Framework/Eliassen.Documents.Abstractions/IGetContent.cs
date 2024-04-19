namespace Eliassen.Documents;

public interface IGetContent<T>
{
    Task<T?> GetContentAsync(string file);
}
