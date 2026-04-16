using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models
{
    public class DeletePrescriptionItemCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeletePrescriptionItemCommand(int id) => Id = id;
    }
}