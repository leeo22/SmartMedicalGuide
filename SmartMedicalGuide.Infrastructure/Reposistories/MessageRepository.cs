using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class MessageRepository : GenericRepositoryAsync<Message>, IMessageRepository
    {
        #region Fields
        private readonly DbSet<Message> _message;
        #endregion

        #region Constructors
        public MessageRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _message = dBContext.Set<Message>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
