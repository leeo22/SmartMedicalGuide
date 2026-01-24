using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Models
{
    public class DeletePatientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeletePatientCommand(int id)
        {
            Id = id;

        }
    }
}
