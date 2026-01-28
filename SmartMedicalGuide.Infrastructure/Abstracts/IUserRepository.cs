using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
        public Task<List<User>> GetUsersListAsync();
    }
}
