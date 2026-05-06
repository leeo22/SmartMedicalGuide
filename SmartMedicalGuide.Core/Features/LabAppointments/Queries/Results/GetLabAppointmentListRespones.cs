namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results
{
    public class GetLabAppointmentListResponse
    {
        public int LabAppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int LabId { get; set; }
        public string LabName { get; set; }
        public string? TestType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }
        public string? BookingSource { get; set; }
    }
}