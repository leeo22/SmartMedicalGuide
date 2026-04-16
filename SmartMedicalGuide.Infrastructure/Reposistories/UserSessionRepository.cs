using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class UserSessionRepository : GenericRepositoryAsync<UserSession>, IUserSessionRepository
    {
        #region Fields
        private readonly DbSet<UserSession> _userSession;
        #endregion

        #region Constructors
        public UserSessionRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _userSession = dBContext.Set<UserSession>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
