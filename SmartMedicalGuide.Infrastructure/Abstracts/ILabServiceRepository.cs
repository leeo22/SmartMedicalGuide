using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ILabServiceRepository : IGenericRepositoryAsync<LabService>
    {
        public Task<List<LabService>> GetLabServicesListAsync();
    }
}
