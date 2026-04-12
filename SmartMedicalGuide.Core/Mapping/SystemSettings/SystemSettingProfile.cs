using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.SystemSettings
{
    public partial class SystemSettingProfile : Profile
    {
        public SystemSettingProfile()
        {
            GetSystemSettingListMapping();
            GetSystemSettingByIDMapping();
            AddSystemSettingCommandMapping();
        }
    }
}
