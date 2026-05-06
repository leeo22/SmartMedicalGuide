using SmartMedicalGuide.Core.Features.LabServices.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabServices
{
    public partial class LabServiceProfile
    {
        public void GetSingleLabServiceResponseMapping()
        {
            CreateMap<LabService, GetSingleLabServiceResponse>()
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.FullName : null))
                .ForMember(dest => dest.LabEmail, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.Email : null))
                .ForMember(dest => dest.LabPhone, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.PhoneNumber : null))
                .ForMember(dest => dest.FinalPrice, opt => opt.Ignore()); // يتم حسابه في الـ Handler
        }
    }
}