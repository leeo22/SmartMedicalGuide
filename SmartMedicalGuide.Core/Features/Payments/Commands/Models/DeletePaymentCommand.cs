using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Models
{
    public class DeletePaymentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeletePaymentCommand(int id)
        {
            Id = id;

        }
    }
}
