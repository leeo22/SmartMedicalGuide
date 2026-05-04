using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorSchedules
{
    public partial class DoctorScheduleProfile
    {
        public void GetSingleDoctorScheduleResponseMapping()
        {
            CreateMap<DoctorSchedule, GetSingleDoctorScheduleResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
                .ForMember(dest => dest.DoctorPhone, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.PhoneNumber : null))
                .ForMember(dest => dest.UpcomingAppointments, opt => opt.Ignore());
        }
    }
}