namespace SmartMedicalGuide.Data.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Content { get; set; }
        public bool IsFromDoctor { get; set; }
        public DateTime SentAt { get; set; }

        public int ChatID { get; set; }
        public Chat Chat { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }


}
