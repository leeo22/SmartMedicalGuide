using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Models
{
    public class AddSpecializationCommand : IRequest<Response<string>>
    {

        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
