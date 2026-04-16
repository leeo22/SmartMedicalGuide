using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IUserServices
    {
        public Task<List<User>> GetUsersListAsync();
        public Task<string> AddAsync(User user);
        public Task<User?> GetUserByIDAsync(int id);
        public Task<string> EditAsync(User user);
        public Task<string> DeleteAsync(User user);
    }
}
