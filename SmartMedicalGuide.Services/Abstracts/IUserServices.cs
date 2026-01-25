using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IUserServices : IGenericRepositoryAsync<User>
    {
        public Task<List<User>> GetAllUserListAsync();
    }
}
