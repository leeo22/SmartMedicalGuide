using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Specializations
{
    public partial class SpecializationProfile
    {
        public void GetSpecializationWithDetailsResponseMapping()
        {
            CreateMap<Specialization, GetSpecializationWithDetailsResponse>()
                .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors));

            CreateMap<Doctor, GetDoctorListResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null))
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Reviews != null && src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
                .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews != null ? src.Reviews.Count : 0));
        }
    }
}