using AutoMapper;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile : Profile
    {

        public void EditSpecializationCommandMapping()
        {
            CreateMap<EditSpecializationCommand, Specialization>();
        }
    }
}
