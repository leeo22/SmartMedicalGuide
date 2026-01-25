namespace SmartMedicalGuide.Data.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public string LicenseNumber { get; set; }

        public decimal ConsultationPrice { get; set; }
        public string VerificationStatus { get; set; }
        public string AvailableTimes { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }

}
