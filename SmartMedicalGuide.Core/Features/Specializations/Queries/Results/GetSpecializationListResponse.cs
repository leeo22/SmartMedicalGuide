namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Results
{
    public class GetSpecializationListResponse
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DoctorsCount { get; set; }
    }
}