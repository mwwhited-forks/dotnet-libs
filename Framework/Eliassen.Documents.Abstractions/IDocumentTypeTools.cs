namespace Eliassen.Documents;

public interface IDocumentTypeTools
{
    IDocumentType? GetByContentType(string contentType);
    IDocumentType? GetByFileExtension(string fileExtension);
    IDocumentType? GetByFileHeader(Stream stream);
}
