using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.SystemSettings
{
    public partial class SystemSettingProfile
    {
        public void GetSystemSettingByIDMapping()
        {
            CreateMap<SystemSetting, GetSingleSystemSettingResponse>();
        }
    }
}
