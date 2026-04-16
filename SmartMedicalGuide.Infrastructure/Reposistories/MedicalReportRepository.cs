using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class MedicalReportRepository : GenericRepositoryAsync<MedicalReport>, IMedicalReportRepository
    {
        #region Fields
        private readonly DbSet<MedicalReport> _medicalReport;
        #endregion

        #region Constructors
        public MedicalReportRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _medicalReport = dBContext.Set<MedicalReport>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
