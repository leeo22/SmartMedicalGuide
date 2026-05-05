namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Results
{
    public class GetSingleClinicResponse
    {
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public string? ClinicName { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? ClinicImageUrl { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
    }
}