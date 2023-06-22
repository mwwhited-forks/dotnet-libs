using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eliassen.System.Templating
{
    /// <inheritdoc />
    public record FileType : IFileType
    {
        /// <inheritdoc />
        public string Extension { get; set; }
        /// <inheritdoc />
        public string ContentType { get; set; }
        /// <inheritdoc />
        public bool IsTemplateType { get; set; }
    }

    /// <summary>
    /// Access template from file system
    /// </summary>
    public class FileTemplateSource : ITemplateSource
    {
        private readonly FileTemplatingSettings _settings;
        private readonly IEnumerable<IFileType> _fileTypes;
        private readonly ILogger _logger;

        public FileTemplateSource(
            IOptions<FileTemplatingSettings> settings,
            IEnumerable<IFileType> fileTypes,
            ILogger<FileTemplateSource> logger
            )
        {
            _settings = settings.Value;
            _fileTypes = fileTypes;
            _logger = logger;
        }

        /// <inheritdoc />
        public IEnumerable<ITemplateContext> Get(string templateName)
        {
            var sandbox = string.IsNullOrWhiteSpace(_settings.SandboxPath) ? null : Path.GetFullPath(_settings.SandboxPath + "/");

            _logger.LogInformation(
                $"Search for {{{nameof(templateName)}}} in \"{{{nameof(templateName)}}}\"", 
                templateName, 
                _settings.TemplatePath
                );

            var templateTypes =
                from template in _fileTypes
                where template.IsTemplateType
                select template;

            var fileTypes =
                from template in _fileTypes.Concat(new[] { new FileType {
                    Extension = "",
                    ContentType= "application/octet-stream",
                    IsTemplateType = false
                } })
                where !template.IsTemplateType
                select template;

            var possibleFiles =
                from template in templateTypes
                from target in fileTypes
                let fileName = string.Join("", templateName, target.Extension, template.Extension)
                let filePath = Path.Combine(_settings.TemplatePath, fileName)
                let fullPath = Path.GetFullPath(filePath)
                where sandbox == null || fullPath.StartsWith(sandbox)
                where File.Exists(fullPath)
                select new TemplateContext()
                {
                    TemplateName = templateName,
                    TemplateContentType = template.ContentType,
                    TemplateFileExtension = template.Extension,
                    TemplateSource = this,

                    TemplateReference = fullPath,
                    OpenTemplate = ctx => File.Open(ctx.TemplateReference, FileMode.Open, FileAccess.Read, FileShare.Read),

                    TargetContentType = target.ContentType,
                    TargetFileExtension = target.Extension,

                    Priority = _settings.Priority,
                };

            return possibleFiles;
        }
    }
}