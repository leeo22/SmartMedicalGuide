namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Results
{
    public class GetDoctorNameResponse
    {
        public int DoctorId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        //public User User { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public string LicenseNumber { get; set; }
        public decimal ConsultationPrice { get; set; }
        public string VerificationStatus { get; set; }
        public string AvailableTimes { get; set; }
    }
}
