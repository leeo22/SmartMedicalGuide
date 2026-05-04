using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Results
{
    public class GetDoctorWithDetailsResponse
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
        public List<ClinicDto> Clinics { get; set; }
        public List<DoctorScheduleDto> DoctorSchedules { get; set; }
        public List<CapacitySettingDto> CapacitySettings { get; set; }
        public List<ReviewDto> Reviews { get; set; }
    }

    public class ClinicDto
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class DoctorScheduleDto
    {
        public int ScheduleId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class CapacitySettingDto
    {
        public int Id { get; set; }
        public WorkDays WorkDays { get; set; }
        public BookingType BookingType { get; set; }
        public ShiftType ShiftType { get; set; }
        public int DailyCapacity { get; set; }
        public int MaxLimit { get; set; }
        public bool IsActive { get; set; }
    }

    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}