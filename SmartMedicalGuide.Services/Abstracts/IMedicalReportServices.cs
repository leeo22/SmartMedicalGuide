using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IMedicalReportServices
    {
        public Task<List<MedicalReport>> GetMedicalReportsListAsync();
        public Task<string> AddAsync(MedicalReport medicalReport);
        public Task<MedicalReport> GetMedicalReportByIDAsync(int id);
        public Task<string> EditAsync(MedicalReport medicalReport);
        public Task<string> DeleteAsync(MedicalReport medicalReport);
    }
}
