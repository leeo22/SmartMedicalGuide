using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Results
{
    public class GetSingleDoctorResponse
    {
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string DoctorName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int? SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public string? Bio { get; set; }
        public string? LicenseNumber { get; set; }
        public decimal? ConsultationPrice { get; set; }
        public string? AvailableTimes { get; set; }
        public string VerificationStatus { get; set; }
        public bool IsAvailableForBooking { get; set; }
        public int? YearsOfExperience { get; set; }
        public string? Gender { get; set; }
        public string? ProfileImageUrl { get; set; }
        public double AverageRating { get; set; }
        public int ReviewsCount { get; set; }
        public ICollection<Clinic>? Clinics { get; set; }
        public ICollection<DoctorSchedule>? DoctorSchedules { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}