namespace SmartMedicalGuide.Core.Features.Chats.Queries.Results
{
    public class GetChatListResponse
    {
        public int ChatId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MessagesCount { get; set; }
    }
}