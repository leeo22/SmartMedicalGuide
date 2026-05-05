using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteClinicCommand(int id) => Id = id;
    }
}