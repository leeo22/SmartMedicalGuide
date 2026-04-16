using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IChatRepository : IGenericRepositoryAsync<Chat>
    {
        //public Task<List<Chat>> GetChatsListAsync();
    }

}
