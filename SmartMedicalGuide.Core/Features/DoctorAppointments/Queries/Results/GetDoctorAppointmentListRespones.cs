namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results
{
    public class GetDoctorAppointmentListResponse
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? AppointmentType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? BookingSource { get; set; }
    }
}