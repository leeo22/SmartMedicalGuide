namespace SmartMedicalGuide.Data.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<SymptomAnalysis> SymptomAnalyses { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }

}
