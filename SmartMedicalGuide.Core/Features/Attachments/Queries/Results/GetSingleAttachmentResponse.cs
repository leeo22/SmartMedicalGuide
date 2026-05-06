namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Results
{
    public class GetSingleAttachmentResponse
    {
        public int AttachmentId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long? FileSize { get; set; }
        public string? ContentType { get; set; }
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}