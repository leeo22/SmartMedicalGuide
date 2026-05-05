using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void EditClinicCommandMapping()
        {
            CreateMap<EditClinicCommand, Clinic>()
                .ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.ClinicName))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ClinicImageUrl, opt => opt.MapFrom(src => src.ClinicImageUrl))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.OpeningTime, opt => opt.MapFrom(src => src.OpeningTime))
                .ForMember(dest => dest.ClosingTime, opt => opt.MapFrom(src => src.ClosingTime))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}