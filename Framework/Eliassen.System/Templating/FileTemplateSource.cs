using Microsoft.Extensions.Options;
using System;
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
        private (string extension, string type)[] _fileTypes = new[]
        {
            (".md","text/markdown"),
            (".html","text/html"),
            (".txt","text/plain"),
        };

        /// <inheritdoc/>
        public FileTemplateSource(
            IOptions<FileTemplatingSettings>? settings)
        {
            _settings = settings?.Value ?? new();
        }

        /// <inheritdoc/>
        public bool CanGet(string templateName, string targetName) =>
            GetFullPath(templateName, targetName) != null;

        /// <inheritdoc/>
        public string? Get(string templateName, string targetName) =>
             CanGet(templateName, targetName) ? File.ReadAllText(GetFullPath(templateName, targetName)) : null;

        /// <inheritdoc/>
        public string? SuggestedContentType(string templateName, string targetName) =>
            CanGet(templateName, targetName) ?
            _fileTypes.First(ft => ft.extension.Equals(Path.GetExtension(GetFullPath(templateName, targetName)), StringComparison.CurrentCultureIgnoreCase))
                      .type :
            null;

        /// <inheritdoc/>
        public string? SuggestedFileName(string templateName, string targetName) =>
            CanGet(templateName, targetName) ? Path.GetFileName(GetFullPath(templateName, targetName)) : null;

        private string? GetFullPath(string templateName, string targetName) =>
            _fileTypes.Select(ft => Path.GetFullPath(Path.Combine(_settings.TemplatePath, $"{templateName}-{targetName}{ft.extension}")))
                      .FirstOrDefault(File.Exists);
    }
}