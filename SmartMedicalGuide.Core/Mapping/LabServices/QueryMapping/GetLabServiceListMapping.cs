using SmartMedicalGuide.Core.Features.LabServices.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabServices
{
    public partial class LabServiceProfile
    {
        public void GetLabServiceListResponseMapping()
        {
            CreateMap<LabService, GetLabServiceListResponse>()
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.FullName : null))
                .ForMember(dest => dest.FinalPrice, opt => opt.Ignore()); // يتم حسابه في الـ Handler
        }
    }
}