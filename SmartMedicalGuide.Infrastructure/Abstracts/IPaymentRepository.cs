using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPaymentRepository : IGenericRepositoryAsync<Payment>
    {
        public Task<List<Payment>> GetPaymentsListAsync();
    }
}
