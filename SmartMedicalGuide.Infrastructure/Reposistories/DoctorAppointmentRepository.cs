using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class DoctorAppointmentRepository : GenericRepositoryAsync<DoctorAppointment>, IDoctorAppointmentRepository
    {
        #region Fields
        private readonly DbSet<DoctorAppointment> _appointments;
        #endregion

        #region Constructors
        public DoctorAppointmentRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _appointments = dbContext.Set<DoctorAppointment>();
        }
        #endregion

        #region Basic Handlers
        public async Task<DoctorAppointment?> GetAppointmentByIdWithIncludesAsync(int id)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                //.Include(x => x.Prescriptions)
                .Include(x => x.Payment)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.AppointmentId == id);
        }

        public async Task<List<DoctorAppointment>> GetAllAppointmentsWithIncludesAsync()
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                //.Include(x => x.Prescriptions)
                .Include(x => x.Payment)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<DoctorAppointment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.DoctorId == doctorId && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetByPatientIdAsync(int patientId)
        {
            return await _appointments
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetByDateAsync(DateTime date)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.AppointmentDate.HasValue &&
                            x.AppointmentDate.Value.Date == date.Date &&
                            !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetByStatusAsync(string status)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.Status == status && !x.IsDeleted)
                .OrderByDescending(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetDoctorUpcomingAppointmentsAsync(int doctorId)
        {
            var now = DateTime.UtcNow;
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.DoctorId == doctorId &&
                            x.AppointmentDate > now &&
                            x.Status != "Cancelled" &&
                            !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId)
        {
            var now = DateTime.UtcNow;
            return await _appointments
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.PatientId == patientId &&
                            x.AppointmentDate > now &&
                            x.Status != "Cancelled" &&
                            !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetDoctorTodayAppointmentsAsync(int doctorId)
        {
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.DoctorId == doctorId &&
                            x.AppointmentDate >= today &&
                            x.AppointmentDate < tomorrow &&
                            !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<List<DoctorAppointment>> GetDoctorAppointmentsByDateRangeAsync(int doctorId, DateTime fromDate, DateTime toDate)
        {
            return await _appointments
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.DoctorId == doctorId &&
                            x.AppointmentDate >= fromDate &&
                            x.AppointmentDate <= toDate &&
                            !x.IsDeleted)
                .OrderBy(x => x.AppointmentDate)
                .ToListAsync();
        }

        public async Task<int> GetDoctorAppointmentsCountAsync(int doctorId)
        {
            return await _appointments
                .CountAsync(x => x.DoctorId == doctorId && !x.IsDeleted);
        }

        public async Task<bool> CheckDoctorAvailabilityAsync(int doctorId, DateTime appointmentDate)
        {
            // التحقق من وجود موعد في نفس الوقت
            var existingAppointment = await _appointments
                .AnyAsync(x => x.DoctorId == doctorId &&
                               x.AppointmentDate == appointmentDate &&
                               x.Status != "Cancelled" &&
                               !x.IsDeleted);
            return !existingAppointment;
        }

        public async Task<object> GetAppointmentsReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            var query = _appointments.Where(x => !x.IsDeleted);

            if (fromDate.HasValue)
                query = query.Where(x => x.AppointmentDate >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(x => x.AppointmentDate <= toDate.Value);

            var appointments = await query.ToListAsync();

            return new
            {
                TotalAppointments = appointments.Count,
                Pending = appointments.Count(x => x.Status == "Pending"),
                Confirmed = appointments.Count(x => x.Status == "Confirmed"),
                Completed = appointments.Count(x => x.Status == "Completed"),
                Cancelled = appointments.Count(x => x.Status == "Cancelled"),
                TotalRevenue = appointments.Where(x => x.Status == "Completed").Sum(x => x.Price ?? 0),
                ByDoctor = appointments.GroupBy(x => x.DoctorId)
                    .Select(g => new { DoctorId = g.Key, Count = g.Count() }),
                ByDate = appointments.GroupBy(x => x.AppointmentDate.Value.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .OrderBy(x => x.Date)
            };
        }
        #endregion
    }
}