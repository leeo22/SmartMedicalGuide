using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class PaymentServices : IPaymentServices
    {
        #region Fields
        public readonly IPaymentRepository _paymentRepository;
        #endregion

        #region Constructors
        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        #endregion
        #region Handels Functions
        public async Task<string> AddAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
            return "Success";
        }

        public async Task<string> DeleteAsync(Payment payment)
        {
            var trans = _paymentRepository.BeginTransaction();
            try
            {
                await _paymentRepository.DeleteAsync(payment);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
            return "Success";
        }

        public async Task<Payment> GetPaymentByIDAsync(int id)
        {
            var payment = _paymentRepository.GetByIdAsync()
                                      .Where(x => x.PaymentId.Equals(id))
                                      .FirstOrDefault();
            return payment;
        }

        public async Task<List<Payment>> GetPaymentsListAsync()
        {
            return await _paymentRepository.GetPaymentsListAsync();
        }
        #endregion

    }
}
