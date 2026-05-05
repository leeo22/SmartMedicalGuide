namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Results
{
    public class FavoriteDoctorDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string SpecializationName { get; set; }
        public decimal? ConsultationPrice { get; set; }
        public double AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public DateTime AddedAt { get; set; }
    }
}