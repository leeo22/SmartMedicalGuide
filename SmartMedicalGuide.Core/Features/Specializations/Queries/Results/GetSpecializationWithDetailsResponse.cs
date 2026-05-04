using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Results
{
    public class GetSpecializationWithDetailsResponse
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<GetDoctorListResponse>? Doctors { get; set; }
    }
}