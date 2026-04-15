using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Models
{
    public class EditSpecializationCommand : IRequest<Response<string>>
    {
        public int SpecializationId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
