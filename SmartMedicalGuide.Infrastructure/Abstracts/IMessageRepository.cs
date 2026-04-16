using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IMessageRepository : IGenericRepositoryAsync<Message>
    {
        //public Task<List<Message>> GetMessagesListAsync();
    }
}
