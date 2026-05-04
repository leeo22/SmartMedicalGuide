using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile
    {
        public void EditSpecializationCommandMapping()
        {
            CreateMap<EditSpecializationCommand, Specialization>()
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId));
        }
    }
}