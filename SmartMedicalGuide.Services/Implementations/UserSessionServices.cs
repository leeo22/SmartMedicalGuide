using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class UserSessionServices : IUserSessionServices
    {
        #region Fields
        private readonly IUserSessionRepository _userSessionRepository;
        #endregion

        #region Constructors
        public UserSessionServices(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(UserSession userSession)
        {
            await _userSessionRepository.AddAsync(userSession);
            return "Success";
        }

        public async Task<string> DeleteAsync(UserSession userSession)
        {
            var trans = _userSessionRepository.BeginTransaction();
            try
            {
                await _userSessionRepository.DeleteAsync(userSession);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(UserSession userSession)
        {
            await _userSessionRepository.UpdateAsync(userSession);
            return "Success";
        }

        public async Task<UserSession> GetActiveSessionByUserIdAsync(int userId)
        {
            return await _userSessionRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId && x.LogoutTime == null)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetActiveSessionsCountByUserIdAsync(int userId)
        {
            return await _userSessionRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId && x.LogoutTime == null)
                .CountAsync();
        }

        public async Task<UserSession> GetByIDAsync(int id)
        {
            var result = _userSessionRepository.GetByIdAsync()
                                            .Where(x => x.SessionId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<UserSession>> GetByUserIdAsync(int userId)
        {
            return await _userSessionRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.LoginTime)
                .ToListAsync();
        }

        public async Task<List<UserSession>> GetListAsync()
        {
            return await _userSessionRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}