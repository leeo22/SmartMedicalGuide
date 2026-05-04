using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.DoctorSchedules
{
    public partial class DoctorScheduleProfile : Profile
    {
        public DoctorScheduleProfile()
        {
            AddDoctorScheduleCommandMapping();
            EditDoctorScheduleCommandMapping();
            GetDoctorScheduleListResponseMapping();
            GetSingleDoctorScheduleResponseMapping();
        }
    }
}