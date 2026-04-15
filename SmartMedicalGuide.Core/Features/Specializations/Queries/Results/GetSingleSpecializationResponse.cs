namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Results
{
    public class GetSingleSpecializationResponse
    {
        public int SpecializationId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
