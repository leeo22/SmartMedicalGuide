using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class SystemSettingServices(IDapperRepositoryAsync dra) : ISystemSettingServices
    {
        public async Task<SystemSetting> AddAsync(SystemSetting systemSetting)
        {
            return await dra.GetDataAsync<SystemSetting>("" +
                "insert into SystemSettings(KeyName,Value)" +
                "Values(@KeyName,@Value)" +
                "SET @SettingId = SCOPE_IDENTITY(); " +
                "SELECT * FROM SystemSettings WHERE SettingId = @SettingId", systemSetting);
        }

        public async Task<List<SystemSetting>> GetAllSystemAsync()
        {
            var syst = await dra.GetAllDataAsync<SystemSetting>("SELECT * FROM SystemSettings");
            return syst.ToList();
        }

        public async Task<SystemSetting> GetByIdAsync(int Id)
        {
            var syst = await dra.GetDataAsync<SystemSetting>("SELECT * FROM SystemSettings WHERE SettingId = @ID", new
            {
                ID = Id
            });
            return syst;
        }
    }
}
