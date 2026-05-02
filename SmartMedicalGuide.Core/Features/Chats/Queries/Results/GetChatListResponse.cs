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

        // ✅ الحقول الجديدة
        public string ChatName { get; set; }
        public bool IsGroup { get; set; }
        public bool IsActive { get; set; }
        public string? LastMessage { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public int UnreadCount { get; set; }  // عدد الرسائل غير المقروءة للمستخدم الحالي
    }
}