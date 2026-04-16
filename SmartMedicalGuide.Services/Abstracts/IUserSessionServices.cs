using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IUserSessionServices
    {
        public Task<List<UserSession>> GetListAsync();
        public Task<UserSession> GetByIDAsync(int id);
        public Task<string> AddAsync(UserSession userSession);
        public Task<string> EditAsync(UserSession userSession);
        public Task<string> DeleteAsync(UserSession userSession);
        public Task<List<UserSession>> GetByUserIdAsync(int userId);
        public Task<UserSession> GetActiveSessionByUserIdAsync(int userId);
        public Task<int> GetActiveSessionsCountByUserIdAsync(int userId);
    }
}