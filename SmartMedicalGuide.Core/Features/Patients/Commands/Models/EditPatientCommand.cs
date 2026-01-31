using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Models
{
    public class EditPatientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
