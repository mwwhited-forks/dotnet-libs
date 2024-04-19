namespace Eliassen.Documents;

public interface IDocumentConversion
{
    Task ConvertAsync(Stream source, string sourceContentType, Stream destination, string destinationContentType);
}
