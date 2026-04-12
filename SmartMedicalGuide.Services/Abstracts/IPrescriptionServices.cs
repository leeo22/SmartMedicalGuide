using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPrescriptionServices
    {
        public Task<List<Prescription>> GetPrescriptionListAsync();
        public Task<string> AddAsync(Prescription prescription);
        public Task<Prescription> GetPrescriptionByIDAsync(int id);
        public Task<string> EditAsync(Prescription prescription);
        public Task<string> DeleteAsync(Prescription prescription);
    }
}
