namespace Eliassen.Azure.StorageAccount
{
    public record DocumentModel
    {
        public string? DocumentId { get; set; }

        public string? DocumentKey { get; set; }

        public string? DocumentName { get; set; }

        public string? DocumentType { get; set; }

        public long? DocumentSize { get; set; }

        public string? DocumentRepository { get; set; }

        public string? DocumentCategory { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }
    }
}
