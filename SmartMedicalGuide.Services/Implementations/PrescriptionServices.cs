using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
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

        #region Basic CRUD Handlers
        public async Task<List<Prescription>> GetListAsync()
        {
            try
            {
                return await _prescriptionRepository.GetAllPrescriptionsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescriptions list: {ex.Message}", ex);
            }
        }

        public async Task<Prescription?> GetByIDAsync(int id)
        {
            try
            {
                return await _prescriptionRepository.GetPrescriptionByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Prescription prescription)
        {
            try
            {
                prescription.IsDeleted = false;
                prescription.Status = "Active";
                prescription.CreatedAt = DateTime.UtcNow;

                await _prescriptionRepository.AddAsync(prescription);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add prescription: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Prescription prescription)
        {
            try
            {
                var existing = await _prescriptionRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.PrescriptionId == prescription.PrescriptionId && !x.IsDeleted);

                if (existing == null)
                    return "Prescription not found";

                existing.Description = prescription.Description ?? existing.Description;
                existing.Notes = prescription.Notes ?? existing.Notes;
                existing.FollowUpDate = prescription.FollowUpDate ?? existing.FollowUpDate;
                existing.Status = prescription.Status ?? existing.Status;

                await _prescriptionRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit prescription: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Prescription prescription)
        {
            try
            {
                prescription.IsDeleted = true;
                await _prescriptionRepository.UpdateAsync(prescription);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete prescription: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Prescription>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _prescriptionRepository.GetByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescriptions for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Prescription>> GetByDoctorIdAsync(int doctorId)
        {
            try
            {
                return await _prescriptionRepository.GetByDoctorIdAsync(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescriptions for doctor {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<Prescription?> GetByAppointmentIdAsync(int appointmentId)
        {
            try
            {
                return await _prescriptionRepository.GetByAppointmentIdAsync(appointmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription for appointment {appointmentId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Prescription>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _prescriptionRepository.GetByDateRangeAsync(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescriptions by date range: {ex.Message}", ex);
            }
        }

        public async Task<Prescription?> GetPrescriptionWithItemsAsync(int id)
        {
            try
            {
                return await _prescriptionRepository.GetPrescriptionWithItemsAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription with items for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<object> GetPrescriptionStatisticsAsync()
        {
            try
            {
                return await _prescriptionRepository.GetPrescriptionStatisticsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription statistics: {ex.Message}", ex);
            }
        }

        public async Task<string> UpdatePrescriptionStatusAsync(int prescriptionId, string status)
        {
            try
            {
                var prescription = await _prescriptionRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.PrescriptionId == prescriptionId && !x.IsDeleted);

                if (prescription == null)
                    return "Prescription not found";

                prescription.Status = status;
                await _prescriptionRepository.UpdateAsync(prescription);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to update prescription status: {ex.Message}";
            }
        }
        #endregion
    }
}