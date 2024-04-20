using Eliassen.Documents;
using Eliassen.Documents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eliassen.WebApi.Controllers;

/// <summary>
/// Controller for handling document-related operations.
/// </summary>
[AllowAnonymous]
[Route("[Controller]/[Action]")]
public class DocumentController : Controller
{
    private readonly IDocumentConversion _converter;
    private readonly IContentProvider _content;

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentController"/> class with the specified dependencies.
    /// </summary>
    /// <param name="converter">The document conversion service.</param>
    /// <param name="content">The content provider service.</param>
    public DocumentController(
        IDocumentConversion converter,
        IContentProvider content
        )
    {
        _converter = converter;
        _content = content;
    }

    /// <summary>
    /// Downloads the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Download(string file) =>
        await _content.DownloadAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(blob.Content, blob.ContentType, blob.FileName)
        };

    /// <summary>
    /// Retrieves the text of the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Text(string file) =>
        await _content.DownloadAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(
                await ConvertToAsync(blob.Content, blob.ContentType, "text/plain"),
                "text/plain",
                Path.ChangeExtension(blob.FileName, ".txt"))
        };

    /// <summary>
    /// Retrieves the html of the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Html(string file) =>
        await _content.DownloadAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(
                await ConvertToAsync(blob.Content, blob.ContentType, "text/html"),
                "text/html",
                Path.ChangeExtension(blob.FileName, ".html"))
        };

    /// <summary>
    /// Retrieves the pdf of the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Pdf(string file) =>
        await _content.DownloadAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(
                await ConvertToAsync(blob.Content, blob.ContentType, "application/pdf"),
                "application/pdf",
                Path.ChangeExtension(blob.FileName, ".pdf"))
        };

    private async Task<Stream> ConvertToAsync(Stream source, string sourceType, string destinationType)
    {
        var ms = new MemoryStream();
        await _converter.ConvertAsync(source, sourceType, ms, destinationType);
        ms.Position = 0;
        return ms;
    }

    /// <summary>
    /// Retrieves the summary of the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Summary(string file) =>
        await _content.SummaryAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(blob.Content, blob.ContentType, blob.FileName)
        };
}
