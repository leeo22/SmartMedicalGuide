using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IUserSessionRepository : IGenericRepositoryAsync<UserSession>
    {
        //public Task<List<UserSession>> GetUserSessionsListAsync();
    }
}
