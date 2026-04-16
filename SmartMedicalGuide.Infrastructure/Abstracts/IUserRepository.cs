using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        public Task<List<User>> GetUsersListAsync();
    }
}
