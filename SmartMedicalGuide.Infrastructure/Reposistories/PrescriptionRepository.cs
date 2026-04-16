using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class PrescriptionRepository : GenericRepositoryAsync<Prescription>, IPrescriptionRepository
    {
        #region Fields
        private readonly DbSet<Prescription> _prescription;
        #endregion

        #region Constructors
        public PrescriptionRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _prescription = dBContext.Set<Prescription>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
