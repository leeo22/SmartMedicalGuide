using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void EditLabCommandMapping()
        {
            CreateMap<EditLabCommand, Lab>().ForMember(dest => dest.LabId, opt => opt
                                                  .MapFrom(src => src.LabId))
                                                  .ForMember(dest => dest.UserId, opt => opt
                                                  .MapFrom(src => src.UserId));

        }

    }
}
