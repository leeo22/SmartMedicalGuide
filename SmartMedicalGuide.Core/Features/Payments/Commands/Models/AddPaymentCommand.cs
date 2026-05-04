using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Models
{
    public class AddPaymentCommand : IRequest<Response<string>>
    {
        public int? DoctorAppointmentId { get; set; }
        public int? LabAppointmentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? WalletType { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverNumber { get; set; }
        public string? TransferImagePath { get; set; }
        public decimal Amount { get; set; }
        public decimal PlatformFee { get; set; }
        public decimal DoctorShare { get; set; }
        public string? Notes { get; set; }
    }
}