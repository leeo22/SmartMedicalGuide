namespace SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results
{
    public class ChatParticipantResponse
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public bool IsTyping { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
    }
}
