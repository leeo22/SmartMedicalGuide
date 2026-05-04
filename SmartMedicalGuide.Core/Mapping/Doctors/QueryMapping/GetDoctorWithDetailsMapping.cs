using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetDoctorWithDetailsResponseMapping()
        {
            CreateMap<Doctor, GetDoctorWithDetailsResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.User != null ? src.User.PhoneNumber : null))
                .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.Specialization != null ? src.Specialization.Name : null))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Reviews != null && src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
                .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews != null ? src.Reviews.Count : 0))
                .ForMember(dest => dest.Clinics, opt => opt.MapFrom(src => src.Clinics))
                .ForMember(dest => dest.DoctorSchedules, opt => opt.MapFrom(src => src.DoctorSchedules))
                .ForMember(dest => dest.CapacitySettings, opt => opt.MapFrom(src => src.DoctorCapacitySettings))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));
        }
    }
}