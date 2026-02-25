using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IClinicServices
    {
        public Task<List<Clinic>> GetClinicsListAsync();
        public Task<string> AddAsync(Clinic clinic);
        public Task<Clinic> GetClinicByIDAsync(int id);
        public Task<string> EditAsync(Clinic clinic);
        public Task<string> DeleteAsync(Clinic clinic);
    }
}
