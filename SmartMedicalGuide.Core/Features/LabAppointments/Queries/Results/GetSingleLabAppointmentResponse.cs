using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results
{
    public class GetSingleLabAppointmentResponse
    {
        public int LabAppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public int LabId { get; set; }
        public string LabName { get; set; }
        public string LabEmail { get; set; }
        public string LabPhone { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? TestType { get; set; }
        public string Status { get; set; }
        public decimal? Price { get; set; }
        public string? BookingSource { get; set; }
        public string? Notes { get; set; }
        public string? CancellationReason { get; set; }
        public Payment? Payment { get; set; }
    }
}