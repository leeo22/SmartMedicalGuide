using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class MedicalReportServices : IMedicalReportServices
    {
        #region Fields
        private readonly IMedicalReportRepository _medicalReportRepository;
        #endregion

        #region Constructors
        public MedicalReportServices(IMedicalReportRepository medicalReportRepository)
        {
            _medicalReportRepository = medicalReportRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(MedicalReport medicalReport)
        {
            await _medicalReportRepository.AddAsync(medicalReport);
            return "Success";
        }

        public async Task<string> DeleteAsync(MedicalReport medicalReport)
        {
            var trans = _medicalReportRepository.BeginTransaction();
            try
            {
                await _medicalReportRepository.DeleteAsync(medicalReport);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(MedicalReport medicalReport)
        {
            await _medicalReportRepository.UpdateAsync(medicalReport);
            return "Success";
        }

        public async Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId)
        {
            return await _medicalReportRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<MedicalReport> GetByIDAsync(int id)
        {
            var result = _medicalReportRepository.GetByIdAsync()
                                            .Where(x => x.ReportId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<MedicalReport>> GetByLabIdAsync(int labId)
        {
            return await _medicalReportRepository.GetTableAsTracking()
                .Where(x => x.LabId == labId)
                .ToListAsync();
        }

        public async Task<List<MedicalReport>> GetByPatientIdAsync(int patientId)
        {
            return await _medicalReportRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<List<MedicalReport>> GetListAsync()
        {
            return await _medicalReportRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}