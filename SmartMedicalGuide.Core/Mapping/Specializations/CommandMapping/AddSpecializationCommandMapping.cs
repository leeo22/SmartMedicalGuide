using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile
    {
        public void AddSpecializationCommandMapping()
        {
            CreateMap<AddSpecializationCommand, Specialization>();
        }
    }
}