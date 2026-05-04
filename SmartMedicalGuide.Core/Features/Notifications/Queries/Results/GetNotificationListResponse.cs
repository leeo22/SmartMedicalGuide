namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Results
{
    public class GetNotificationListResponse
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string? NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImageUrl { get; set; }
        public string? ActionUrl { get; set; }
    }
}