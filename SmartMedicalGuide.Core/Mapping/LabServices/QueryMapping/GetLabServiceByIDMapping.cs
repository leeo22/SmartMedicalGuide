using SmartMedicalGuide.Core.Features.LabsServices.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabServices
{
    public partial class LabServiceProfile
    {
        public void GetLabServiceByIDMapping()
        {
            CreateMap<LabService, GetSingleLabServiceResponse>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.ServiceId))
                .ForMember(dest => dest.LabId, opt => opt.MapFrom(src => src.LabId))
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.CenterName : null))
                .ForMember(dest => dest.LabCenterName, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.CenterName : null))
                .ForMember(dest => dest.LabPhoneNumber, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.PhoneNumber : null))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}