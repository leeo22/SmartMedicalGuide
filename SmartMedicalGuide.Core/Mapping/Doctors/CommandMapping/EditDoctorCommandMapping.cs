using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void EditDoctorCommandMapping()
        {
            CreateMap<EditDoctorCommand, Doctor>()
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
                .ForMember(dest => dest.ConsultationPrice, opt => opt.MapFrom(src => src.ConsultationPrice))
                .ForMember(dest => dest.AvailableTimes, opt => opt.MapFrom(src => src.AvailableTimes))
                .ForMember(dest => dest.YearsOfExperience, opt => opt.MapFrom(src => src.YearsOfExperience))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => src.ProfileImageUrl))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.VerificationStatus, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.IsAvailableForBooking, opt => opt.Ignore());
        }
    }
}