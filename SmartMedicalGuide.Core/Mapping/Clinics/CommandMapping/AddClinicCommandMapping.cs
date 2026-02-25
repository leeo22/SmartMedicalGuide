using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void AddClinicCommandMapping()
        {
            CreateMap<AddClinicCommand, Clinic>()
                        .ForMember(dest => dest.UserId, opt => opt
                        .MapFrom(src => src.UserId));
        }
    }
}
