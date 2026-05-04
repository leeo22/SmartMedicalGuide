namespace SmartMedicalGuide.Core.Features.Payments.Queries.Results
{
    public class GetPaymentListResponse
    {
        public int PaymentId { get; set; }
        public int? DoctorAppointmentId { get; set; }
        public int? LabAppointmentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? LabName { get; set; }
    }
}