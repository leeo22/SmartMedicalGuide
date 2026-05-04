namespace SmartMedicalGuide.Core.Features.Payments.Queries.Results
{
    public class GetSinglePaymentResponse
    {
        public int PaymentId { get; set; }
        public int? DoctorAppointmentId { get; set; }
        public int? LabAppointmentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? WalletType { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverNumber { get; set; }
        public string? TransferImagePath { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionId { get; set; }
        public string? Notes { get; set; }
        public decimal PlatformFee { get; set; }
        public decimal DoctorShare { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public string? LabName { get; set; }
    }
}