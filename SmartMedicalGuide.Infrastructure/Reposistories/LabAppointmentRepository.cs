using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class LabAppointmentRepository : GenericRepositoryAsync<LabAppointment>, ILabAppointmentRepository
    {
        #region Fields
        private readonly DbSet<LabAppointment> _appointments;
        #endregion

        #region Constructors
        public LabAppointmentRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _appointments = dbContext.Set<LabAppointment>();
        }
        #endregion

        #region Basic Handlers
        public async Task<LabAppointment?> GetAppointmentByIdWithIncludesAsync(int id)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Include(x => x.Payment)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.LabAppointmentId == id);
        }

        public async Task<List<LabAppointment>> GetAllAppointmentsWithIncludesAsync()
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Include(x => x.Payment)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<LabAppointment>> GetByLabIdAsync(int labId)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.LabId == labId && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetByPatientIdAsync(int patientId)
        {
            return await _appointments
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetByDateAsync(DateTime date)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.AppointmentDate.Date == date.Date && !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetByStatusAsync(string status)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.Status == status && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetLabUpcomingAppointmentsAsync(int labId)
        {
            var now = DateTime.UtcNow;
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.LabId == labId && x.AppointmentDate > now && x.Status != "Cancelled" && !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId)
        {
            var now = DateTime.UtcNow;
            return await _appointments
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.PatientId == patientId && x.AppointmentDate > now && x.Status != "Cancelled" && !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<LabAppointment>> GetLabTodayAppointmentsAsync(int labId)
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.LabId == labId && x.AppointmentDate >= today && x.AppointmentDate < tomorrow && !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<bool> CheckLabAvailabilityAsync(int labId, DateTime appointmentDate)
        {
            var existingAppointment = await _appointments
                .AnyAsync(x => x.LabId == labId && x.AppointmentDate == appointmentDate && x.Status != "Cancelled" && !x.IsDeleted);
            return !existingAppointment;
        }

        public async Task<string> CancelAppointmentAsync(int appointmentId, string? cancellationReason = null, int? rescheduledByUserId = null)
        {
            try
            {
                var appointment = await _appointments
                    .FirstOrDefaultAsync(x => x.LabAppointmentId == appointmentId && !x.IsDeleted);

                if (appointment == null)
                    return "Appointment not found";

                appointment.Status = "Cancelled";
                appointment.CancellationReason = cancellationReason;
                appointment.RescheduledByUserId = rescheduledByUserId;

                await UpdateAsync(appointment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to cancel appointment: {ex.Message}";
            }
        }

        public async Task<string> ConfirmAppointmentAsync(int appointmentId)
        {
            try
            {
                var appointment = await _appointments
                    .FirstOrDefaultAsync(x => x.LabAppointmentId == appointmentId && !x.IsDeleted);

                if (appointment == null)
                    return "Appointment not found";

                appointment.Status = "Confirmed";
                await UpdateAsync(appointment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to confirm appointment: {ex.Message}";
            }
        }

        public async Task<string> CompleteAppointmentAsync(int appointmentId)
        {
            try
            {
                var appointment = await _appointments
                    .FirstOrDefaultAsync(x => x.LabAppointmentId == appointmentId && !x.IsDeleted);

                if (appointment == null)
                    return "Appointment not found";

                appointment.Status = "Completed";
                await UpdateAsync(appointment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to complete appointment: {ex.Message}";
            }
        }
        #endregion
    }
}