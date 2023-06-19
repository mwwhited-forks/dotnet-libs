using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eliassen.System.Templating
{
    /// <summary>
    /// Access template from file system
    /// </summary>
    public class FileTemplateSource : ITemplateSource
    {
        private readonly FileTemplatingSettings _settings;

        public FileTemplateSource(
            IOptions<FileTemplatingSettings> settings
            )
        {
            _settings = settings.Value;
        }

        private (string extension, string contentType)[] _fileTypes = new[]
        {
            (".md","text/markdown"),
            (".html","text/html"),
            (".txt","text/plain"),
            (".json","text/json"),
            (".yaml","text/yaml"),

            (".hbs","text/x-handlebars-template"),
            (".xslt",XsltTemplateProvider.ContentType),
        };

        private IEnumerable<(string fullFilePath, string extension, string contentType)> GetTemplates(string templateName)
        {
            var sandbox = string.IsNullOrWhiteSpace(_settings.SandboxPath) ? null : Path.GetFullPath(_settings.SandboxPath);
            var query =
                  from fileType in _fileTypes
                  let fileName = $"{templateName}{fileType.extension}"
                  let filePath = Path.Combine(_settings.TemplatePath, fileName)
                  let fullFilePath = Path.GetFullPath(filePath)
                  where sandbox == null || fullFilePath.StartsWith(sandbox)
                  select (fullFilePath, fileType.extension, fileType.contentType);
            return query;
        }

        private (string extension, string contentType) GetFileType(string file)
        {
            var extension = Path.GetExtension(file);
            var fileType = _fileTypes.FirstOrDefault(ft => ft.extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase));
            if (fileType == default)
                return ("", "application/octet-stream");
            return fileType;
        }

        private bool NestedType(string? extension) =>
            extension == ".hbs" ||
            extension == ".xslt"
            ;

        /// <inheritdoc />
        public IEnumerable<ITemplateContext> Get(string templateName)
        {
            var templates = GetTemplates(templateName);

            var query = from template in templates
                        let targetType = NestedType(template.extension)
                            ? GetFileType(Path.GetFileNameWithoutExtension(template.fullFilePath))
                            : (template.extension, template.contentType)
                        select new TemplateContext()
                        {
                            TemplateName = templateName,
                            TemplateContentType = template.contentType,
                            TemplateFileExtension = template.extension,
                            TemplateSource = this,

                            TemplateReference = template.fullFilePath,
                            OpenTemplate = () => File.Open(template.fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read),

                            TargetContentType = targetType.contentType,
                            TargetFileExtension = targetType.extension,
                        };

            return query;
        }
    }
}