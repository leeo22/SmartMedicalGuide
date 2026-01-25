namespace SmartMedicalGuide.Data.Entities
{
    public class VerificationRequest
    {
        public int RequestId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string DocumentType { get; set; }
        public string DocumentImagePath { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
