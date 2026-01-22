namespace SmartMedicalGuide.Data.Entities
{
    public class Chat
    {
        public int ChatID { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<Message> Messages { get; set; }
    }


}
