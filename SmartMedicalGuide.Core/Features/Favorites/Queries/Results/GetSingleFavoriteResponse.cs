namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Results
{
    public class GetSingleFavoriteResponse
    {
        public int FavoriteId { get; set; }
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

    }
}