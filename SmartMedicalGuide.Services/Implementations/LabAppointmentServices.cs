using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class LabAppointmentServices : ILabAppointmentServices
    {
        #region Fields
        private readonly ILabAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public LabAppointmentServices(ILabAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<LabAppointment>> GetListAsync()
        {
            try
            {
                return await _appointmentRepository.GetAllAppointmentsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab appointments list: {ex.Message}", ex);
            }
        }

        public async Task<LabAppointment?> GetByIDAsync(int id)
        {
            try
            {
                return await _appointmentRepository.GetAppointmentByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab appointment by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(LabAppointment appointment)
        {
            try
            {
                appointment.Status = appointment.Status ?? "Pending";
                appointment.IsDeleted = false;

                await _appointmentRepository.AddAsync(appointment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add lab appointment: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(LabAppointment appointment)
        {
            try
            {
                var existing = await _appointmentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.LabAppointmentId == appointment.LabAppointmentId && !x.IsDeleted);

                if (existing == null)
                    return "Appointment not found";

                existing.AppointmentDate = appointment.AppointmentDate;
                existing.TestType = appointment.TestType ?? existing.TestType;
                existing.Price = appointment.Price ?? existing.Price;
                existing.Status = appointment.Status ?? existing.Status;
                existing.Notes = appointment.Notes ?? existing.Notes;
                existing.BookingSource = appointment.BookingSource ?? existing.BookingSource;

                await _appointmentRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit lab appointment: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(LabAppointment appointment)
        {
            try
            {
                appointment.IsDeleted = true;
                await _appointmentRepository.UpdateAsync(appointment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete lab appointment: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<LabAppointment>> GetByLabIdAsync(int labId)
        {
            try
            {
                return await _appointmentRepository.GetByLabIdAsync(labId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting appointments for lab {labId}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabAppointment>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _appointmentRepository.GetByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting appointments for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabAppointment>> GetByStatusAsync(string status)
        {
            try
            {
                return await _appointmentRepository.GetByStatusAsync(status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting appointments by status {status}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabAppointment>> GetLabUpcomingAppointmentsAsync(int labId)
        {
            try
            {
                return await _appointmentRepository.GetLabUpcomingAppointmentsAsync(labId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting upcoming appointments for lab {labId}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId)
        {
            try
            {
                return await _appointmentRepository.GetPatientUpcomingAppointmentsAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting upcoming appointments for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> CheckLabAvailabilityAsync(int labId, DateTime appointmentDate)
        {
            try
            {
                return await _appointmentRepository.CheckLabAvailabilityAsync(labId, appointmentDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking availability for lab {labId} at {appointmentDate}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}