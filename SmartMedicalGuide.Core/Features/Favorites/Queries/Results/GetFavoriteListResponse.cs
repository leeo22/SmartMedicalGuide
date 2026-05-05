namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Results
{
    public class GetFavoriteListResponse
    {
        public int FavoriteId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialization { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}