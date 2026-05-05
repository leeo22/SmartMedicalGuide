using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
