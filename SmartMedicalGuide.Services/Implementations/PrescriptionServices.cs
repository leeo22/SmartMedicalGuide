using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class PrescriptionServices : IPrescriptionServices
    {
        #region Fields
        private readonly IPrescriptionRepository _prescriptionRepository;
        #endregion

        #region Constructors
        public PrescriptionServices(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(Prescription prescription)
        {
            await _prescriptionRepository.AddAsync(prescription);
            return "Success";
        }

        public async Task<string> DeleteAsync(Prescription prescription)
        {
            var trans = _prescriptionRepository.BeginTransaction();
            try
            {
                await _prescriptionRepository.DeleteAsync(prescription);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Prescription prescription)
        {
            await _prescriptionRepository.UpdateAsync(prescription);
            return "Success";
        }

        public async Task<List<Prescription>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _prescriptionRepository.GetTableAsTracking()
                .Where(x => x.DoctorAppointmentId == appointmentId)
                .ToListAsync();
        }

        public async Task<List<Prescription>> GetByDoctorIdAsync(int doctorId)
        {
            return await _prescriptionRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<Prescription> GetByIDAsync(int id)
        {
            var result = _prescriptionRepository.GetByIdAsync()
                                            .Where(x => x.PrescriptionId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Prescription>> GetByPatientIdAsync(int patientId)
        {
            return await _prescriptionRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<List<Prescription>> GetListAsync()
        {
            return await _prescriptionRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}