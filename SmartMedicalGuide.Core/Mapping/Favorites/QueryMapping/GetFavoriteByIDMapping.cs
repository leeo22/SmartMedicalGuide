using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Favorites
{
    public partial class FavoriteProfile
    {
        public void GetFavoriteByIDMapping()
        {
            CreateMap<Favorite, GetSingleFavoriteResponse>();
            //.ForMember(dest => dest.FavoriteId, opt => opt.MapFrom(src => src.FavoriteId))
            //.ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
            //.ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : null))
            //.ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.Email : null))
            //.ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
            //.ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
            //.ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
            //.ForMember(dest => dest.DoctorSpecialization, opt => opt.MapFrom(src => src.Doctor != null ? src.Doctor.Specialization : null));
        }
    }
}