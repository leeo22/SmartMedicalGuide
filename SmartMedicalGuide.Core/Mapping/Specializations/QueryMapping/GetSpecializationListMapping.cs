using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile
    {
        public void GetSpecializationListResponseMapping()
        {
            CreateMap<Specialization, GetSpecializationListResponse>();
        }
    }
}