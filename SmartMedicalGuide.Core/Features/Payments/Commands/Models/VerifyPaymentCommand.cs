using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Models
{
    public class VerifyPaymentCommand : IRequest<Response<string>>
    {
        public int PaymentId { get; set; }
    }
}