namespace Eliassen.Search;

public interface ISummerizeContent
{
    Task<string> GenerateSummaryAsync(string input);
}

