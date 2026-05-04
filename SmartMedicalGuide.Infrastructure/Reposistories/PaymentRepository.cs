using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepositoryAsync<Payment>, IPaymentRepository
    {
        #region Fields
        private readonly DbSet<Payment> _payments;
        #endregion

        #region Constructors
        public PaymentRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _payments = dbContext.Set<Payment>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Payment?> GetPaymentByIdWithIncludesAsync(int id)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Include(x => x.LabAppointment)
                    .ThenInclude(a => a.Lab)
                        .ThenInclude(l => l.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PaymentId == id);
        }

        public async Task<List<Payment>> GetAllPaymentsWithIncludesAsync()
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Include(x => x.LabAppointment)
                    .ThenInclude(a => a.Lab)
                        .ThenInclude(l => l.User)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Payment>> GetByPatientIdAsync(int patientId)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Where(x => (x.DoctorAppointment != null && x.DoctorAppointment.PatientId == patientId) ||
                            (x.LabAppointment != null && x.LabAppointment.PatientId == patientId))
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.DoctorAppointment != null && x.DoctorAppointment.DoctorId == doctorId)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetByPaymentStatusAsync(string status)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentStatus == status && !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentDate >= fromDate && x.PaymentDate <= toDate && !x.IsDeleted)
                .OrderBy(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetByPaymentMethodAsync(string method)
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentMethod == method && !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<decimal> GetDoctorRevenueAsync(int doctorId)
        {
            return await _payments
                .Where(x => x.DoctorAppointment != null && x.DoctorAppointment.DoctorId == doctorId)
                .Where(x => x.PaymentStatus == "Completed" && !x.IsDeleted)
                .SumAsync(x => x.DoctorShare);
        }

        public async Task<object> GetPlatformRevenueAsync()
        {
            var completedPayments = await _payments
                .Where(x => x.PaymentStatus == "Completed" && !x.IsDeleted)
                .ToListAsync();

            return new
            {
                TotalRevenue = completedPayments.Sum(x => x.Amount),
                TotalPlatformFees = completedPayments.Sum(x => x.PlatformFee),
                TotalDoctorShares = completedPayments.Sum(x => x.DoctorShare),
                AveragePlatformFee = completedPayments.Any() ? completedPayments.Average(x => x.PlatformFee) : 0
            };
        }

        public async Task<object> GetRevenueReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            var query = _payments.Where(x => x.PaymentStatus == "Completed" && !x.IsDeleted);

            if (fromDate.HasValue)
                query = query.Where(x => x.PaymentDate >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(x => x.PaymentDate <= toDate.Value);

            var payments = await query.ToListAsync();

            return new
            {
                TotalRevenue = payments.Sum(x => x.Amount),
                TotalPlatformFees = payments.Sum(x => x.PlatformFee),
                TotalDoctorShares = payments.Sum(x => x.DoctorShare),
                ByMonth = payments.GroupBy(x => new { x.PaymentDate.Year, x.PaymentDate.Month })
                    .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Revenue = g.Sum(x => x.Amount) })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month),
                ByPaymentMethod = payments.GroupBy(x => x.PaymentMethod)
                    .Select(g => new { Method = g.Key, Total = g.Sum(x => x.Amount), Count = g.Count() }),
                ByDoctor = payments.Where(x => x.DoctorAppointment != null)
                    .GroupBy(x => x.DoctorAppointment.DoctorId)
                    .Select(g => new { DoctorId = g.Key, Revenue = g.Sum(x => x.Amount) })
            };
        }

        public async Task<List<Payment>> GetPendingPaymentsAsync()
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentStatus == "Pending" && !x.IsDeleted)
                .OrderBy(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<object> GetPaymentStatisticsAsync()
        {
            var payments = await _payments.Where(x => !x.IsDeleted).ToListAsync();

            return new
            {
                TotalPayments = payments.Count,
                TotalAmount = payments.Sum(x => x.Amount),
                AverageAmount = payments.Any() ? payments.Average(x => x.Amount) : 0,
                ByStatus = payments.GroupBy(x => x.PaymentStatus)
                    .Select(g => new { Status = g.Key, Count = g.Count(), Total = g.Sum(x => x.Amount) }),
                ByMethod = payments.GroupBy(x => x.PaymentMethod)
                    .Select(g => new { Method = g.Key, Count = g.Count(), Total = g.Sum(x => x.Amount) })
            };
        }

        public async Task<List<Payment>> GetWalletPaymentsAsync()
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentMethod == "Wallet" && !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetTransferPaymentsAsync()
        {
            return await _payments
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.DoctorAppointment)
                    .ThenInclude(a => a.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => x.PaymentMethod == "BankTransfer" && !x.IsDeleted)
                .OrderByDescending(x => x.PaymentDate)
                .ToListAsync();
        }
        #endregion
    }
}