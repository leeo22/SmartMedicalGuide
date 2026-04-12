using SmartMedicalGuide.Core.Features.SystemSettings.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.SystemSettings
{
    public partial class SystemSettingProfile
    {
        public void AddSystemSettingCommandMapping()
        {
            CreateMap<AddSystemSettingCommand, SystemSetting>();
        }
    }
}
