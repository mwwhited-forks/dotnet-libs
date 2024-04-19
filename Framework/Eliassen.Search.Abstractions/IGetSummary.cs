namespace Eliassen.Search;

public interface IGetSummary<T>
{
    Task<T?> GetSummaryAsync(string file);
}