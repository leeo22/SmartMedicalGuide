using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Results
{
    public class GetSingleDoctorCapacitySettingResponse
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public WorkDays WorkDays { get; set; }
        public BookingType BookingType { get; set; }
        public ShiftType ShiftType { get; set; }
        public int DailyCapacity { get; set; }
        public int MaxLimit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}