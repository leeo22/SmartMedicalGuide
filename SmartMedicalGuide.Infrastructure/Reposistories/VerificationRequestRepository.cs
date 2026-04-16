using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class VerificationRequestRepository : GenericRepositoryAsync<VerificationRequest>, IVerificationRequestRepository
    {
        #region Fields
        private readonly DbSet<VerificationRequest> _verificationRequest;
        #endregion

        #region Constructors
        public VerificationRequestRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _verificationRequest = dBContext.Set<VerificationRequest>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
