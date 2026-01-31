using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPaymentSevices
    {
        public Task<List<Payment>> GetPaymentsListAsync();
        public Task<string> AddAsync(Payment payment);
        public Task<Payment> GetPaymentByIDAsync(int id);
        public Task<string> EditAsync(Payment payment);
        public Task<string> DeleteAsync(Payment payment);
    }
}
