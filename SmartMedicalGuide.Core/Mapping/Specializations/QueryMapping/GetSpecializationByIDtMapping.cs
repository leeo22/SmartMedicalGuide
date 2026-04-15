
using AutoMapper;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile : Profile
    {
        public void GetSpecializationByIDtMapping()
        {
            CreateMap<Specialization, GetSingleSpecializationResponse>();

        }
    }
}

