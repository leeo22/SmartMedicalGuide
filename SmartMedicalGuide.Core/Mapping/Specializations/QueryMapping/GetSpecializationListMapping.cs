using AutoMapper;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile : Profile
    {
        public void GetSpecializationListMapping()
        {
            CreateMap<Specialization, GetSpecializationListResponse>();
        }
    }
}
