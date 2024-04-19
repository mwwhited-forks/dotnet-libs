namespace Eliassen.Documents;

public interface IGetSummary<T>
{
    Task<T?> GetSummaryAsync(string file);
}
