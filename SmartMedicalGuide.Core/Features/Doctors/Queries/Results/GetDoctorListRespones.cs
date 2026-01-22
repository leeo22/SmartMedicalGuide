namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Results
{
    public class GetDoctorListRespones
    {
        public int DoctorID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public string ClinicName { get; set; }
        public string ClinicLocation { get; set; }
        public string LicenseNumber { get; set; }
        public string IDImage { get; set; }
        public string PracticeCertificateImage { get; set; }
        public string CV { get; set; }
        public string AvailableTimes { get; set; }
        public decimal Price { get; set; }
        public string VerificationStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
