using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class AttachmentRepository : GenericRepositoryAsync<Attachment>, IAttachmentRepository
    {
        #region Fields
        private readonly DbSet<Attachment> _attachment;
        #endregion

        #region Constructors
        public AttachmentRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _attachment = dBContext.Set<Attachment>();

        }

        #endregion

        #region Handels Functions

        #endregion


    }
}
