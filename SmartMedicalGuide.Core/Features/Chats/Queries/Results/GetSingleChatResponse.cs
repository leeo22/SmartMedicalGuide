namespace SmartMedicalGuide.Core.Features.Chats.Queries.Results
{
    public class GetSingleChatResponse
    {
        public int ChatId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<MessageDto>? Messages { get; set; }
    }

    public class MessageDto
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public string? SenderName { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}