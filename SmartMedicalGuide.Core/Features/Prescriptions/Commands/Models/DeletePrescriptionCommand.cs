using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class DeletePrescriptionCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeletePrescriptionCommand(int id) => Id = id;
    }
}