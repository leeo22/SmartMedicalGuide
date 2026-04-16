using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class PrescriptionItemRepository : GenericRepositoryAsync<PrescriptionItem>, IPrescriptionItemRepository
    {
        #region Fields
        private readonly DbSet<PrescriptionItem> _prescriptionItem;
        #endregion

        #region Constructors
        public PrescriptionItemRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _prescriptionItem = dBContext.Set<PrescriptionItem>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
