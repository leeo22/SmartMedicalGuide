namespace SmartMedicalGuide.Core.Features.Labs.Queries.Results
{
    public class GetSingleLabResponse
    {
        public int LabId { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }

        public string CenterName { get; set; }
        public string CenterType { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string LicenseNumber { get; set; }
        public string VerificationStatus { get; set; }
    }
}
