using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class PrescriptionRepository : GenericRepositoryAsync<Prescription>, IPrescriptionRepository
    {
        #region Fields
        private readonly DbSet<Prescription> _prescriptions;
        #endregion

        #region Constructors
        public PrescriptionRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _prescriptions = dbContext.Set<Prescription>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Prescription?> GetPrescriptionByIdWithIncludesAsync(int id)
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.DoctorAppointment)
                .Include(x => x.PrescriptionItems)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PrescriptionId == id);
        }

        public async Task<List<Prescription>> GetAllPrescriptionsWithIncludesAsync()
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.DoctorAppointment)
                .Include(x => x.PrescriptionItems)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Prescription>> GetByPatientIdAsync(int patientId)
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.PrescriptionItems)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Prescription>> GetByDoctorIdAsync(int doctorId)
        {
            return await _prescriptions
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.PrescriptionItems)
                .Where(x => x.DoctorId == doctorId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<Prescription?> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.PrescriptionItems)
                .Where(x => x.DoctorAppointmentId == appointmentId && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Prescription>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.PrescriptionItems)
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<Prescription?> GetPrescriptionWithItemsAsync(int id)
        {
            return await _prescriptions
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.DoctorAppointment)
                .Include(x => x.PrescriptionItems)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PrescriptionId == id);
        }

        public async Task<object> GetPrescriptionStatisticsAsync()
        {
            var prescriptions = await _prescriptions.Where(x => !x.IsDeleted).ToListAsync();
            var activePrescriptions = prescriptions.Where(x => x.Status == "Active").Count();
            var completedPrescriptions = prescriptions.Where(x => x.Status == "Completed").Count();
            var expiredPrescriptions = prescriptions.Where(x => x.Status == "Expired").Count();

            return new
            {
                TotalPrescriptions = prescriptions.Count,
                ActiveCount = activePrescriptions,
                CompletedCount = completedPrescriptions,
                ExpiredCount = expiredPrescriptions,
                ByMonth = prescriptions.GroupBy(x => new { x.CreatedAt.Year, x.CreatedAt.Month })
                    .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month),
                ByDoctor = prescriptions.GroupBy(x => x.DoctorId)
                    .Select(g => new { DoctorId = g.Key, Count = g.Count() })
            };
        }
        #endregion
    }
}