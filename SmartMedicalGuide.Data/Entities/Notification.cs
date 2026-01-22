namespace SmartMedicalGuide.Data.Entities
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? PatientID { get; set; }
        public Patient Patient { get; set; }
    }

}
