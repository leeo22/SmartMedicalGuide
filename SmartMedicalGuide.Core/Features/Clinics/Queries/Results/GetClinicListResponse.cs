

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Results
{
    public class GetClinicListResponse
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }

        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
