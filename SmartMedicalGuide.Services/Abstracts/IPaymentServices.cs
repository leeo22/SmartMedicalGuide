using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPaymentServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Payment>> GetListAsync();
        Task<Payment?> GetByIDAsync(int id);
        Task<string> AddAsync(Payment payment);
        Task<string> EditAsync(Payment payment);
        Task<string> DeleteAsync(Payment payment);
        #endregion

        #region Additional Functions - 14 Functions
        Task<List<Payment>> GetByPatientIdAsync(int patientId);
        Task<List<Payment>> GetByDoctorIdAsync(int doctorId);
        Task<List<Payment>> GetByPaymentStatusAsync(string status);
        Task<List<Payment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<List<Payment>> GetByPaymentMethodAsync(string method);
        Task<decimal> GetDoctorRevenueAsync(int doctorId);
        Task<object> GetPlatformRevenueAsync();
        Task<object> GetRevenueReportAsync(DateTime? fromDate, DateTime? toDate);
        Task<string> UpdatePaymentStatusAsync(int paymentId, string status);
        Task<string> VerifyPaymentAsync(int paymentId);
        Task<List<Payment>> GetPendingPaymentsAsync();
        Task<object> GetPaymentStatisticsAsync();
        Task<List<Payment>> GetWalletPaymentsAsync();
        Task<List<Payment>> GetTransferPaymentsAsync();
        #endregion
    }
}