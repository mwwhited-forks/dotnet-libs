namespace Eliassen.Search;

public interface IGetContent<T>
{
    Task<T?> GetContentAsync(string file);
}
