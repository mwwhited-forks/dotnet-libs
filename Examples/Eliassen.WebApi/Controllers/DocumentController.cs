using Eliassen.Documents;
using Eliassen.Documents.Depercated;
using Eliassen.Documents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
    private readonly IDocumentTypeTools _documentTypes;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DocumentController"/> class with the specified dependencies.
    /// </summary>
    /// <param name="converter">The document conversion service.</param>
    /// <param name="content">The content provider service.</param>
    /// <param name="documentTypes">The existing type definitions service.</param>
    /// <param name="logger">The logger service.</param>
    public DocumentController(
        IDocumentConversion converter,
        IContentProvider content,
        IDocumentTypeTools documentTypes,
        ILogger<DocumentController> logger
        )
    {
        _converter = converter;
        _content = content;
        _documentTypes = documentTypes;
        _logger = logger;
    }

    /// <summary>
    /// Downloads the specified file.
    /// </summary>
    /// <param name="file">The path to the file.</param>
    [HttpGet("{*file}")]
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Summary(string file) =>
        await _content.SummaryAsync(file) switch
        {
            null => NotFound(),
            ContentReference blob => File(blob.Content, blob.ContentType, blob.FileName)
        };

    /// <summary>
    /// Upload file content
    /// </summary>
    /// <param name="content">upload file content</param>
    /// <param name="file"></param>
    /// <param name="sourceContentType">optionally overload the provided MIME Type</param>
    /// <returns></returns>
    [HttpPost("{*file}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Upload([FromForm] IFormFile content, string file, string? sourceContentType = null)
    {
        _logger.LogDebug("Start Upload");
        if (ModelState.IsValid)
        {
            _logger.LogDebug("Upload Ok");
            //  return Ok(await _uploader.UploadFileAsync(model));
        }

        _logger.LogDebug("Upload BadRequest");
        return BadRequest(ModelState);
    }

    /// <summary>
    /// Document Converter
    /// </summary>
    /// <param name="content">upload file content</param>
    /// <param name="targetContentType">define the target MIME type</param>
    /// <param name="sourceContentType">optionally overload the provided MIME Type</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Convert([FromForm] IFormFile content, string targetContentType, string? sourceContentType = null)
    {
        using var source = new MemoryStream();
        await content.CopyToAsync(source);
        source.Position = 0;

        var destination = new MemoryStream();
        await _converter.ConvertAsync(source, sourceContentType ?? content.ContentType, destination, targetContentType);
        destination.Position = 0;

        var type = _documentTypes.GetByContentType(targetContentType);

        var targetFile = type != null ? Path.ChangeExtension(content.FileName, type.FileExtensions.FirstOrDefault()) : null;

        return File(destination, targetContentType, fileDownloadName: targetFile);
    }
}
