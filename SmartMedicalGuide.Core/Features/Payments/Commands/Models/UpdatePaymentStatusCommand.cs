using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Models
{
    public class UpdatePaymentStatusCommand : IRequest<Response<string>>
    {
        public int PaymentId { get; set; }
        public string Status { get; set; }
    }
}