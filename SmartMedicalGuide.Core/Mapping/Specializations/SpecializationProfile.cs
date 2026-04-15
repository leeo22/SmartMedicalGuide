using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            GetSpecializationByIDtMapping();
            GetSpecializationListMapping();
            EditSpecializationCommandMapping();
            AddSpecializationCommandMapping();
        }
    }
}
