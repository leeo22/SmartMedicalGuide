using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorSchedules
{
    public partial class DoctorScheduleProfile
    {
        public void GetDoctorScheduleListResponseMapping()
        {
            CreateMap<DoctorSchedule, GetDoctorScheduleListResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null));
        }
    }
}