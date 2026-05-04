namespace SmartMedicalGuide.Core.Features.Patients.Queries.Results
{
    public class GetPatientListResponse
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}