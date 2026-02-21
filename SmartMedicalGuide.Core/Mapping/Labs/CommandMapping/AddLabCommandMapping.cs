using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void AddLabCommandMapping()
        {
            CreateMap<AddLabCommand, Lab>()
                        .ForMember(dest => dest.UserId, opt => opt
                        .MapFrom(src => src.UserId));
        }

    }
}

