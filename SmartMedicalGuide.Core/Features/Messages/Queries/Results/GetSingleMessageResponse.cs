namespace SmartMedicalGuide.Core.Features.Messages.Queries.Results
{
    public class GetSingleMessageResponse
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}