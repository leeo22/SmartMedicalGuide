using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        #region Fields
        private readonly DbSet<User> _user;
        #endregion
        #region Constructors
        public UserRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _user = dbContext.Set<User>();
        }
        #endregion
        #region Handels Functions


        public async Task<List<User>> GetUsersListAsync()
        {
            return await _user.Include(x => x.Role).ToListAsync();
        }
        #endregion

    }
}
