using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.DoctorCapacitySettings
{
    public partial class DoctorCapacitySettingProfile : Profile
    {
        public DoctorCapacitySettingProfile()
        {
            AddDoctorCapacitySettingCommandMapping();
            EditDoctorCapacitySettingCommandMapping();
            GetDoctorCapacitySettingByIDMapping();
            GetDoctorCapacitySettingListMapping();
        }
    }
}