namespace SmartMedicalGuide.Data.Entities
{
    public class Center
    {
        public int CenterID { get; set; }
        public string CenterName { get; set; }
        public string CenterType { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string LicenseNumber { get; set; }
        public string VerificationStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }

}
