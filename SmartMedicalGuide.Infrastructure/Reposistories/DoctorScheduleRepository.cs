using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class DoctorScheduleRepository : GenericRepositoryAsync<DoctorSchedule>, IDoctorScheduleRepository
    {

        #region Fields
        private readonly DbSet<DoctorSchedule> _doctor;
        #endregion
        #region Constructors
        public DoctorScheduleRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _doctor = dbContext.Set<DoctorSchedule>();
        }
        #endregion
        #region Handels Functions
        #endregion

    }
}
