using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class PaymentRepository : GenericRepositoryAsync<Payment>, IPaymentRepository
    {
        #region Fields
        private readonly DbSet<Payment> _payment;
        #endregion

        #region Constructors
        public PaymentRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _payment = dBContext.Set<Payment>();

        }






        #endregion

        #region Handels Functions
        public async Task<List<Payment>> GetPaymentsListAsync()
        {
            return await _payment.ToListAsync();
        }
        #endregion
    }
}
