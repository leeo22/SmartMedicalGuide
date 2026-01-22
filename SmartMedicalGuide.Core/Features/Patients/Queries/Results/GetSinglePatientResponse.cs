namespace SmartMedicalGuide.Core.Features.Patients.Queries.Results
{
    public class GetSinglePatientResponse
    {
        public int PatientID { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
