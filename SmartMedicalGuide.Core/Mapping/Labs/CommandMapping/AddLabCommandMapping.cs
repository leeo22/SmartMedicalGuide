using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void AddLabCommandMapping()
        {
            CreateMap<AddLabCommand, Lab>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CenterName, opt => opt.MapFrom(src => src.CenterName))
                .ForMember(dest => dest.CenterType, opt => opt.MapFrom(src => src.CenterType))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.LabImageUrl, opt => opt.MapFrom(src => src.LabImageUrl))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.WorkingHours, opt => opt.MapFrom(src => src.WorkingHours));
        }
    }
}