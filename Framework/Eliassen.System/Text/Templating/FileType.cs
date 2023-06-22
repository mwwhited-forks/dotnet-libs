namespace Eliassen.System.Text.Templating
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
}