namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Results
{
    public class GetAttachmentListResponse
    {
        public int AttachmentId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}