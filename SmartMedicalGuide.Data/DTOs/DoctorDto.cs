namespace SmartMedicalGuide.Data.DTOs
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public string ProfileImageUrl { get; set; }
        public decimal? ConsultationPrice { get; set; }
        public double AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public bool IsAvailableForBooking { get; set; }
    }
}
