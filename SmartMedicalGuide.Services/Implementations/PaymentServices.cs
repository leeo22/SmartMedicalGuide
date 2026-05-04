using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class PaymentServices : IPaymentServices
    {
        #region Fields
        private readonly IPaymentRepository _paymentRepository;
        #endregion

        #region Constructors
        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Payment>> GetListAsync()
        {
            return await _paymentRepository.GetAllPaymentsWithIncludesAsync();
        }

        public async Task<Payment?> GetByIDAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdWithIncludesAsync(id);
        }

        public async Task<string> AddAsync(Payment payment)
        {
            try
            {
                payment.PaymentDate = DateTime.UtcNow;
                payment.PaymentStatus = payment.PaymentStatus ?? "Pending";
                payment.IsDeleted = false;

                await _paymentRepository.AddAsync(payment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add payment: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Payment payment)
        {
            try
            {
                var existing = await _paymentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.PaymentId == payment.PaymentId && !x.IsDeleted);

                if (existing == null)
                    return "Payment not found";

                existing.PaymentMethod = payment.PaymentMethod ?? existing.PaymentMethod;
                existing.WalletType = payment.WalletType ?? existing.WalletType;
                existing.ReceiverName = payment.ReceiverName ?? existing.ReceiverName;
                existing.ReceiverNumber = payment.ReceiverNumber ?? existing.ReceiverNumber;
                existing.TransferImagePath = payment.TransferImagePath ?? existing.TransferImagePath;
                existing.PaymentStatus = payment.PaymentStatus ?? existing.PaymentStatus;
                existing.Notes = payment.Notes ?? existing.Notes;

                await _paymentRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit payment: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Payment payment)
        {
            try
            {
                payment.IsDeleted = true;
                await _paymentRepository.UpdateAsync(payment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete payment: {ex.Message}";
            }
        }
        #endregion

        #region Additional Functions
        public async Task<List<Payment>> GetByPatientIdAsync(int patientId)
        {
            return await _paymentRepository.GetByPatientIdAsync(patientId);
        }

        public async Task<List<Payment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _paymentRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<List<Payment>> GetByPaymentStatusAsync(string status)
        {
            return await _paymentRepository.GetByPaymentStatusAsync(status);
        }

        public async Task<List<Payment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _paymentRepository.GetByDateRangeAsync(fromDate, toDate);
        }

        public async Task<List<Payment>> GetByPaymentMethodAsync(string method)
        {
            return await _paymentRepository.GetByPaymentMethodAsync(method);
        }

        public async Task<decimal> GetDoctorRevenueAsync(int doctorId)
        {
            return await _paymentRepository.GetDoctorRevenueAsync(doctorId);
        }

        public async Task<object> GetPlatformRevenueAsync()
        {
            return await _paymentRepository.GetPlatformRevenueAsync();
        }

        public async Task<object> GetRevenueReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            return await _paymentRepository.GetRevenueReportAsync(fromDate, toDate);
        }

        public async Task<string> UpdatePaymentStatusAsync(int paymentId, string status)
        {
            try
            {
                var payment = await _paymentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.PaymentId == paymentId && !x.IsDeleted);

                if (payment == null)
                    return "Payment not found";

                payment.PaymentStatus = status;
                await _paymentRepository.UpdateAsync(payment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to update payment status: {ex.Message}";
            }
        }

        public async Task<string> VerifyPaymentAsync(int paymentId)
        {
            try
            {
                var payment = await _paymentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.PaymentId == paymentId && !x.IsDeleted);

                if (payment == null)
                    return "Payment not found";

                payment.PaymentStatus = "Completed";
                await _paymentRepository.UpdateAsync(payment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to verify payment: {ex.Message}";
            }
        }

        public async Task<List<Payment>> GetPendingPaymentsAsync()
        {
            return await _paymentRepository.GetPendingPaymentsAsync();
        }

        public async Task<object> GetPaymentStatisticsAsync()
        {
            return await _paymentRepository.GetPaymentStatisticsAsync();
        }

        public async Task<List<Payment>> GetWalletPaymentsAsync()
        {
            return await _paymentRepository.GetWalletPaymentsAsync();
        }

        public async Task<List<Payment>> GetTransferPaymentsAsync()
        {
            return await _paymentRepository.GetTransferPaymentsAsync();
        }
        #endregion
    }
}