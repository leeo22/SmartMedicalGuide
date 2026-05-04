using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            AddSpecializationCommandMapping();
            EditSpecializationCommandMapping();
            GetSpecializationListResponseMapping();
            GetSingleSpecializationResponseMapping();
            GetSpecializationWithDetailsResponseMapping();
        }
    }
}