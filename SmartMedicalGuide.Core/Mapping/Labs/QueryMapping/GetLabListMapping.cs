using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void GetLabListResponseMapping()
        {
            CreateMap<Lab, GetLabListResponse>()
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.ServicesCount, opt => opt.MapFrom(src => src.LabServices != null ? src.LabServices.Count : 0));
        }
    }
}