namespace Eliassen.System.Text.Templating
{
    /// <inheritdoc />
    public record FileType : IFileType
    {
        /// <inheritdoc />
        public string Extension { get; set; } = null!;
        /// <inheritdoc />
        public string ContentType { get; set; } = null!;
        /// <inheritdoc />
        public bool IsTemplateType { get; set; }
    }
}