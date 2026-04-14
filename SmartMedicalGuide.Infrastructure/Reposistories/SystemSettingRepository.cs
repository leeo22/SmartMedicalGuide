using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class SystemSettingRepository(IDapperRepositoryAsync repositoryAsync) //: ISystemSettingRepository
    {

        //public async Task<List<SystemSetting>> GetAllAsync()
        //{
        //    var syst = await repositoryAsync.GetAllDataAsync<SystemSetting>("SELECT * FROM SystemSettings");
        //    return syst.ToList();
        //}

        //public async Task<SystemSetting> GetByIdAsync(int Id)
        //{
        //    var syst = await repositoryAsync.GetDataAsync<SystemSetting>("SELECT * FROM SystemSettings WHERE SettingId = @ID", new
        //    {
        //        ID = Id
        //    });
        //    return syst;
        //}
    }
}
