using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class ChatRepository : GenericRepositoryAsync<Chat>, IChatRepository
    {
        #region Fields
        private readonly DbSet<Chat> _chat;
        #endregion

        #region Constructors
        public ChatRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _chat = dBContext.Set<Chat>();

        }

        #endregion

        #region Handels Functions

        #endregion


    }
}
