using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results
{
    public class GetSingleDoctorAppointmentResponse
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public string? DoctorPhone { get; set; }
        public string? AppointmentType { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? BookingSource { get; set; }
        public bool IsPostponed { get; set; }
        public DateTime? NewAppointmentDate { get; set; }
        public DateTime? OriginalAppointmentDate { get; set; }
        public string? PostponeReason { get; set; }
        public string? CancellationReason { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
        public Payment? Payment { get; set; }
    }
}