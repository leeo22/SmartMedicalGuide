using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabServiceServices
    {
        public Task<List<LabService>> GetLabServicesListAsync();
        public Task<string> AddAsync(LabService labService);
        public Task<LabService> GetLabByIDAsync(int id);
        public Task<string> EditAsync(LabService labService);
        public Task<string> DeleteAsync(LabService labService);

    }
}
