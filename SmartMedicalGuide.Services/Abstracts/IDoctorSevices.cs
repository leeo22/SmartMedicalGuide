using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorServices
    {
        // Basic CRUD - 5 Functions
        Task<List<Doctor>> GetListAsync();
        Task<Doctor?> GetByIDAsync(int id);
        Task<string> AddAsync(Doctor doctor);
        Task<string> EditAsync(Doctor doctor);
        Task<string> DeleteAsync(Doctor doctor);

        // Additional Functions - 11 Functions
        Task<Doctor?> GetByUserIdAsync(int userId);
        Task<List<Doctor>> GetBySpecializationIdAsync(int specializationId);
        Task<List<Doctor>> GetVerifiedDoctorsAsync();
        Task<List<Doctor>> SearchDoctorsAsync(string keyword);
        Task<List<Doctor>> GetTopRatedDoctorsAsync(int limit);
        Task<List<Doctor>> GetDoctorsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<Doctor>> GetAvailableForBookingDoctorsAsync();
        Task<string> UpdateVerificationStatusAsync(int doctorId, string status);
        Task<string> ToggleAvailableForBookingAsync(int doctorId, bool isAvailable);
        Task<Doctor?> GetDoctorWithDetailsAsync(int id);
        Task<DoctorStatisticsDto> GetDoctorStatisticsAsync(int doctorId);
    }

    public class DoctorStatisticsDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string? Gender { get; set; }
        public int? YearsOfExperience { get; set; }
        public int TotalAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public decimal TotalRevenue { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public int TotalPrescriptions { get; set; }
    }
}