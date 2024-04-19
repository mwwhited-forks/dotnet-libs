namespace Eliassen.Documents;

public interface IDocumentConversionChainBuilder
{
    ChainStep[] Steps(string sourceContentType, string destinationContentType);
}
