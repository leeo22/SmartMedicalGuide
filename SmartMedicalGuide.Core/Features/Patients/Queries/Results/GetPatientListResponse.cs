namespace SmartMedicalGuide.Core.Features.Patients.Queries.Results
{
    public class GetPatientListResponse
    {
        public int PatientID { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}
