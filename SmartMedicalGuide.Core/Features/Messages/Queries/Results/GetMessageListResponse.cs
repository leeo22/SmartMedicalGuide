namespace SmartMedicalGuide.Core.Features.Messages.Queries.Results
{
    public class GetMessageListResponse
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string? SenderName { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // ✅ الحقول الجديدة
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public int? ReplyToMessageId { get; set; }
        public string? AttachmentUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}