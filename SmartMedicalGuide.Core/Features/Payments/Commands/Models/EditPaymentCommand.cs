using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Models
{
    public class EditPaymentCommand : IRequest<Response<string>>
    {
        public int PaymentId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? WalletType { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverNumber { get; set; }
        public string? TransferImagePath { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Notes { get; set; }
    }
}