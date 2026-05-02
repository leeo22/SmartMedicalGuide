namespace SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results
{
    public class UserChatResponse
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public bool IsGroup { get; set; }
        public bool IsActive { get; set; }
        public string? LastMessage { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public int UnreadCount { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
