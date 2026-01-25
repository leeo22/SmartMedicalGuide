namespace SmartMedicalGuide.Data.Entities
{
    public class AuditLog
    {
        public int LogId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Action { get; set; }
        public string TableName { get; set; }
        public int RecordId { get; set; }

        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public DateTime ActionDate { get; set; }
    }

}
