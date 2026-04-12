<<<<<<< HEAD
﻿using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ISystemSettingRepository : IGenericRepositoryAsync<SystemSetting>
    {
        public Task<List<SystemSetting>> GetSystemSettingsListAsync();
=======
﻿namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ISystemSettingRepository
    {
        //public Task<List<SystemSetting>> GetAllAsync();
        //public Task<SystemSetting> GetByIdAsync(int Id);
>>>>>>> 5544136e3ebc971ee1f59abf8801ca62912e2f8d
    }
}
