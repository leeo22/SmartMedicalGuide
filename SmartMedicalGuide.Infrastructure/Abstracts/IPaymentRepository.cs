using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPaymentRepository : IGenericRepositoryAsync<Payment>
    {
        Task<Payment?> GetPaymentByIdWithIncludesAsync(int id);
        Task<List<Payment>> GetAllPaymentsWithIncludesAsync();
        Task<List<Payment>> GetByPatientIdAsync(int patientId);
        Task<List<Payment>> GetByDoctorIdAsync(int doctorId);
        Task<List<Payment>> GetByPaymentStatusAsync(string status);
        Task<List<Payment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<List<Payment>> GetByPaymentMethodAsync(string method);
        Task<decimal> GetDoctorRevenueAsync(int doctorId);
        Task<object> GetPlatformRevenueAsync();
        Task<object> GetRevenueReportAsync(DateTime? fromDate, DateTime? toDate);
        Task<List<Payment>> GetPendingPaymentsAsync();
        Task<object> GetPaymentStatisticsAsync();
        Task<List<Payment>> GetWalletPaymentsAsync();
        Task<List<Payment>> GetTransferPaymentsAsync();
    }
}