using Nucleus.Core.Busines.Attributes;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private IUserSession _userSession { get; set; }
        private IDocumentManager _documentManager { get; set; }

        public DocumentsController(IUserSession userSession, IDocumentManager documentManager)
        {
            _userSession = userSession;
            _documentManager = documentManager;
        }

        [HttpGet("{**id}")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 604800)]
        public async Task<IActionResult> GetDocument(string id)
        {
            BlobDto? blob = await _documentManager.DownloadDocument(id);
            if (blob == null)
                return BadRequest();
            return File(blob.Content, blob.ContentType, blob.Name);
        }

        [Authorize]
        [HttpPost("Save")]
        [ApplicationRight(Rights.Vlog.Manager, Rights.Blog.Manager, Rights.Project.Manager)]
        public async Task<IActionResult> SaveDocument([FromForm] DocumentModel document)
        {
            IFormFile? file = null;
            if (this.Request.HasFormContentType && this.Request.Form.Files.Count > 0)
                file = this.Request.Form.Files[0];

            if (file == null)
                return BadRequest();

            document.DocumentName = file.FileName;
            document.DocumentType = file.ContentType;
            document.DocumentSize = file.Length;

            return new JsonResult(await _documentManager.SaveDocument(document, file.OpenReadStream()));
        }

        [Authorize]
        [HttpPost("Delete")]
        [ApplicationRight(Rights.Vlog.Manager, Rights.Blog.Manager, Rights.Project.Manager)]
        public async Task<IActionResult> DeleteDocument(DocumentModel document)
        {
            return new JsonResult(await _documentManager.RemoveDocument(document));
        }
    }
}
