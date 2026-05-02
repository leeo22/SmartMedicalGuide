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

        // ✅ الحقول الجديدة
        public string ChatName { get; set; }
        public bool IsGroup { get; set; }
        public bool IsActive { get; set; }
        public string? LastMessage { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public List<ChatParticipantsDto>? Participants { get; set; }  // المشاركون في المحادثة
    }

    public class MessageDto
    {
        public int MessageId { get; set; }
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

    // ✅ DTO جديد للمشاركين
    public class ChatParticipantsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public bool IsTyping { get; set; }
        public bool IsAdmin { get; set; }
    }
}